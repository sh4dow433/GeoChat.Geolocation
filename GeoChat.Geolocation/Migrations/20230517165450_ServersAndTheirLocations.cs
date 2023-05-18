using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeoChat.Geolocation.Api.Migrations
{
    /// <inheritdoc />
    public partial class ServersAndTheirLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeoHashCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "GeoHashCode", "ServerId" },
                values: new object[,]
                {
                    { 1L, "u2ph8", 1L },
                    { 2L, "u2ph9", 1L },
                    { 3L, "u2phd", 1L },
                    { 4L, "u2phe", 1L },
                    { 5L, "u2phs", 1L },
                    { 6L, "u2pht", 1L },
                    { 7L, "u2ph2", 1L },
                    { 8L, "u2ph3", 1L },
                    { 9L, "u2ph6", 1L },
                    { 10L, "u2ph7", 1L },
                    { 11L, "u2phk", 1L },
                    { 12L, "u2phm", 1L },
                    { 13L, "u2ph0", 1L },
                    { 14L, "u2ph1", 1L },
                    { 15L, "u2ph4", 1L },
                    { 16L, "u2ph5", 1L },
                    { 17L, "u2phh", 1L },
                    { 18L, "u2phj", 1L },
                    { 19L, "sxfsb", 2L },
                    { 20L, "sxfsc", 2L },
                    { 21L, "sxfsf", 2L },
                    { 22L, "sxfsg", 2L },
                    { 23L, "sxfsu", 2L },
                    { 24L, "sxfs8", 2L },
                    { 25L, "sxfs9", 2L },
                    { 26L, "sxfsd", 2L },
                    { 27L, "sxfse", 2L },
                    { 28L, "sxfss", 2L },
                    { 29L, "sxfs2", 2L },
                    { 30L, "sxfs3", 2L },
                    { 31L, "sxfs6", 2L },
                    { 32L, "sxfs7", 2L },
                    { 33L, "sxfsk", 2L },
                    { 34L, "sxfxz", 2L },
                    { 35L, "sxfxx", 2L },
                    { 36L, "sxfmp", 2L },
                    { 37L, "sxft3", 2L },
                    { 38L, "sxft6", 2L },
                    { 39L, "sxft0", 2L },
                    { 40L, "sxft1", 2L },
                    { 41L, "sxft4", 2L },
                    { 42L, "sxft5", 2L },
                    { 43L, "sxfth", 2L },
                    { 44L, "u82f0", 3L },
                    { 45L, "u82f1", 3L },
                    { 46L, "u82f4", 3L },
                    { 47L, "u82f5", 3L },
                    { 48L, "u82fh", 3L },
                    { 49L, "u82fk", 3L },
                    { 50L, "u82cb", 3L },
                    { 51L, "u82cc", 3L },
                    { 52L, "u82cf", 3L },
                    { 53L, "u829u", 3L },
                    { 54L, "u829v", 3L },
                    { 55L, "u829y", 3L },
                    { 56L, "u829z", 3L },
                    { 57L, "u82dp", 3L }
                });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { -1L, "Default", "" },
                    { 1L, "Timis", "" },
                    { 2L, "Bucuresti", "" },
                    { 3L, "Cluj-Napoca", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
