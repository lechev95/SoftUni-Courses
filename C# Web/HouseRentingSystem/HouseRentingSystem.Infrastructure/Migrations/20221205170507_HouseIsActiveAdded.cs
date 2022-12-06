using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class HouseIsActiveAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16f2651e-43b4-4220-abb6-d17e7e76ec8b", "AQAAAAEAACcQAAAAEFw7VDt0PwLt9PjrKLx2gzrucQP87942Bf802LuqEgw/73rThraOOCJhbqcj2DpqyQ==", "3aa8e138-d52c-49d2-bcb5-96ec0866f2aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b63ee8fd-daab-44c9-b8f6-70715bb072c2", "AQAAAAEAACcQAAAAEO7e2cB/MYkaVnz7RgVKqgPW4Gk7M5gyNhTyVBMo9iFSlhqeXabiOuctgNQKMTgGXw==", "f8573419-b397-4e51-9f5f-786261ea28c3" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04950b96-a77a-4aa6-8d13-2f40844ebbce", "AQAAAAEAACcQAAAAEEEphbYnmYcnnH2cmxkFwZCFmjkm6cf9i5E/SxhP/u2jj0ywxnE04rQLWYwnynjIkA==", "e8d52ecc-c3c4-4e77-9113-f7a10f13452b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0374e994-acba-44d1-a92b-a863a49077ad", "AQAAAAEAACcQAAAAEL7lSMO2ngft6y5I9yUSmhO6PzprEsRq9+b9/qN1OlBqM9sHfWLmJ5Qz/U0fAUGBhA==", "ae6f95df-637a-4924-a7b2-e18e3d1bd43c" });
        }
    }
}
