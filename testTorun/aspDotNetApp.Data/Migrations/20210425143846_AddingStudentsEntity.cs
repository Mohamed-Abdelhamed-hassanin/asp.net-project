using Microsoft.EntityFrameworkCore.Migrations;

namespace aspDotNetApp.Data.Migrations
{
    public partial class AddingStudentsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grades = table.Column<float>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    Universtiesid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Universties_Universtiesid",
                        column: x => x.Universtiesid,
                        principalTable: "Universties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Universtiesid",
                table: "Students",
                column: "Universtiesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
