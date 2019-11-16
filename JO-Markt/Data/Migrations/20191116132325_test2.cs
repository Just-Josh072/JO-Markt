using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JOMarkt.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Category_CategoryCategorieId",
                table: "SubCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubsubCategory_SubCategory_SubcategoryId",
                table: "SubsubCategory");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_subCategory",
                table: "subCategory",
                column: "SubcategoryId");

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Discount_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    EAN = table.Column<string>(nullable: true),
                    DiscountPrice = table.Column<double>(nullable: false),
                    ValidUntil = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Discount_Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subCategory_Category_CategoryCategorieId",
                table: "subCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubsubCategory_subCategory_SubcategoryId",
                table: "SubsubCategory");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subCategory",
                table: "subCategory");

            migrationBuilder.RenameTable(
                name: "subCategory",
                newName: "SubCategory");

            migrationBuilder.RenameIndex(
                name: "IX_subCategory_CategoryCategorieId",
                table: "SubCategory",
                newName: "IX_SubCategory_CategoryCategorieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory",
                column: "SubcategoryId");

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
    }
}
