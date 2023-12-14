using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VassaSpraket_TW.Data.Migrations
{
    /// <inheritdoc />
    public partial class create_table_pagetemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdfSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChapterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabelCanvasPos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    LabelCanvas_Top = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    LabelCanvas_Left = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    LabelCanvas_Width = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    LabelCanvas_Height = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Canvas_StartX = table.Column<int>(type: "int", nullable: false),
                    Canvas_StartY = table.Column<int>(type: "int", nullable: false),
                    Canvas_Width = table.Column<int>(type: "int", nullable: false),
                    Canvas_Height = table.Column<int>(type: "int", nullable: false),
                    Scale = table.Column<float>(type: "real", nullable: false),                  
                    PageTemplateId = table.Column<int>(type: "int", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelCanvasPos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelCanvasPos_PageTemplate_PageTemplateId",
                        column: x => x.PageTemplateId,
                        principalTable: "PageTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelCanvasPos_PageTemplateId",
                table: "LabelCanvasPos",
                column: "PageTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
