using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JOMarkt.Data.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subCategory_Categories_Categoriesid",
                table: "subCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_subCategory_Category_CategoryCategorieId",
                table: "subCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubsubCategory_subCategory_SubcategoryId",
                table: "SubsubCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subCategory",
                table: "subCategory");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "subCategory",
                newName: "SubCategory");

            migrationBuilder.RenameIndex(
                name: "IX_subCategory_CategoryCategorieId",
                table: "SubCategory",
                newName: "IX_SubCategory_CategoryCategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_subCategory_Categoriesid",
                table: "SubCategory",
                newName: "IX_SubCategory_Categoriesid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory",
                column: "SubcategoryId");

            migrationBuilder.CreateTable(
                name: "Product_1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EAN = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Shortdescription = table.Column<string>(nullable: true),
                    Fulldescription = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Subcategory = table.Column<string>(nullable: true),
                    Subsubcategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_1", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Categories_Categoriesid",
                table: "SubCategory",
                column: "Categoriesid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Category_CategoryCategorieId",
                table: "SubCategory",
                column: "CategoryCategorieId",
                principalTable: "Category",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubsubCategory_SubCategory_SubcategoryId",
                table: "SubsubCategory",
                column: "SubcategoryId",
                principalTable: "SubCategory",
                principalColumn: "SubcategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Categories_Categoriesid",
                table: "SubCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Category_CategoryCategorieId",
                table: "SubCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubsubCategory_SubCategory_SubcategoryId",
                table: "SubsubCategory");

            migrationBuilder.DropTable(
                name: "Product_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory");

            migrationBuilder.RenameTable(
                name: "SubCategory",
                newName: "subCategory");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategory_CategoryCategorieId",
                table: "subCategory",
                newName: "IX_subCategory_CategoryCategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategory_Categoriesid",
                table: "subCategory",
                newName: "IX_subCategory_Categoriesid");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_subCategory",
                table: "subCategory",
                column: "SubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_subCategory_Categories_Categoriesid",
                table: "subCategory",
                column: "Categoriesid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subCategory_Category_CategoryCategorieId",
                table: "subCategory",
                column: "CategoryCategorieId",
                principalTable: "Category",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubsubCategory_subCategory_SubcategoryId",
                table: "SubsubCategory",
                column: "SubcategoryId",
                principalTable: "subCategory",
                principalColumn: "SubcategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
