using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VassaSpraket_TW.Data.Migrations
{
    /// <inheritdoc />
    public partial class create_table_insertdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Chapters VALUES ('Chapter 1', 1)");
            migrationBuilder.Sql("INSERT INTO Chapters VALUES ('Chapter 2', 2)");
            migrationBuilder.Sql("INSERT INTO PageTemplate VALUES ('ch_1.pdf','ch_1.png', 1)");
            migrationBuilder.Sql("INSERT INTO PageTemplate VALUES ('ch_2.pdf','ch_2.png', 2)");

            migrationBuilder.Sql(@"
    INSERT INTO LabelCanvasPos 
    (        
        PageNumber, 
        LabelCanvas_Top, 
        LabelCanvas_Left, 
        LabelCanvas_Width, 
        LabelCanvas_Height,       
        Canvas_StartX, 
        Canvas_StartY, 
        Canvas_Width, 
        Canvas_Height, 
        Scale,        
        PageTemplateId
    ) 
    VALUES 
    ( 1, '46.5', '50', '74.5', '22.5', 100, 850, 1400, 420, 2.7,1),
    ( 1, '71', '50', '74.5', '22', 100, 1310, 1400, 415, 2.7,1),
    ( 2, '4', '51', '74.5', '39',140, 60, 1400, 730, 2.7,1),
    ( 2, '45', '51', '74.5', '20', 140, 820, 1400, 380, 2.7, 1),
    ( 2, '67', '50', '79', '28', 60, 1230, 1480, 515, 2.7, 1),
    ( 3, '9', '50', '74.5', '38.5', 100, 145, 1400, 730, 2.7, 1),
    ( 3, '50', '50', '74.5', '43', 100, 912, 1400, 815, 2.7, 1),

   ( 1, '9', '51', '74.5', '20', 140, 150, 1400, 380, 2.7, 2),
   ( 1, '32', '51', '74.5', '61',  140, 580, 1400, 1145, 2.7, 2),
   ( 2, '28', '50', '74.5', '38',  100, 510, 1410, 710, 2.7,2),
   ( 2, '67', '50', '74.5', '26', 100, 1230, 1410, 495, 2.7, 2),
   ( 3, '4', '51', '74.5', '47',  140, 60, 1400, 870, 2.7, 2),
   ( 3, '53', '51', '74.5', '40',  140, 970, 1400, 750, 2.7, 2);

");



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
