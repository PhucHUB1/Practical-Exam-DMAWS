using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practical_Exam_DMAWS.Models;

public partial class OrderSystemContext : DbContext
{
    public OrderSystemContext()
    {
    }

    public OrderSystemContext(DbContextOptions<OrderSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblItem> TblItems { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DGB56C6\\\\\\\\SQLEXPRESS,1433;Initial Catalog=OrderSystem;User ID=PHUC;Password=PHUC123;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__tblItem__727E83EBE9D0A42B");

            entity.ToTable("tblItem");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(12, 4)");
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__tblOrder__C3905BAF50BBD5E4");

            entity.ToTable("tblOrder");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.DeliveryTime).HasColumnType("datetime");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(50);
            entity.Property(e => e.OrderAddress).HasMaxLength(255);
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Item).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_tblOrder_tblItem");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
