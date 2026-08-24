using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamPiZAZCPW211TeamProject.Migrations
{
    /// <inheritdoc />
    public partial class AnimeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "Episodes", "PublicationYear", "ReleaseYear", "StudioId", "Synopsis", "Title", "TvRating" },
                values: new object[,]
                {
                    { 102, 63, 2016, 0, 5, "Set in Taisho Era Japan, the story follows a boy, Tanjiro Kamado,\r\nwho's family is massacred by a demon which sets him on the\r\npath for revenge. Eventually, he meets an organization called the\r\nDemon Slayer Corp who help him in this adventure.", "Demon Slayer", "TV-14" },
                    { 108, 38, 2023, 0, 2, "Fantasy anime series that follows Frieren, an immortal elf mage.\r\nIt uniquely begins after her party defeats the Demon King,\r\nexploring her emotional journey to understand human mortality\r\nand connections decades later with her new party.", "Frieren: Beyond Journey's End", "TV-14" },
                    { 109, 24, 2017, 0, 3, "Fantasy anime series that follows Chise Hatori, a young girl\r\nsold at an auction to a mysterious non-human mage named Elias\r\nAinsworth. The story explores their relationship and Chise's\r\njourney of self-discovery in a world of magic and mythical creatures.", "The Ancient Magus' Bride", "TV-14" },
                    { 111, 13, 2025, 0, null, "Follows a noble woman, Scarlet El Vandimion, who's received\r\nUnflattering nicknames due to her love for a good beatdown on\r\nunjustly nobles. Scarlet is also on mission with the Prince, Julius,\r\nto bring down corrupt nobility and religious institutions.", "May I Ask For One Final Thing", "TV-MA" },
                    { 112, 12, 2022, 0, null, "Fantasy anime series that follows Menou, a skilled executioner\r\nwho is tasked with eliminating individuals summoned from\r\nanother world. The story explores themes of morality, justice,\r\nand the consequences of wielding power in a fantastical setting.", "The Executioner and Her Way of Life", "TV-14" },
                    { 113, 12, 2021, 0, null, "Fantasy anime series that follows Lugh Tuatha De, a skilled\r\nassassin who is reincarnated into a parallel world. Tasked with\r\npreventing the rise of a destructive hero, Lugh must navigate\r\npolitical intrigue and moral dilemmas to fulfill his mission.", "The World's Finest Assassin", "TV-14" }
                });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 9, "A Japanese animation studio known for its long-running anime series and adaptations of popular manga.", "Pierrot" },
                    { 10, "A Japanese animation studio known for its iconic anime series and films.", "OLM" },
                    { 11, "A Japanese animation studio known for its long-running anime series and adaptations of popular manga.", "Toei Animation" }
                });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "Episodes", "PublicationYear", "ReleaseYear", "StudioId", "Synopsis", "Title", "TvRating" },
                values: new object[,]
                {
                    { 101, 366, 2004, 0, 9, "Bleach follows Ichigo Kurosaki, a teenager who can see ghosts,\r\nand Rukia Kuchiki, a Soul Reaper (Shinigami). After Rukia\r\nshares her powers with Ichigo to save his family, he must protect\r\nhumans from evil spirits called Hollows and guide lost souls.", "Bleach", "TV-14" },
                    { 103, 1300, 1997, 0, 10, "Humans known as 'Trainers' catch, train, and battle creatures\r\nknown as Pokémon. The trainers and they're Pokémon not only\r\nshare a special bond in battle, but also a deep friendship.", "Pokemon", "TV-PG" },
                    { 104, 1170, 2004, 0, 11, "Monkey D. Luffy dreams of becoming the Pirate King by finding\r\nthe legendary \"One Piece\" treasure left behind by Gol D. Roger.\r\nAfter accidentally eating a magical Gum-Gum Devil Fruit, Luffy\r\ngained the ability to stretch like rubber. He sets sail, assembling a\r\nloyal and eccentric crew, to conquer the perilous Grand Line.", "One Piece", "TV-14" },
                    { 105, 220, 1999, 0, 9, "Focus' on the struggle of a young ninja in the Hidden Leaf Village,\r\nNaruto Uzumaki. He faces many dangers with his companions\r\nSasuke Uchiha and Sakura Haruno, including other ninja and\r\nother villages.", "Naruto", "TV-PG" },
                    { 106, 291, 1989, 0, 11, "Follows a hero named Goku and his friends who together, these\r\nfighters defend Earth from powerful space aliens, killer robots,\r\nand magic monsters through intense martial arts battles.", "Dragon Ball", "TV-PG" },
                    { 107, 48, 2023, 0, 10, "Historical mystery anime following Maomao, a young apothecary\r\nsold into palace servitude, who solves medical and court\r\nmysteries using her vast knowledge of poisons and herbs.", "Apothecary Diaries", "TV-14" },
                    { 110, 200, 1992, 0, 11, "Following Usagi Tsukino, a clumsy, average teenager who\r\ndiscovers she is the reincarnation of a Moon Kingdom princess.\r\nGuided by a talking cat named Luna, she transforms into the\r\nmagical guardian \"Sailor Moon\" to fight dark forces and protect\r\nEarth alongside a team of fellow Sailor Guardians.", "Sailor Moon", "TV-PG" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
