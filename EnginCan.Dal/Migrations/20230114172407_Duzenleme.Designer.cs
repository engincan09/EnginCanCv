﻿// <auto-generated />
using System;
using EnginCan.Dal.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EnginCan.Dal.Migrations
{
    [DbContext(typeof(EnginCanContext))]
    [Migration("20230114172407_Duzenleme")]
    partial class Duzenleme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnginCan.Entity.Models.Abouts.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AltAciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("DataStatus")
                        .HasColumnType("int");

                    b.Property<short>("DeneyimSuresi")
                        .HasColumnType("smallint");

                    b.Property<string>("DogumTarih")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastUpdatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("MezuniyetDurum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OzetMetin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sehir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Yas")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("About");
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Skills.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("DataStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastUpdatedUserId")
                        .HasColumnType("int");

                    b.Property<short>("Oran")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Systems.Lookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("BooleanValue1")
                        .HasColumnType("bit");

                    b.Property<bool?>("BooleanValue2")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("DataStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastUpdatedUserId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupTypeId1")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LookupTypeId1");

                    b.HasIndex("ParentId");

                    b.ToTable("Lookup");
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Systems.LookupType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("LookupType");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            Name = "Cinsiyet"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Ülke"
                        },
                        new
                        {
                            Id = 10,
                            Name = "İl"
                        },
                        new
                        {
                            Id = 11,
                            Name = "İlçe"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Döviz"
                        });
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Systems.Page", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AllName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("AllRouterLink")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("HomeWidget")
                        .HasColumnType("bit");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("MenuShow")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.Property<short>("Order")
                        .HasColumnType("smallint");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("RouterLink")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("WidgetIcon")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Pages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AllName = "Yönetim Paneli",
                            AllRouterLink = "/yonetim",
                            HomeWidget = false,
                            MenuShow = true,
                            Name = "Yönetim Paneli",
                            Order = (short)0,
                            RouterLink = "/yonetim"
                        },
                        new
                        {
                            Id = 2,
                            AllName = "Yönetim Paneli / Ana Sayfa",
                            AllRouterLink = "/yonetim/ana-sayfa",
                            HomeWidget = false,
                            Icon = "fa fa-home",
                            MenuShow = true,
                            Name = "Ana Sayfa",
                            Order = (short)0,
                            ParentId = 1,
                            RouterLink = "/ana-sayfa"
                        },
                        new
                        {
                            Id = 3,
                            AllName = "Yönetim Paneli / İdari İşler",
                            AllRouterLink = "/yonetim/idari-isler",
                            HomeWidget = false,
                            Icon = "fa fa-copy",
                            MenuShow = true,
                            Name = "İdari İşler",
                            Order = (short)1,
                            ParentId = 1,
                            RouterLink = "/idari-isler"
                        },
                        new
                        {
                            Id = 4,
                            AllName = "Yönetim Paneli / İdari İşler/ Kullanıcı İşlemleri",
                            AllRouterLink = "/yonetim/idari-isler/kullanici-islemleri",
                            HomeWidget = false,
                            Icon = "fa fa-user",
                            MenuShow = true,
                            Name = "Kullanıcı İşlemleri",
                            Order = (short)1,
                            ParentId = 3,
                            RouterLink = "/kullanici-islemleri"
                        },
                        new
                        {
                            Id = 5,
                            AllName = "Yönetim Paneli / İdari İşler/ Kullanıcı İşlemleri / Tüm Kullanıcılar",
                            AllRouterLink = "/yonetim/idari-isler/kullanici-islemleri/tum-kullanicilar",
                            HomeWidget = false,
                            MenuShow = true,
                            Name = "Tüm Kullanıcılar",
                            Order = (short)0,
                            ParentId = 4,
                            RouterLink = "/tum-kullanicilar"
                        },
                        new
                        {
                            Id = 6,
                            AllName = "Yönetim Paneli / İdari İşler/ Kullanıcı İşlemleri / Yeni Kullanıcı",
                            AllRouterLink = "/yonetim/idari-isler/kullanici-islemleri/tum-kullanicilar/yeni-kullanici",
                            HomeWidget = false,
                            MenuShow = true,
                            Name = "Yeni Kullanıcı",
                            Order = (short)1,
                            ParentId = 4,
                            RouterLink = "/yeni-kullanici"
                        },
                        new
                        {
                            Id = 7,
                            AllName = "Yönetim Paneli / İdari İşler/ Personel İşlemleri",
                            AllRouterLink = "/yonetim/idari-isler/personel-islemleri",
                            HomeWidget = false,
                            Icon = "fa fa-users",
                            MenuShow = true,
                            Name = "Personel İşlemleri",
                            Order = (short)1,
                            ParentId = 3,
                            RouterLink = "/personel-islemleri"
                        },
                        new
                        {
                            Id = 8,
                            AllName = "Yönetim Paneli / İdari İşler/ Personel İşlemleri / Tüm Personeller",
                            AllRouterLink = "/yonetim/idari-isler/personel-islemleri/tum-personeller",
                            HomeWidget = false,
                            MenuShow = true,
                            Name = "Tüm Kullanıcılar",
                            Order = (short)0,
                            ParentId = 7,
                            RouterLink = "/tum-personeller"
                        },
                        new
                        {
                            Id = 9,
                            AllName = "Yönetim Paneli / İdari İşler/ Personel İşlemleri / Yeni Personel",
                            AllRouterLink = "/yonetim/idari-isler/personel-islemleri/yeni-personel",
                            HomeWidget = false,
                            MenuShow = true,
                            Name = "Yeni Kullanıcı",
                            Order = (short)1,
                            ParentId = 7,
                            RouterLink = "/yeni-personel"
                        },
                        new
                        {
                            Id = 10,
                            AllName = "Yönetim Paneli / İdari İşler / Organizasyon Kadro İşlemleri",
                            AllRouterLink = "/yonetim/idari-isler/organizasyon-kadro-islemleri",
                            HomeWidget = false,
                            Icon = "fa fa-sitemap",
                            MenuShow = true,
                            Name = "Organizasyon Kadro İşlemleri",
                            Order = (short)1,
                            ParentId = 3,
                            RouterLink = "/organizasyon-kadro-islemleri"
                        },
                        new
                        {
                            Id = 11,
                            AllName = "Yönetim Paneli / İdari İşler/ Organizasyon Kadro İşlemleri / Organizasyon Şeması",
                            AllRouterLink = "/yonetim/idari-isler/organizasyon-kadro-islemleri/organizasyon-semasi",
                            HomeWidget = false,
                            MenuShow = true,
                            Name = "Organizasyon Şeması",
                            Order = (short)1,
                            ParentId = 10,
                            RouterLink = "/organizasyon-semasi"
                        },
                        new
                        {
                            Id = 12,
                            AllName = "Yönetim Paneli / İdari İşler/ Organizasyon Kadro İşlemleri / Yeni Birim",
                            AllRouterLink = "/yonetim/idari-isler/organizasyon-kadro-islemleri/yeni-birim",
                            HomeWidget = false,
                            MenuShow = true,
                            Name = "Yeni Birim",
                            Order = (short)1,
                            ParentId = 10,
                            RouterLink = "/yeni-birim"
                        },
                        new
                        {
                            Id = 17,
                            AllName = "Yönetim Paneli / Hakkımda",
                            AllRouterLink = "/yonetim/hakkimda",
                            HomeWidget = false,
                            Icon = "fa fa-address-card",
                            MenuShow = true,
                            Name = "Hakkımda",
                            Order = (short)1,
                            ParentId = 1,
                            RouterLink = "/hakkimda"
                        },
                        new
                        {
                            Id = 18,
                            AllName = "Yönetim Paneli / Yetenekler",
                            AllRouterLink = "/yonetim/yetenekler",
                            HomeWidget = false,
                            Icon = "fa fa-list",
                            MenuShow = true,
                            Name = "Yetenekler",
                            Order = (short)1,
                            ParentId = 1,
                            RouterLink = "/yetenekler"
                        });
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Systems.PagePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("DataStatus")
                        .HasColumnType("int");

                    b.Property<bool>("Forbidden")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastUpdatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("PagePermissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 4,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 6,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 7,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 8,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 9,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 10,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 11,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 12,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 17,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 17,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 18,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedUserId = 1,
                            DataStatus = 2,
                            Forbidden = false,
                            PageId = 18,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Users.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("DataStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastUpdatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataStatus = 2,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("DataStatus")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastUpdatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataStatus = 2,
                            Email = "admin@mail.com",
                            FullName = "Yönetici Admin",
                            Name = "Yönetici",
                            Password = "9K7Cwg3Qw/8FR/S9VvrNdgl8znxhPagMZ4QrajV/3AQ=",
                            Surname = "Admin"
                        });
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Users.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("DataStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastUpdatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataStatus = 2,
                            RoleId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Users.UserSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LoginAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("RemoteIpAddress")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("RequestHeader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Systems.Lookup", b =>
                {
                    b.HasOne("EnginCan.Entity.Models.Systems.LookupType", "LookupType")
                        .WithMany("Lookup")
                        .HasForeignKey("LookupTypeId1");

                    b.HasOne("EnginCan.Entity.Models.Systems.Lookup", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Systems.Page", b =>
                {
                    b.HasOne("EnginCan.Entity.Models.Systems.Page", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Systems.PagePermission", b =>
                {
                    b.HasOne("EnginCan.Entity.Models.Systems.Page", "Page")
                        .WithMany("PagePermission")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnginCan.Entity.Models.Users.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("EnginCan.Entity.Models.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Users.UserRole", b =>
                {
                    b.HasOne("EnginCan.Entity.Models.Users.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnginCan.Entity.Models.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EnginCan.Entity.Models.Users.UserSession", b =>
                {
                    b.HasOne("EnginCan.Entity.Models.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
