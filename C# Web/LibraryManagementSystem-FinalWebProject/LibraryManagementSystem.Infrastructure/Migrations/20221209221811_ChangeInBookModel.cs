using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Infrastructure.Migrations
{
    public partial class ChangeInBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d070cc2e-00d5-4916-92ad-bd06f87cb42b", "AQAAAAEAACcQAAAAECZP5vc/QwiDmlE2v2QmDmS7vqYT/XdZNvA8n4OuybcKpLVYmzDvF7cU6BkPaXVSQg==", "26e97a3a-24ca-4324-8ac7-d854ab5f6b05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "lib12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c53db3dd-678f-4fe4-add7-9dd4299da2a3", "AQAAAAEAACcQAAAAEHuN5HMG29Cz+vC3u8XhNwpQwlZsT7BUFmmvUNcXFVMinH+6PNW8zJARZtLbb0gx7g==", "dd946518-c61d-49e9-ac80-16861ea67026" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "121cc3bd-0131-4001-ae97-cff6bc1eb7d8", "AQAAAAEAACcQAAAAELig/Wv/l98hQ44maCdKN60v/oQ5DLSQLTGqQ7rACimTj4GGH3/3cZK1Mzt9vdGcdQ==", "178853c3-e882-4452-be0f-2f00ab6f2dd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "lib12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47799250-b045-48ef-a789-9b7de482e523", "AQAAAAEAACcQAAAAEObw3wVApx4HNdy27MlZBAMwxRSqHCj6AvEpdH0gthKKl0m4diqWNPgOTf2+023S3A==", "03f4c33c-59ba-4fda-b89b-ca483c25f052" });
        }
    }
}
