using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSpot.Migrations
{
    /// <inheritdoc />
    public partial class fixJobosting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriptio",
                table: "JobPosts",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "JobPosts",
                newName: "Descriptio");
        }
    }
}
