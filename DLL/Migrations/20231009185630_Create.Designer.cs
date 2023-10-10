﻿// <auto-generated />
using System;
using DLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DLL.Migrations
{
    [DbContext(typeof(Store_Identity_APIContext))]
    [Migration("20231009185630_Create")]
    partial class Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DLL.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "HP",
                            Photo = "https://fixcenter.com.ua/content/uploads/images/serveryhp.png"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dell",
                            Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/Dell_logo_2016.svg/200px-Dell_logo_2016.svg.png"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Samsung",
                            Photo = "https://upload.wikimedia.org/wikipedia/uk/thumb/2/24/Samsung_Logo.svg/1280px-Samsung_Logo.svg.png"
                        });
                });

            modelBuilder.Entity("DLL.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("DLL.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Laptops",
                            Photo = "https://www.notebookcheck-ru.com/uploads/tx_nbc2/MicrosoftSurfaceLaptop3-15__1__02.JPG"
                        },
                        new
                        {
                            Id = 1,
                            Name = "MFU",
                            Photo = "https://images.prom.ua/3060125370_w640_h640_mfu-lazernoe-xerox.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Displays",
                            Photo = "https://www.lg.com/in/images/monitors/md07543925/gallery/27MP400-B-D-01.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Speakers",
                            Photo = "https://shop.sven.ua/image/cache/catalog/products-sven/acoustic_plast/sven_445_01-1200x800.png"
                        });
                });

            modelBuilder.Entity("DLL.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("OldPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CategoryId = 2,
                            Count = 0,
                            Name = "L1",
                            Photo = "https://klike.net/uploads/posts/2020-04/1586244741_1.jpg",
                            Price = 22200m
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            CategoryId = 2,
                            Count = 8,
                            Name = "L2",
                            Photo = "https://klike.net/uploads/posts/2020-04/1586244779_2.jpg",
                            Price = 34400m
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            CategoryId = 2,
                            Count = 3,
                            Name = "L3",
                            Photo = "https://klike.net/uploads/posts/2020-04/1586244761_4.jpg",
                            Price = 12200m
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            CategoryId = 2,
                            Count = 1,
                            Name = "L4",
                            Photo = "https://klike.net/uploads/posts/2020-04/1586244770_7.jpg",
                            Price = 15600m
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 1,
                            CategoryId = 1,
                            Count = 3,
                            Name = "P4",
                            Photo = "https://tech-choice.net/wp-content/uploads/2019/09/mfu-dlja-pechati-foto-620x330.jpg",
                            Price = 15600m
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 3,
                            CategoryId = 1,
                            Count = 8,
                            Name = "P4",
                            Photo = "https://cdn.27.ua/799/1f/3c/7996_2.jpeg",
                            Price = 15600m
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 2,
                            CategoryId = 1,
                            Count = 3,
                            Name = "P4",
                            Photo = "https://images.prom.ua/2937801366_mfu-a4-epson.jpg",
                            Price = 15600m
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 1,
                            CategoryId = 1,
                            Count = 5,
                            Name = "P4",
                            Photo = "https://images.prom.ua/2800565290_w640_h640_polnoe-reshenie-mfu.jpg",
                            Price = 15600m
                        },
                        new
                        {
                            Id = 9,
                            BrandId = 1,
                            CategoryId = 3,
                            Count = 3,
                            Name = "D1",
                            Photo = "https://img.freepik.com/free-photo/computer_1205-717.jpg?1",
                            Price = 4560m
                        },
                        new
                        {
                            Id = 10,
                            BrandId = 2,
                            CategoryId = 3,
                            Count = 1,
                            Name = "D2",
                            Photo = "https://cdn.fotosklad.ru/unsafe/73e5a00a41ff440c925b9b1a460df709/image.jpg",
                            Price = 4860m
                        },
                        new
                        {
                            Id = 11,
                            BrandId = 3,
                            CategoryId = 3,
                            Count = 2,
                            Name = "D3",
                            Photo = "https://st.depositphotos.com/1035837/1386/i/600/depositphotos_13861529-stock-photo-monitor.jpg",
                            Price = 4960m
                        },
                        new
                        {
                            Id = 12,
                            BrandId = 1,
                            CategoryId = 3,
                            Count = 3,
                            Name = "D4",
                            Photo = "https://images.unian.net/photos/2022_07/thumb_files/400_0_1656777669-2895.jpg?r=799803",
                            Price = 4560m
                        },
                        new
                        {
                            Id = 13,
                            BrandId = 1,
                            CategoryId = 4,
                            Count = 3,
                            Name = "S4",
                            Photo = "https://st2.depositphotos.com/1001877/5970/i/950/depositphotos_59701653-stock-photo-group-of-audio-speakers-loudspeakers.jpg",
                            Price = 560m
                        },
                        new
                        {
                            Id = 14,
                            BrandId = 2,
                            CategoryId = 4,
                            Count = 5,
                            Name = "S4",
                            Photo = "https://assets.simant.com.ua/images/products/bigest/2559.jpg",
                            Price = 230m
                        },
                        new
                        {
                            Id = 15,
                            BrandId = 3,
                            CategoryId = 4,
                            Count = 2,
                            Name = "S4",
                            Photo = "https://assets.simant.com.ua/images/products/bigest/2668.jpg",
                            Price = 660m
                        },
                        new
                        {
                            Id = 16,
                            BrandId = 3,
                            CategoryId = 4,
                            Count = 1,
                            Name = "S4",
                            Photo = "https://assets.simant.com.ua/images/products/bigest/2614.jpg",
                            Price = 860m
                        });
                });

            modelBuilder.Entity("DLL.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DLL.Models.Card", b =>
                {
                    b.HasOne("DLL.Models.Product", "Product")
                        .WithMany("Cards")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DLL.Models.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DLL.Models.Product", b =>
                {
                    b.HasOne("DLL.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DLL.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DLL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DLL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DLL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DLL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DLL.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DLL.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DLL.Models.Product", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("DLL.Models.User", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
