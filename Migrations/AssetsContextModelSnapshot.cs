﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AssetsContext))]
    partial class AssetsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Models.Accounts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Accounts_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Accounts_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("WebApplication1.Models.Assetcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Asc_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Asc_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AssetCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Assetcategories");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetDetails", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetId"), 1L, 1);

                    b.Property<decimal>("AccumulatedDepreciation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AssetAge")
                        .HasColumnType("int");

                    b.Property<string>("AssetCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BookValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CalculatedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepreciationCalculationStartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepreciationEndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DepreciationRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DepreciationStartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DepreciationValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PurchasedFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReceiptDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResponsibleEmployee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ScrapPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TaxInvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetId");

                    b.ToTable("AssetDetails");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetDetails2", b =>
                {
                    b.Property<int>("AssetDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetDetailId"), 1L, 1);

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InsuranceAge")
                        .HasColumnType("int");

                    b.Property<string>("InsuranceCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsuranceEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsuranceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsurancePolicyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("InsurancePremium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InsuranceStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaintenanceRecommendation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentVoucherNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssetDetailId");

                    b.HasIndex("AssetId");

                    b.ToTable("AssetDetails2");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetDetails3", b =>
                {
                    b.Property<int>("AssetDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetDetailId"), 1L, 1);

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<decimal>("ExchangeRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InstallationCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OtherCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ShipWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TransportCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AssetDetailId");

                    b.HasIndex("AssetId");

                    b.ToTable("AssetDetails3");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetDisposal", b =>
                {
                    b.Property<int>("DisposalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisposalId"), 1L, 1);

                    b.Property<string>("AssetCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DisposalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DisposalId");

                    b.ToTable("AssetDisposals");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetInventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"), 1L, 1);

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<string>("AssetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BookValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inspector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("InventoryValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LocationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Verifier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InventoryId");

                    b.HasIndex("AssetId");

                    b.ToTable("AssetInventory");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetSales", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"), 1L, 1);

                    b.Property<string>("AssetCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BookValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SaleId");

                    b.ToTable("AssetSales");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetSharing", b =>
                {
                    b.Property<int>("SharingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SharingId"), 1L, 1);

                    b.Property<string>("AssetCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SharingId");

                    b.ToTable("AssetSharing");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetTransferLog", b =>
                {
                    b.Property<int>("TransferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransferId"), 1L, 1);

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<string>("AssetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferredFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferredTo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransferId");

                    b.HasIndex("AssetId");

                    b.ToTable("AssetTransferLogs");
                });

            modelBuilder.Entity("WebApplication1.Models.Assettypecode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AssetCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Assettypecodes");
                });

            modelBuilder.Entity("WebApplication1.Models.Countingunit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("unitCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countingunits");
                });

            modelBuilder.Entity("WebApplication1.Models.Factiontypecode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FactionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Factiontypecodes");
                });

            modelBuilder.Entity("WebApplication1.Models.PropertySeller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Homepage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telfax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TinNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PropertySellers");
                });

            modelBuilder.Entity("WebApplication1.Models.RepairAsset", b =>
                {
                    b.Property<int>("RepairAssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RepairAssetId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AssetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RepairAssetId");

                    b.HasIndex("AssetId");

                    b.ToTable("RepairAssets");
                });

            modelBuilder.Entity("WebApplication1.Models.Responsibleperson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RP_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RP_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ResponsiblePersons");
                });

            modelBuilder.Entity("WebApplication1.Models.Sectiontypecode", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"), 1L, 1);

                    b.Property<string>("SectionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sectioncode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectionId");

                    b.ToTable("SectionTypeCodes");
                });

            modelBuilder.Entity("WebApplication1.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodeId")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("affiliation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("positiontype")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("prefix")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("subposition")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("workgroup")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetDetails2", b =>
                {
                    b.HasOne("WebApplication1.Models.AssetDetails", "AssetDetails")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetDetails");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetDetails3", b =>
                {
                    b.HasOne("WebApplication1.Models.AssetDetails", "AssetDetails")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetDetails");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetInventory", b =>
                {
                    b.HasOne("WebApplication1.Models.AssetDetails", "AssetDetails")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetDetails");
                });

            modelBuilder.Entity("WebApplication1.Models.AssetTransferLog", b =>
                {
                    b.HasOne("WebApplication1.Models.AssetDetails", "AssetDetails")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetDetails");
                });

            modelBuilder.Entity("WebApplication1.Models.RepairAsset", b =>
                {
                    b.HasOne("WebApplication1.Models.AssetDetails", "AssetDetails")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
