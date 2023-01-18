using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RRelationnelle.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _fName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _lName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _activation = table.Column<bool>(type: "bit", nullable: false),
                    _creationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id_Category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idcreator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id_Category);
                    table.ForeignKey(
                        name: "FK_Category_Admin_idcreator",
                        column: x => x.idcreator,
                        principalTable: "Admin",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ressource",
                columns: table => new
                {
                    ID_Ressource = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _category = table.Column<int>(type: "int", nullable: false),
                    _activation = table.Column<bool>(type: "bit", nullable: false),
                    _views = table.Column<int>(type: "int", nullable: false),
                    _creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressource", x => x.ID_Ressource);
                    table.ForeignKey(
                        name: "FK_Ressource_Category__category",
                        column: x => x._category,
                        principalTable: "Category",
                        principalColumn: "Id_Category",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_idcreator",
                table: "Category",
                column: "idcreator");

            migrationBuilder.CreateIndex(
                name: "IX_Ressource__category",
                table: "Ressource",
                column: "_category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ressource");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Admin");
        }
    }
}
