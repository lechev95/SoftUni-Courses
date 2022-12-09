﻿// <auto-generated />
using System;
using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagementSystem.Infrastructure.Data.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .HasColumnType("text")
                        .HasColumnName("biography");

                    b.Property<string>("Education")
                        .HasColumnType("text")
                        .HasColumnName("education");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.HasKey("Id")
                        .HasName("pk_authors");

                    b.ToTable("authors", (string)null);

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
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_received");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("image_url");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("isbn");

                    b.Property<int>("LibrarianId")
                        .HasColumnType("integer")
                        .HasColumnName("librarian_id");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("publisher");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<string>("RenterId")
                        .HasColumnType("text")
                        .HasColumnName("renter_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_books");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("ix_books_author_id");

                    b.HasIndex("GenreId")
                        .HasDatabaseName("ix_books_genre_id");

                    b.HasIndex("LibrarianId")
                        .HasDatabaseName("ix_books_librarian_id");

                    b.HasIndex("RenterId")
                        .HasDatabaseName("ix_books_renter_id");

                    b.ToTable("books", (string)null);

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
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("genre_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.HasKey("Id")
                        .HasName("pk_genres");

                    b.ToTable("genres", (string)null);

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
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("phone_number");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_librarians");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_librarians_user_id");

                    b.ToTable("librarians", (string)null);

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
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_role_claims_role_id");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f656ef4d-3e39-4fba-a395-e22127a27bfd",
                            Email = "client@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "client@mail.com",
                            NormalizedUserName = "client@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEOZxyG3UEXluO7nvD2PdMMFCC8SH3stbWUHSuK+aMXRNSrkAxS8YokqvlB24z4vahA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "94d38e04-5d4b-4ade-ab40-b9efee5938ce",
                            TwoFactorEnabled = false,
                            UserName = "client@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_claims_user_id");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_asp_net_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_logins_user_id");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_asp_net_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_user_roles_role_id");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_asp_net_user_tokens");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LibraryManagementSystem.Infrastructure.Data.Book", b =>
                {
                    b.HasOne("LibraryManagementSystem.Infrastructure.Data.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_books_authors_author_id");

                    b.HasOne("LibraryManagementSystem.Infrastructure.Data.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_books_genres_genre_id");

                    b.HasOne("LibraryManagementSystem.Infrastructure.Data.Librarian", "Librarian")
                        .WithMany()
                        .HasForeignKey("LibrarianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_books_librarians_librarian_id");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId")
                        .HasConstraintName("fk_books_users_renter_id");

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
                        .IsRequired()
                        .HasConstraintName("fk_librarians_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_role_claims_asp_net_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_claims_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_logins_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_roles_role_id");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_tokens_asp_net_users_user_id");
                });

            modelBuilder.Entity("LibraryManagementSystem.Infrastructure.Data.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
