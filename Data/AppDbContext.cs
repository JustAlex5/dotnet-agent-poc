using System;
using System.Collections.Generic;
using AgentAiDemo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentAiDemo.API.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyRelation> CompanyRelations { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("addresses_pkey");

            entity.ToTable("addresses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.IsPrimary).HasColumnName("is_primary");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .HasColumnName("street");

            entity.HasOne(d => d.Company).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("addresses_company_id_fkey");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("companies_pkey");

            entity.ToTable("companies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(100)
                .HasColumnName("registration_number");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<CompanyRelation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("company_relations_pkey");

            entity.ToTable("company_relations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LinkedCompanyId).HasColumnName("linked_company_id");
            entity.Property(e => e.RelationType)
                .HasMaxLength(100)
                .HasColumnName("relation_type");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyRelationCompanies)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("company_relations_company_id_fkey");

            entity.HasOne(d => d.LinkedCompany).WithMany(p => p.CompanyRelationLinkedCompanies)
                .HasForeignKey(d => d.LinkedCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("company_relations_linked_company_id_fkey");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transactions_pkey");

            entity.ToTable("transactions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(18, 2)
                .HasColumnName("amount");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .HasColumnName("currency");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");

            entity.HasOne(d => d.Company).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transactions_company_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
