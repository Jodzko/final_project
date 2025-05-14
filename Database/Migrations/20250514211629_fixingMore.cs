using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _final_project.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixingMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_People_PersonId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Addresses",
                newName: "PersonalCode");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_PersonId",
                table: "Addresses",
                newName: "IX_Addresses_PersonalCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_People_PersonalCode",
                table: "Addresses",
                column: "PersonalCode",
                principalTable: "People",
                principalColumn: "PersonalCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_People_PersonalCode",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "PersonalCode",
                table: "Addresses",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_PersonalCode",
                table: "Addresses",
                newName: "IX_Addresses_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_People_PersonId",
                table: "Addresses",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonalCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
