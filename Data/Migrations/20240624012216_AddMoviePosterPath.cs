using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMoviePosterPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterPath",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterPath",
                table: "Movie");
        }
    }
}
