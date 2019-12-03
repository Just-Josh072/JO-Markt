using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JOMarkt.Data.Migrations
{
    public partial class kaas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categoriesid",
                table: "SubsubCategory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Categoriesid",
                table: "subCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subsubcategory",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryCategorieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_Categories_Category_CategoryCategorieId",
                        column: x => x.CategoryCategorieId,
                        principalTable: "Category",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubsubCategory_Categoriesid",
                table: "SubsubCategory",
                column: "Categoriesid");

            migrationBuilder.CreateIndex(
                name: "IX_subCategory_Categoriesid",
                table: "subCategory",
                column: "Categoriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryCategorieId",
                table: "Categories",
                column: "CategoryCategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_subCategory_Categories_Categoriesid",
                table: "subCategory",
                column: "Categoriesid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubsubCategory_Categories_Categoriesid",
                table: "SubsubCategory",
                column: "Categoriesid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subCategory_Categories_Categoriesid",
                table: "subCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubsubCategory_Categories_Categoriesid",
                table: "SubsubCategory");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_SubsubCategory_Categoriesid",
                table: "SubsubCategory");

            migrationBuilder.DropIndex(
                name: "IX_subCategory_Categoriesid",
                table: "subCategory");

            migrationBuilder.DropColumn(
                name: "Categoriesid",
                table: "SubsubCategory");

            migrationBuilder.DropColumn(
                name: "Categoriesid",
                table: "subCategory");

            migrationBuilder.DropColumn(
                name: "Subsubcategory",
                table: "Product");
        }
    }
}
