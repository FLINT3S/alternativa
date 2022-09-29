using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class SpawnDataDimensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Dimension",
                table: "CharacterSpawnData",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "CharacterSpawnData");
        }
    }
}
