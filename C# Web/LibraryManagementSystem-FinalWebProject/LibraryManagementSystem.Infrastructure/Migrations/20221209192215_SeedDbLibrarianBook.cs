using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Infrastructure.Migrations
{
    public partial class SeedDbLibrarianBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "121cc3bd-0131-4001-ae97-cff6bc1eb7d8", "AQAAAAEAACcQAAAAELig/Wv/l98hQ44maCdKN60v/oQ5DLSQLTGqQ7rACimTj4GGH3/3cZK1Mzt9vdGcdQ==", "178853c3-e882-4452-be0f-2f00ab6f2dd2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "lib12856-c198-4129-b3f3-b893d8395082", 0, "47799250-b045-48ef-a789-9b7de482e523", "librarian@mail.com", false, false, null, "librarian@mail.com", "librarian@mail.com", "AQAAAAEAACcQAAAAEObw3wVApx4HNdy27MlZBAMwxRSqHCj6AvEpdH0gthKKl0m4diqWNPgOTf2+023S3A==", null, false, "03f4c33c-59ba-4fda-b89b-ca483c25f052", false, "librarian@mail.com" });

            migrationBuilder.InsertData(
                table: "Librarians",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "lib12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "DateReceived", "Description", "GenreId", "ImageUrl", "IsActive", "Isbn", "LibrarianId", "Price", "Publisher", "Quantity", "RenterId", "Title" },
                values: new object[] { 1, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/TheCapital-Marx.jpg", true, "9781234567897", 1, 8.00m, "Verlag von Otto Meisner", 3, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Капиталът" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "DateReceived", "Description", "GenreId", "ImageUrl", "IsActive", "Isbn", "LibrarianId", "Price", "Publisher", "Quantity", "RenterId", "Title" },
                values: new object[] { 2, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/Emil-Lindgren.jpg", true, "9786192402723", 1, 9.90m, "Пан", 7, null, "Емил от Льонеберя" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "DateReceived", "Description", "GenreId", "ImageUrl", "IsActive", "Isbn", "LibrarianId", "Price", "Publisher", "Quantity", "RenterId", "Title" },
                values: new object[] { 3, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/Bratyata-Lindgren.jpg", true, "9786192405922", 1, 14.90m, "Пан", 2, null, "Братята с лъвски сърца" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "lib12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd61ca53-a9c2-4eb1-ad83-9b32aa544ac6", "AQAAAAEAACcQAAAAEJ4vjF5PslRAZWTzKUxt4MjRP0z0973XWua1utjoUlzHxMGMlXEvk1pHavpsH2ptxg==", "e984d2ea-6f2c-49c7-a484-d3abfa7810dc" });
        }
    }
}
