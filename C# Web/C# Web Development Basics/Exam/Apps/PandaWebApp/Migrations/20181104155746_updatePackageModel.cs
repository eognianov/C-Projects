using Microsoft.EntityFrameworkCore.Migrations;

namespace PandaWebApp.Migrations
{
    public partial class updatePackageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Packages",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "Packages",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
