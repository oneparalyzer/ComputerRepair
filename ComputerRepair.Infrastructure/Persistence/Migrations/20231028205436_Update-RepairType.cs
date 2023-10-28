using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerRepair.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRepairType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_Offices_OfficeId",
                table: "RepairTypes");

            migrationBuilder.DropIndex(
                name: "IX_RepairTypes_OfficeId",
                table: "RepairTypes");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "RepairTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                table: "RepairTypes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RepairTypes_OfficeId",
                table: "RepairTypes",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_Offices_OfficeId",
                table: "RepairTypes",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
