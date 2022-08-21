using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Data.Migrations
{
    public partial class ChangePlayerSquadProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "SquadNumber",
                table: "Players",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SquadNumber",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(byte),
                oldNullable: true);
        }
    }
}
