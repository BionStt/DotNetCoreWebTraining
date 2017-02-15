using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BethanyPieShop.Models;

namespace BethanyPieShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170215174142_AddingOrderForms")]
    partial class AddingOrderForms
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BethanyPieShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BethanyPieShop.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("OrderPlaced");

                    b.Property<decimal>("OrderTotal");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("State");

                    b.Property<string>("ZipCode");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BethanyPieShop.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("OrderId");

                    b.Property<int>("PieId");

                    b.Property<decimal>("Price");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PieId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BethanyPieShop.Models.Pie", b =>
                {
                    b.Property<int>("PieId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AllergyInformation");

                    b.Property<int>("CategoryId");

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("InStock");

                    b.Property<bool>("IsPieOfTheWeek");

                    b.Property<string>("LongDescription");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("ShortDescription");

                    b.HasKey("PieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Pies");
                });

            modelBuilder.Entity("BethanyPieShop.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int?>("PieId");

                    b.Property<string>("ShoppingCartId");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("PieId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("BethanyPieShop.Models.OrderDetail", b =>
                {
                    b.HasOne("BethanyPieShop.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BethanyPieShop.Models.Pie", "Pie")
                        .WithMany()
                        .HasForeignKey("PieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BethanyPieShop.Models.Pie", b =>
                {
                    b.HasOne("BethanyPieShop.Models.Category", "Category")
                        .WithMany("Pies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BethanyPieShop.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("BethanyPieShop.Models.Pie", "Pie")
                        .WithMany()
                        .HasForeignKey("PieId");
                });
        }
    }
}
