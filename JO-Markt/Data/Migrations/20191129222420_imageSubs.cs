using Microsoft.EntityFrameworkCore.Migrations;

namespace JOMarkt.Data.Migrations
{
    public partial class imageSubs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "SubsubCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "subCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "SubsubCategory");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "subCategory");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Category");
        }
    }
}
