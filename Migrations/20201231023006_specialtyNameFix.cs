using Microsoft.EntityFrameworkCore.Migrations;

namespace tephraAPI.Migrations
{
    public partial class specialtyNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriptions",
                table: "Specialties",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Augment",
                table: "Specialties",
                newName: "Augments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Specialties",
                newName: "Descriptions");

            migrationBuilder.RenameColumn(
                name: "Augments",
                table: "Specialties",
                newName: "Augment");
        }
    }
}
