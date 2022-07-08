using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UserAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "DeviceOS",
                table: "Sessions",
                newName: "UserAgent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserAgent",
                table: "Sessions",
                newName: "DeviceOS");

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "Sessions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
