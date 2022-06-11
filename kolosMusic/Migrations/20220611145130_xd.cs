using Microsoft.EntityFrameworkCore.Migrations;

namespace kolosMusic.Migrations
{
    public partial class xd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdAlbum",
                table: "Tracks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 2,
                column: "IdAlbum",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdAlbum",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 2,
                column: "IdAlbum",
                value: 1);
        }
    }
}
