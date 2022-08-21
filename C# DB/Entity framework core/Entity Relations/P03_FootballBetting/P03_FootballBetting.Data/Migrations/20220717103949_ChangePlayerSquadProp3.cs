using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Data.Migrations
{
    public partial class ChangePlayerSquadProp3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "SquadNumber",
                table: "Players",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SquadNumber",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte));
        }
    }
}
