﻿// <auto-generated />
using System;
using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryManagementSystem.Infrastructure.Data.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Айзък",
                            IsActive = true,
                            LastName = "Азимов"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Роалд",
                            IsActive = true,
                            LastName = "Дал"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Роджър",
                            IsActive = true,
                            LastName = "Зелазни"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Ерих",
                            IsActive = true,
                            LastName = "Кестнер"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Астрид",
                            IsActive = true,
                            LastName = "Линдгрен"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Карл",
                            IsActive = true,
                            LastName = "Маркс"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Айн",
                            IsActive = true,
                            LastName = "Ранд"
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "Николай",
                            IsActive = true,
                            LastName = "Теллалов"
                        },
                        new
                        {
                            Id = 9,
                            FirstName = "Зигмунд",
                            IsActive = true,
                            LastName = "Фройд"
                        },
                        new
                        {
                            Id = 10,
                            FirstName = "Ерих",
                            IsActive = true,
                            LastName = "Фром"
                        },
                        new
                        {
                            Id = 11,
                            FirstName = "Робърт",
                            IsActive = true,
                            LastName = "Шекли"
                        },
                        new
                        {
                            Id = 12,
                            FirstName = "Карл",
                            IsActive = true,
                            LastName = "Юнг"
                        },
                        new
                        {
                            Id = 13,
                            FirstName = "Туве",
                            IsActive = true,
                            LastName = "Янсон"
                        },
                        new
                        {
                            Id = 14,
                            FirstName = "Светлин",
                            IsActive = true,
                            LastName = "Наков"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Infrastructure.Data.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LibrarianId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("money");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("LibrarianId");

                    b.HasIndex("RenterId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 6,
                            DateReceived = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 10,
                            ImageUrl = "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/TheCapital-Marx.jpg",
                            IsActive = true,
                            Isbn = "9781234567897",
                            LibrarianId = 1,
                            Price = 8.00m,
                            Publisher = "Verlag von Otto Meisner",
                            Quantity = 3,
                            RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Title = "Капиталът"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 5,
                            DateReceived = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 2,
                            ImageUrl = "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/Emil-Lindgren.jpg",
                            IsActive = true,
                            Isbn = "9786192402723",
                            LibrarianId = 1,
                            Price = 9.90m,
                            Publisher = "Пан",
                            Quantity = 7,
                            Title = "Емил от Льонеберя"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 5,
                            DateReceived = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 2,
                            ImageUrl = "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/Bratyata-Lindgren.jpg",
                            IsActive = true,
                            Isbn = "9786192405922",
                            LibrarianId = 1,
                            Price = 14.90m,
                            Publisher = "Пан",
                            Quantity = 2,
                            Title = "Братята с лъвски сърца"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Infrastructure.Data.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreName = "Алманаси",
                            IsActive = true
                        },
                        new
                        {
                            Id = 2,
                            GenreName = "Детски книги",
                            IsActive = true
                        },
                        new
                        {
                            Id = 3,
                            GenreName = "Документални книги",
                            IsActive = true
                        },
                        new
                        {
                            Id = 4,
                            GenreName = "Енциклопедии",
                            IsActive = true
                        },
                        new
                        {
                            Id = 5,
                            GenreName = "Исторически хроники",
                            IsActive = true
                        },
                        new
                        {
                            Id = 6,
                            GenreName = "Книги за антиутопия",
                            IsActive = true
                        },
                        new
                        {
                            Id = 7,
                            GenreName = "Криминална литература",
                            IsActive = true
                        },
                        new
                        {
                            Id = 8,
                            GenreName = "Научни книги",
                            IsActive = true
                        },
                        new
                        {
                            Id = 9,
                            GenreName = "Научнофантастични книги",
                            IsActive = true
                        },
                        new
                        {
                            Id = 10,
                            GenreName = "Политическа литература",
                            IsActive = true
                        },
                        new
                        {
                            Id = 11,
                            GenreName = "Религиозна литература",
                            IsActive = true
                        },
                        new
                        {
                            Id = 12,
                            GenreName = "Ръкописи",
                            IsActive = true
                        },
                        new
                        {
                            Id = 13,
                            GenreName = "Сатирични книги",
                            IsActive = true
                        },
                        new
                        {
                            Id = 14,
                            GenreName = "Сборници",
                            IsActive = true
                        },
                        new
                        {
                            Id = 15,
                            GenreName = "Стихосбирки",
                            IsActive = true
                        },
                        new
                        {
                            Id = 16,
                            GenreName = "Учебници",
                            IsActive = true
                        },
                        new
                        {
                            Id = 17,
                            GenreName = "Фентъзи книги",
                            IsActive = true
                        },
                        new
                        {
                            Id = 18,
                            GenreName = "Художествена литература",
                            IsActive = true
                        },
                        new
                        {
                            Id = 19,
                            GenreName = "Шпионски романи",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Infrastructure.Data.Librarian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Librarians");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhoneNumber = "+359888888888",
                            UserId = "lib12856-c198-4129-b3f3-b893d8395082"
                        });
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.HasData(
                        new
                        {
                            Id = "lib12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "47799250-b045-48ef-a789-9b7de482e523",
                            Email = "librarian@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "librarian@mail.com",
                            NormalizedUserName = "librarian@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEObw3wVApx4HNdy27MlZBAMwxRSqHCj6AvEpdH0gthKKl0m4diqWNPgOTf2+023S3A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "03f4c33c-59ba-4fda-b89b-ca483c25f052",
                            TwoFactorEnabled = false,
                            UserName = "librarian@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "121cc3bd-0131-4001-ae97-cff6bc1eb7d8",
                            Email = "client@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "client@mail.com",
                            NormalizedUserName = "client@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAELig/Wv/l98hQ44maCdKN60v/oQ5DLSQLTGqQ7rACimTj4GGH3/3cZK1Mzt9vdGcdQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "178853c3-e882-4452-be0f-2f00ab6f2dd2",
                            TwoFactorEnabled = false,
                            UserName = "client@mail.com"
                        });
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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LibraryManagementSystem.Infrastructure.Data.Book", b =>
                {
                    b.HasOne("LibraryManagementSystem.Infrastructure.Data.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Infrastructure.Data.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Infrastructure.Data.Librarian", "Librarian")
                        .WithMany()
                        .HasForeignKey("LibrarianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId");

                    b.Navigation("Author");

                    b.Navigation("Genre");

                    b.Navigation("Librarian");

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("LibraryManagementSystem.Infrastructure.Data.Librarian", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryManagementSystem.Infrastructure.Data.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
