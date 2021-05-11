using Microsoft.EntityFrameworkCore.Migrations;

namespace WebGallery.Migrations
{
    public partial class addimagetotblCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "tblCars",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "tblCars");
        }
    }
}
