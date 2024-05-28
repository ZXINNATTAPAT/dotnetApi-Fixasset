// using Microsoft.EntityFrameworkCore;
// using WebApplication1.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
// using System;
// using System.Text;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.OpenApi.Models;
// using Microsoft.Extensions.Configuration;

// public void ConfigureServices(IServiceCollection services)
// {
//     services.AddDbContext<AssetsContext>(options =>
//     {
//         options.UseSqlServer("Server=DESKTOP-KTV0Q62\\SQLEXPRESS;Database=Fixedassetsdb;Trusted_Connection=True;TrustServerCertificate=True;");
//     });

//     services.AddIdentity<IdentityUser, IdentityRole>(options =>
//     {
//         options.Password.RequireDigit = true;
//         options.Password.RequireLowercase = true;
//         options.Password.RequireUppercase = true;
//         options.Password.RequireNonAlphanumeric = false;
//         options.Password.RequiredLength = 8;
//     })
//     .AddEntityFrameworkStores<AssetsContext>()
//     .AddDefaultTokenProviders();

//     services.AddAuthentication(options =>
//     {
//         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     }).AddJwtBearer(options =>
//     {
//         options.RequireHttpsMetadata = false;
//         options.SaveToken = true;
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])),
//             ValidateIssuer = true,
//             ValidIssuer = Configuration["JWT:ValidIssuer"],
//             ValidateAudience = true,
//             ValidAudience = Configuration["JWT:ValidAudience"],
//             ClockSkew = TimeSpan.Zero
//         };
//     });

//     services.AddControllers();
//     services.AddSwaggerGen(c =>
//     {
//         c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
//     });
// }
