using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tekus.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefactorDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCountries_Services_CountryId",
                table: "ServiceCountries");

            migrationBuilder.AddColumn<string>(
                name: "Countries",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProviderCustomFields",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderCustomFields", x => new { x.ProviderId, x.FieldName });
                    table.ForeignKey(
                        name: "FK_ProviderCustomFields_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCountries_Services_ServiceId",
                table: "ServiceCountries",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCountries_Services_ServiceId",
                table: "ServiceCountries");

            migrationBuilder.DropTable(
                name: "ProviderCustomFields");

            migrationBuilder.DropColumn(
                name: "Countries",
                table: "Services");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCountries_Services_CountryId",
                table: "ServiceCountries",
                column: "CountryId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
