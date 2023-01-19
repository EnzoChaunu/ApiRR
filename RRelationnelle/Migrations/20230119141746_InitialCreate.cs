using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RRelationnelle.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id_role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id_role);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    id_stat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NbSharing = table.Column<int>(type: "int", nullable: false),
                    NbLike = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateStat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.id_stat);
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
                    Id_Category = table.Column<int>(type: "int", nullable: true),
                    _activation = table.Column<bool>(type: "bit", nullable: false),
                    _views = table.Column<int>(type: "int", nullable: false),
                    _creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressource", x => x.ID_Ressource);
                    table.ForeignKey(
                        name: "FK_Ressource_Category_Id_Category",
                        column: x => x.Id_Category,
                        principalTable: "Category",
                        principalColumn: "Id_Category",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
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
                    _creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_role = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id_User);
                    table.ForeignKey(
                        name: "FK_User_Role_id_role",
                        column: x => x.id_role,
                        principalTable: "Role",
                        principalColumn: "id_role",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id_comments = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_User = table.Column<int>(type: "int", nullable: true),
                    ID_Ressource = table.Column<int>(type: "int", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    likes = table.Column<int>(type: "int", nullable: false),
                    dislikes = table.Column<int>(type: "int", nullable: false),
                    activation = table.Column<bool>(type: "bit", nullable: false),
                    modified = table.Column<bool>(type: "bit", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id_comments);
                    table.ForeignKey(
                        name: "FK_Comments_Ressource_ID_Ressource",
                        column: x => x.ID_Ressource,
                        principalTable: "Ressource",
                        principalColumn: "ID_Ressource",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_User_Id_User",
                        column: x => x.Id_User,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ID_Ressource",
                table: "Comments",
                column: "ID_Ressource");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Id_User",
                table: "Comments",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_Ressource_Id_Category",
                table: "Ressource",
                column: "Id_Category");

            migrationBuilder.CreateIndex(
                name: "IX_User_id_role",
                table: "User",
                column: "id_role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Ressource");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
