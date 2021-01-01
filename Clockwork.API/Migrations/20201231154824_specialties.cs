using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tephraAPI.Migrations
{
    public partial class specialties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: true),
                    Skill = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Attr = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Subtype = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Requirments = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Resist = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Cost = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "longtext", maxLength: 10000, nullable: true),
                    Stance = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Reflexive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Notes = table.Column<string>(type: "longtext", maxLength: 10000, nullable: true),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    Strike = table.Column<int>(type: "int", nullable: false),
                    Evade = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Augments = table.Column<int>(type: "int", nullable: false),
                    DIY = table.Column<int>(type: "int", nullable: false),
                    Wounds = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false)
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
