using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolosMusic.Migrations
{
    public partial class lol3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musciains",
                columns: table => new
                {
                    IdMusician = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Musiciahn_pk", x => x.IdMusician);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabels",
                columns: table => new
                {
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MusicLabel_pk", x => x.IdMusicLabel);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Album_pk", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "IdMusicLabel_fk",
                        column: x => x.IdMusicLabel,
                        principalTable: "MusicLabels",
                        principalColumn: "IdMusicLabel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    IdTrack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Track_pk", x => x.IdTrack);
                    table.ForeignKey(
                        name: "trac_Album",
                        column: x => x.IdAlbum,
                        principalTable: "Albums",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicianTracks",
                columns: table => new
                {
                    IdTrack = table.Column<int>(type: "int", nullable: false),
                    IdMusician = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MusicianTrack_pk", x => new { x.IdMusician, x.IdTrack });
                    table.ForeignKey(
                        name: "MusicianTrack_Musician",
                        column: x => x.IdMusician,
                        principalTable: "Musciains",
                        principalColumn: "IdMusician",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "MusicianTrack_Track",
                        column: x => x.IdTrack,
                        principalTable: "Tracks",
                        principalColumn: "IdTrack",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Musciains",
                columns: new[] { "IdMusician", "FirstName", "LastName", "Nickname" },
                values: new object[] { 1, "Kuba", "Nowak", "Xd" });

            migrationBuilder.InsertData(
                table: "MusicLabels",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[] { 1, "Asd" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[] { 1, "Name", 1, new DateTime(1999, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "IdTrack", "Duration", "IdAlbum", "TrackName" },
                values: new object[] { 1, 1.1f, 1, "Name" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "IdTrack", "Duration", "IdAlbum", "TrackName" },
                values: new object[] { 2, 1.9f, 1, "Name" });

            migrationBuilder.InsertData(
                table: "MusicianTracks",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_IdMusicLabel",
                table: "Albums",
                column: "IdMusicLabel");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianTracks_IdTrack",
                table: "MusicianTracks",
                column: "IdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_IdAlbum",
                table: "Tracks",
                column: "IdAlbum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicianTracks");

            migrationBuilder.DropTable(
                name: "Musciains");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "MusicLabels");
        }
    }
}
