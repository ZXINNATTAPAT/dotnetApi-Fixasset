using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Generate a new key (32 bytes for 256 bits)
var key = new byte[32];
using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
{
    rng.GetBytes(key);
}

// Convert the byte array key to a base64-encoded string for storage
string base64Key = Convert.ToBase64String(key);

// Update configuration with the new key
builder.Configuration["Jwt:Key"] = base64Key;

// Use the new key in the JWT token generation
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(base64Key));
var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

// ใน ConfigureServices
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AssetsContext>(options =>
{
    // options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    options.UseSqlServer("Server=DESKTOP-KTV0Q62\\SQLEXPRESS;Database=Fixedassetsdb8;Trusted_Connection=True;TrustServerCertificate=True;");
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            // ValidIssuer = builder.Configuration["Jwt:Issuer"],
            // ValidIssuer = false,
            // ValidAudience = builder.Configuration["Jwt:Audience"],
            // ValidAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

// Add response compression services
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true; // Enable for HTTPS
});

// Configure Gzip compression level
builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest; // or CompressionLevel.Optimal
});

// Add caching services
builder.Services.AddMemoryCache();

// Configure Kestrel
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    // serverOptions.Listen(IPAddress.Any, 4200, listenOptions =>
    // {
    //     // listenOptions.UseHttps();
    //     listenOptions.Protocols = HttpProtocols.Http2;
    // });

    // Set limits
    serverOptions.Limits.MaxConcurrentConnections = 100;
    serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;
    serverOptions.Limits.MaxRequestBodySize = 10 * 1024; // 10 KB
    serverOptions.Limits.MinRequestBodyDataRate =
        new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
    serverOptions.Limits.MinResponseDataRate =
        new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
    serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
    serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(1);
});

var app = builder.Build();

app.UseCors(policyBuilder =>
{
    policyBuilder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
    });
}

// Other configurations
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Set Cache-Control header to 10 minutes
        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");
        // Optionally set the Expires header
        ctx.Context.Response.Headers.Append("Expires", DateTime.UtcNow.AddMinutes(10).ToString("R"));
    }
});

app.UseHttpsRedirection();

// Enable response compression
app.UseResponseCompression();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();