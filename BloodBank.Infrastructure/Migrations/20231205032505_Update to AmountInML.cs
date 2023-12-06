using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatetoAmountInML : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MlAmount",
                table: "Donations",
                newName: "AmountInML");

            migrationBuilder.RenameColumn(
                name: "MlAmount",
                table: "BloodStorage",
                newName: "AmountInML");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountInML",
                table: "Donations",
                newName: "MlAmount");

            migrationBuilder.RenameColumn(
                name: "AmountInML",
                table: "BloodStorage",
                newName: "MlAmount");
        }
    }
}
