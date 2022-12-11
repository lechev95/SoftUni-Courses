using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Infrastructure.Migrations
{
    public partial class PublisherAddedInDbContext2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "944cf118-64d2-4eb5-9570-988c37b226a5", "AQAAAAEAACcQAAAAEP70doCVEHPZ5p4LPpEEUb9R1iprkyz2uK1kLtzCO+twGqFMapP8ZXuxi2NNOJqplw==", "873dc283-4aa5-4642-8901-51058715b49d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "lib12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69190de3-beb9-42fb-a1bf-b819a3b105c5", "AQAAAAEAACcQAAAAEI7ANKy8p2qhnejKOlCHkMZL+OSqF42PTdabWhM4+8Zb/iZyD/f+S63wi3Z1lBYmmA==", "056022b8-1189-48b3-b92e-2aba3eb4416c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11390a59-87f2-4a1c-9941-8f17bb662b21", "AQAAAAEAACcQAAAAEPQZw2eZDn8xGQaoucqPo23t/g7ta86LGc3SFN2456nD3F0Jt8T2vYrBBLZKk5ShHw==", "e3cbaeec-433e-4eec-93d0-13707b1b1b34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "lib12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddb2155c-2168-4286-8c56-0b30262b1120", "AQAAAAEAACcQAAAAELAnwNjPvVuVHnh9d2opQpRV9CNtvXRGWTK1GqQUvwaJIIvWgiAJ5iwHu1zgN9pxyA==", "1aa248d0-cb98-474c-b88b-b800673b1995" });
        }
    }
}
