using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccsessLayer.Migrations
{
    public partial class new_table_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageCategoryID",
                table: "contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "messageCategories",
                columns: table => new
                {
                    MessageCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messageCategories", x => x.MessageCategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_MessageCategoryID",
                table: "contacts",
                column: "MessageCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_messageCategories_MessageCategoryID",
                table: "contacts",
                column: "MessageCategoryID",
                principalTable: "messageCategories",
                principalColumn: "MessageCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_messageCategories_MessageCategoryID",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "messageCategories");

            migrationBuilder.DropIndex(
                name: "IX_contacts_MessageCategoryID",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "MessageCategoryID",
                table: "contacts");
        }
    }
}
