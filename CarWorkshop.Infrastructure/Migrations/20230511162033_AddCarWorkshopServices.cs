using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarWorkshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCarWorkshopServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarWorkshopServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<string>(type: "text", nullable: false),
                    CarWorkshopId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarWorkshopServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarWorkshopServices_CarWorkshops_CarWorkshopId",
                        column: x => x.CarWorkshopId,
                        principalTable: "CarWorkshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarWorkshopServices_CarWorkshopId",
                table: "CarWorkshopServices",
                column: "CarWorkshopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarWorkshopServices");
        }
    }
}
