using Microsoft.EntityFrameworkCore.Migrations;

namespace tephraAPI.Migrations
{
    public partial class SpecialtyFinish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wnd",
                table: "Specialties",
                newName: "Wounds");

            migrationBuilder.RenameColumn(
                name: "Stk",
                table: "Specialties",
                newName: "Strike");

            migrationBuilder.RenameColumn(
                name: "Spd",
                table: "Specialties",
                newName: "Speed");

            migrationBuilder.RenameColumn(
                name: "Pri",
                table: "Specialties",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "Eva",
                table: "Specialties",
                newName: "HitPoints");

            migrationBuilder.RenameColumn(
                name: "Def",
                table: "Specialties",
                newName: "Evade");

            migrationBuilder.RenameColumn(
                name: "Aug",
                table: "Specialties",
                newName: "Defense");

            migrationBuilder.RenameColumn(
                name: "Acc",
                table: "Specialties",
                newName: "Augment");

            migrationBuilder.AddColumn<int>(
                name: "Accuracy",
                table: "Specialties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Attr",
                table: "Specialties",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cost",
                table: "Specialties",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "Specialties",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Reflexive",
                table: "Specialties",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Resist",
                table: "Specialties",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Stance",
                table: "Specialties",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Subtype",
                table: "Specialties",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accuracy",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "Attr",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "Reflexive",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "Resist",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "Stance",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "Subtype",
                table: "Specialties");

            migrationBuilder.RenameColumn(
                name: "Wounds",
                table: "Specialties",
                newName: "Wnd");

            migrationBuilder.RenameColumn(
                name: "Strike",
                table: "Specialties",
                newName: "Stk");

            migrationBuilder.RenameColumn(
                name: "Speed",
                table: "Specialties",
                newName: "Spd");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Specialties",
                newName: "Pri");

            migrationBuilder.RenameColumn(
                name: "HitPoints",
                table: "Specialties",
                newName: "Eva");

            migrationBuilder.RenameColumn(
                name: "Evade",
                table: "Specialties",
                newName: "Def");

            migrationBuilder.RenameColumn(
                name: "Defense",
                table: "Specialties",
                newName: "Aug");

            migrationBuilder.RenameColumn(
                name: "Augment",
                table: "Specialties",
                newName: "Acc");
        }
    }
}
