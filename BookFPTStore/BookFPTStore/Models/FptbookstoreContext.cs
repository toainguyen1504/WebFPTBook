using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookFPTStore.Models;

namespace BookFPTStore.Models;

public partial class FptbookstoreContext : IdentityDbContext<AppUserModel>
{
    internal object TbCategory;

    public FptbookstoreContext()
    {
    }

    public FptbookstoreContext(DbContextOptions<FptbookstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAuthor> TbAuthors { get; set; }

    public virtual DbSet<TbBook> TbBooks { get; set; }

    public virtual DbSet<TbCart> TbCarts { get; set; }

    public virtual DbSet<TbCartDetail> TbCartDetails { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }
    public object Category { get; internal set; }
    public IEnumerable Categories { get; internal set; }
	public List<TbAuthor> Authors { get; internal set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<TbAuthor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Autho__3213E83F22229D0B");

            entity.ToTable("tb_Author");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TbBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Book__3213E83F54F2248B");

            entity.ToTable("tb_Book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("authorId");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .HasColumnName("description");
            entity.Property(e => e.Detail).HasColumnName("detail");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .HasColumnName("image");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PriceSale)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("priceSale");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.TbBooks)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_authorId");

            entity.HasOne(d => d.Category).WithMany(p => p.TbBooks)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_categoryId");
        });

        modelBuilder.Entity<TbCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Cart__3213E83F2983534D");

            entity.ToTable("tb_Cart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(150)
                .HasColumnName("customerName");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalAmount");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.TbCarts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_userId");
        });

        modelBuilder.Entity<TbCartDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_CartD__3213E83F9E05FBF8");

            entity.ToTable("tb_CartDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("bookId");
            entity.Property(e => e.CartId).HasColumnName("cartId");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Book).WithMany(p => p.TbCartDetails)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_bookId");

            entity.HasOne(d => d.Cart).WithMany(p => p.TbCartDetails)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK_cartId");
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Categ__3213E83F480BC412");

            entity.ToTable("tb_Category");

            entity.HasIndex(e => e.Title, "UQ__tb_Categ__E52A1BB340AE81DE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_User__3213E83F3E5B3C62");

            entity.ToTable("tb_User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(320)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(30)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(15)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);

        base.OnModelCreating(modelBuilder);

        // Cấu hình khóa chính cho IdentityUserLogin<string>
        modelBuilder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
