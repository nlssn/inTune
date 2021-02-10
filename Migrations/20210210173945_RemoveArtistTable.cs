using Microsoft.EntityFrameworkCore.Migrations;

namespace inTune.Migrations
{
    public partial class RemoveArtistTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Artists_ArtistId",
                table: "Records");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Records",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Records",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Artists_ArtistId",
                table: "Records",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Artists_ArtistId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Records");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Artists_ArtistId",
                table: "Records",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
