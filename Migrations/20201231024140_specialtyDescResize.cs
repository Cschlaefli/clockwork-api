using Microsoft.EntityFrameworkCore.Migrations;

namespace tephraAPI.Migrations
{
    public partial class specialtyDescResize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Specialties",
                type: "longtext",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Specialties",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 5000,
                oldNullable: true);
        }
    }
}
