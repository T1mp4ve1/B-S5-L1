using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class initialmigrationa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorS",
                columns: table => new
                {
                    AuthorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pseudonym = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorS", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "GenreS",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreS", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "BookS",
                columns: table => new
                {
                    BookID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoverIMG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookS", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_BookS_AuthorS_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "AuthorS",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookS_GenreS_GenreID",
                        column: x => x.GenreID,
                        principalTable: "GenreS",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookS_AuthorID",
                table: "BookS",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_BookS_GenreID",
                table: "BookS",
                column: "GenreID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookS");

            migrationBuilder.DropTable(
                name: "AuthorS");

            migrationBuilder.DropTable(
                name: "GenreS");
        }
    }
}
