using Microsoft.EntityFrameworkCore.Migrations;

namespace kolosMusic.Migrations
{
    public partial class twojastara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrackName",
                table: "Tracks",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 1,
                column: "TrackName",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrackName",
                table: "Tracks",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 1,
                column: "TrackName",
                value: "Name");
        }
    }
}
