using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AssetsContext : DbContext
    {
        public DbSet<Users>? Users { get; set; }
         // ใช้ nullable reference types
        public DbSet<AssetDetails>? AssetDetails { get; set; } 
        // ใช้ nullable reference types
        public DbSet<AssetDetails2>? AssetDetails2 { get; set; }
         // ใช้ nullable reference types
        public DbSet<AssetDetails3>? AssetDetails3 { get; set; }
         // ใช้ nullable reference types
        public DbSet<AssetDisposal>? AssetDisposals { get; set; } 

        public DbSet<AssetInventory>? AssetInventory { get; set; }

        public DbSet<AssetSales>? AssetSales { get; set; } 

        public DbSet<AssetSharing>? AssetSharing { get; set; } 

        public DbSet<RepairAsset>? RepairAssets { get; set; } 

        public DbSet<AssetTransferLog>? AssetTransferLogs { get; set; }

        public DbSet<Accounts>? Accounts { get; set; }

        public DbSet<Assetcategory>? Assetcategories { get; set; }

        public DbSet<Factiontypecode>? Factiontypecodes { get; set; }

        public DbSet<Assettypecode>? Assettypecodes { get; set; }

        public DbSet<Countingunit>? Countingunits { get; set; }

        public DbSet<PropertySeller>? PropertySellers { get; set; }

        public DbSet<Responsibleperson>? ResponsiblePersons { get; set; }

        public DbSet<Sectiontypecode>? SectionTypeCodes { get; set; }

        public DbSet<Depreciation>? Depreciations { get; set; }

        // ใช้ nullable reference types

        // หรือใช้ [Required] เพื่อระบุว่าต้องมีค่า
        // [Required]
        // public DbSet<Users> Users { get; set; }

        public AssetsContext(DbContextOptions options) : base(options)
        {
            
        }
    }

}