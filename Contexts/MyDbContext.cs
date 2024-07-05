using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using _DotNETCore_7_ADO_Sp_.Models;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _DotNETCore_7_ADO_Sp_.Contexts;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Visitor> Visitors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //this should be empty
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Visitor__3214EC07B1DB67B3");

            entity.ToTable("Visitor");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RegisterAt).HasColumnType("datetime");
            entity.Property(e => e.DepartAt).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
