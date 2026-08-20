using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamPiZAZCPW211TeamProject.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Animes");

            migrationBuilder.AddColumn<int>(
                name: "Episodes",
                table: "Animes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublicationYear",
                table: "Animes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TvRating",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Episodes",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "PublicationYear",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "TvRating",
                table: "Animes");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Animes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
