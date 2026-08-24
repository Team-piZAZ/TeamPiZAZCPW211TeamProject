using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamPiZAZCPW211TeamProject.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 101,
                column: "ReleaseYear",
                value: 2004);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 102,
                column: "ReleaseYear",
                value: 2016);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 104,
                column: "ReleaseYear",
                value: 2004);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 105,
                column: "ReleaseYear",
                value: 1999);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 106,
                column: "ReleaseYear",
                value: 1989);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 107,
                column: "ReleaseYear",
                value: 2023);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 108,
                column: "ReleaseYear",
                value: 2023);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 109,
                column: "ReleaseYear",
                value: 2017);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 110,
                column: "ReleaseYear",
                value: 1992);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 111,
                column: "ReleaseYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 112,
                column: "ReleaseYear",
                value: 2022);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 113,
                column: "ReleaseYear",
                value: 2021);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 101,
                column: "ReleaseYear",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 102,
                column: "ReleaseYear",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 104,
                column: "ReleaseYear",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 105,
                column: "ReleaseYear",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 106,
                column: "ReleaseYear",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 107,
                column: "ReleaseYear",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 108,
                column: "ReleaseYear",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 109,
                column: "ReleaseYear",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 110,
                column: "ReleaseYear",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 111,
                column: "ReleaseYear",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 112,
                column: "ReleaseYear",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 113,
                column: "ReleaseYear",
                value: 0);
        }
    }
}
