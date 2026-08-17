using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamPiZAZCPW211TeamProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewStudioSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 4, "A Japanese animation studio known for its detailed animation and character-driven stories.", "Kyoto Animation" },
                    { 5, "A Japanese animation studio known for its visually stunning anime adaptations.", "Ufotable" },
                    { 6, "A Japanese animation studio known for its mecha and science fiction anime.", "Sunrise" },
                    { 7, "A Japanese animation studio known for its creative and innovative approach to anime production.", "Wit Studio" },
                    { 8, "A Japanese animation studio known for its high-quality productions and attention to detail.", "Studio Deen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
