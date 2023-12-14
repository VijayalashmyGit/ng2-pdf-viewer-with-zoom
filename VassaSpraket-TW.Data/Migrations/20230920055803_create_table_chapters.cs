using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VassaSpraket_TW.Data.Migrations
{
    /// <inheritdoc />
    public partial class create_table_chapters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Chapters",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  ChapterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  ChapterNumber = table.Column<int>(type: "int", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Chapters", x => x.Id);
              });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
