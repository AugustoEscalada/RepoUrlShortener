using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoAcortadorURL.Migrations
{
    /// <inheritdoc />
    public partial class addcolumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "ShortenedUrls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "ShortenedUrls");
        }
    }
}
