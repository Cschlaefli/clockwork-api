using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tephraAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Skill = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Requirments = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "longtext", maxLength: 5000, nullable: true),
                    Acc = table.Column<int>(type: "int", nullable: false),
                    Stk = table.Column<int>(type: "int", nullable: false),
                    Eva = table.Column<int>(type: "int", nullable: false),
                    Def = table.Column<int>(type: "int", nullable: false),
                    Spd = table.Column<int>(type: "int", nullable: false),
                    Pri = table.Column<int>(type: "int", nullable: false),
                    Aug = table.Column<int>(type: "int", nullable: false),
                    DIY = table.Column<int>(type: "int", nullable: false),
                    Wnd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specialties");
        }
    }
}
