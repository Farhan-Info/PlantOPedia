using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantOPedia.Migrations
{
    public partial class Fifthmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(@"Models/SQL Script(PlantOPedia).sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
