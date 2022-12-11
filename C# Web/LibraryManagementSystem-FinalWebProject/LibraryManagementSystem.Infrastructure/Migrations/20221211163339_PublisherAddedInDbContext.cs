using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Infrastructure.Migrations
{
    public partial class PublisherAddedInDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher");

            migrationBuilder.RenameTable(
                name: "Publisher",
                newName: "Publishers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers");

            migrationBuilder.RenameTable(
                name: "Publishers",
                newName: "Publisher");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f282665-1bb3-46d7-853d-c9f8b7b647ac", "AQAAAAEAACcQAAAAEK1sRpwNRzvLQckXS70WTPWwBkDcnmt0uDSGl/pV9sUetB/C1soT+S3HygdO3Q60lA==", "51c15620-15ae-4423-b6fd-a0b1f99d90bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "lib12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73d4c3a5-4669-48ab-b753-5f81d491f852", "AQAAAAEAACcQAAAAEKwiJEFhZLdU9f6oqNkLtG7id0bD5FJr+0Gnm9SjJ20GHTFCp2NDES7ebakT83+q7A==", "e932049d-b8f1-42e0-9823-0928719ad1f5" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
