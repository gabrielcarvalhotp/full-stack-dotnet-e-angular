using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEvents.Infrastructure.DataAccess.Migrations
{
    public partial class CreateBatchField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Batch",
                table: "Events",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Batch",
                table: "Events");
        }
    }
}
