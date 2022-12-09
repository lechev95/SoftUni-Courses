using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Infrastructure.Migrations
{
    public partial class SeedBooksLibrarians : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "concurrency_stamp", "password_hash", "security_stamp" },
                values: new object[] { "f656ef4d-3e39-4fba-a395-e22127a27bfd", "AQAAAAEAACcQAAAAEOZxyG3UEXluO7nvD2PdMMFCC8SH3stbWUHSuK+aMXRNSrkAxS8YokqvlB24z4vahA==", "94d38e04-5d4b-4ade-ab40-b9efee5938ce" });

            migrationBuilder.InsertData(
                table: "librarians",
                columns: new[] { "id", "phone_number", "user_id" },
                values: new object[] { 1, "+359888888888", "lib12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "id", "author_id", "date_received", "description", "genre_id", "image_url", "is_active", "isbn", "librarian_id", "price", "publisher", "quantity", "renter_id", "title" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/TheCapital-Marx.jpg", true, "9781234567897", 1, 8.00m, "Verlag von Otto Meisner", 3, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Капиталът" },
                    { 2, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/Emil-Lindgren.jpg", true, "9786192402723", 1, 9.90m, "Пан", 7, null, "Емил от Льонеберя" },
                    { 3, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "https://raw.githubusercontent.com/lechev95/SoftUni-Courses/main/C%23%20Web/LibraryManagementSystem-FinalWebProject/LibraryManagementSystem-FinalWebProject/wwwroot/Images/Bratyata-Lindgren.jpg", true, "9786192405922", 1, 14.90m, "Пан", 2, null, "Братята с лъвски сърца" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "librarians",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "concurrency_stamp", "password_hash", "security_stamp" },
                values: new object[] { "a8284f0c-b61e-4f97-bf17-acd8d98fcfee", "AQAAAAEAACcQAAAAELKikjZu7H2Q8r5VjjMCkoXCZjG4Uznq82+/Z+YozSzOgqukSEinAXAVVYN41ehshg==", "4f90bedb-7f21-4650-bc4e-42d13be101c6" });
        }
    }
}
