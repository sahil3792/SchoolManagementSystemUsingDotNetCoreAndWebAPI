using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewColumninTeacherLeaveTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TeachersLeaves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TeachersLeaves");
        }
    }
}
