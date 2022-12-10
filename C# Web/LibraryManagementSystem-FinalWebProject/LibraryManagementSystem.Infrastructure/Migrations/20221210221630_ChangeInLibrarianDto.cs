using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Infrastructure.Migrations
{
    public partial class ChangeInLibrarianDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Librarians",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d403db73-9eff-4e20-a857-655f27542968", "AQAAAAEAACcQAAAAEOKMfmc/MAcMd0NBqEiO6w5TxDSTs2pBBItMbRwcTy8GAura6kIUbNendDlawsdVqw==", "6077cb12-2efb-488f-86eb-4373e345dae0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "lib12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eda24ba0-41dc-4723-92d2-cb4d460c62ea", "AQAAAAEAACcQAAAAEL/9GnZCAVePrHXK4diwKti0CLBOYLo76Sr7Bslg79mB4WafopMnFkehr1+oIWBbJQ==", "ee063485-d2b9-4b81-8bcd-468d56100a19" });

            migrationBuilder.UpdateData(
                table: "Librarians",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Librarians");

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
    }
}
