using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesGroup.Data.Migrations
{
    /// <inheritdoc />
    public partial class MovieAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_AgeLimits_AgeLimitId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "AgeLimitId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_AgeLimits_AgeLimitId",
                table: "Movies",
                column: "AgeLimitId",
                principalTable: "AgeLimits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_AgeLimits_AgeLimitId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "AgeLimitId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_AgeLimits_AgeLimitId",
                table: "Movies",
                column: "AgeLimitId",
                principalTable: "AgeLimits",
                principalColumn: "Id");
        }
    }
}
