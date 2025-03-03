using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MasterPolDesktop.Models;

public partial class _43pKolinichenkoUpContext : DbContext
{
    public _43pKolinichenkoUpContext()
    {
    }

    public _43pKolinichenkoUpContext(DbContextOptions<_43pKolinichenkoUpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=43P_Kolinichenko_UP;Username=postgres;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("material_types_pk");

            entity.ToTable("material_types");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.NameTypeMaterial)
                .HasColumnType("character varying")
                .HasColumnName("name_type_material");
            entity.Property(e => e.PercentDefectMaterials).HasColumnName("percent_defect_materials");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.IdPartner).HasName("partners_pk");

            entity.ToTable("partners");

            entity.Property(e => e.IdPartner).HasColumnName("id_partner");
            entity.Property(e => e.ContactEmail)
                .HasColumnType("character varying")
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPhone)
                .HasColumnType("character varying")
                .HasColumnName("contact_phone");
            entity.Property(e => e.DirectorFullName)
                .HasColumnType("character varying")
                .HasColumnName("director_full_name");
            entity.Property(e => e.IdTypeCompany).HasColumnName("id_type_company");
            entity.Property(e => e.LegalAddress)
                .HasColumnType("character varying")
                .HasColumnName("legal_address");
            entity.Property(e => e.NameCompany)
                .HasColumnType("character varying")
                .HasColumnName("name_company");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.TaxIdentificationNumber)
                .HasColumnType("character varying")
                .HasColumnName("tax_identification_number");

            entity.HasOne(d => d.IdTypeCompanyNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdTypeCompany)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("partners_partner_types_fk");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partner_products_pk");

            entity.ToTable("partner_products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountProduct).HasColumnName("count_product");
            entity.Property(e => e.DateOfSale).HasColumnName("date_of_sale");
            entity.Property(e => e.IdPartner).HasColumnName("id_partner");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdPartnerNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.IdPartner)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("partner_products_partners_fk");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("partner_products_products_fk");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("partner_types_pk");

            entity.ToTable("partner_types");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.TypeName)
                .HasColumnType("character varying")
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("products_pk");

            entity.ToTable("products");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.ArticleNumber)
                .HasColumnType("character varying")
                .HasColumnName("article_number");
            entity.Property(e => e.Height)
                .HasDefaultValueSql("0")
                .HasColumnName("height");
            entity.Property(e => e.IdProductType).HasColumnName("id_product_type");
            entity.Property(e => e.Length)
                .HasDefaultValueSql("0")
                .HasColumnName("length");
            entity.Property(e => e.MinimumPrice)
                .HasDefaultValueSql("0")
                .HasColumnName("minimum_price");
            entity.Property(e => e.ProductName)
                .HasColumnType("character varying")
                .HasColumnName("product_name");
            entity.Property(e => e.WeightWithPack)
                .HasDefaultValueSql("0")
                .HasColumnName("weight_with_pack");
            entity.Property(e => e.WeightWithoutPack)
                .HasDefaultValueSql("0")
                .HasColumnName("weight_without_pack");
            entity.Property(e => e.Width)
                .HasDefaultValueSql("0")
                .HasColumnName("width");

            entity.HasOne(d => d.IdProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductType)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("products_product_types_fk");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("product_types_pk");

            entity.ToTable("product_types");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.Ratio).HasColumnName("ratio");
            entity.Property(e => e.TypeName)
                .HasColumnType("character varying")
                .HasColumnName("type_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
