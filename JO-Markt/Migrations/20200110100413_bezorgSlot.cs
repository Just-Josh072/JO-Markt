using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JOMarkt.Migrations
{
    public partial class bezorgSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Promotions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bezorgslot",
                columns: table => new
                {
                    BezorgslotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    BeginTijd = table.Column<DateTime>(nullable: false),
                    EindTijd = table.Column<DateTime>(nullable: false),
                    Prijs = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bezorgslot", x => x.BezorgslotId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bezorgslot");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Promotions");
        }
    }
}
