using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccsessLayer.Migrations
{
    public partial class new_add_worklatiocion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkDepartmant",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkLocationID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "workLocations",
                columns: table => new
                {
                    WorkLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workLocations", x => x.WorkLocationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkLocationID",
                table: "AspNetUsers",
                column: "WorkLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_workLocations_WorkLocationID",
                table: "AspNetUsers",
                column: "WorkLocationID",
                principalTable: "workLocations",
                principalColumn: "WorkLocationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_workLocations_WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "workLocations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkDepartmant",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkLocationID",
                table: "AspNetUsers");
        }
    }
}
