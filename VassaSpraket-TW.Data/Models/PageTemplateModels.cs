namespace VassaSpraket_TW.Data.Models
{
    public class PageTemplate
    {
        public int Id { get; set; }
        public string PdfSrc { get; set; }
        public string ThumbnailImg { get; set; }        
        public int ChapterId { get; set; }
        public List<LabelCanvasPos> Rows { get; set; }

    }

    public class LabelCanvasPos
    {
        public int Id { get; set; }
        public int PageNumber { get; set; }
        public string LabelCanvas_Top { get; set; }
        public string LabelCanvas_Left { get; set; }
        public string LabelCanvas_Width { get; set; }
        public string LabelCanvas_Height { get; set; }
        public int Canvas_StartX { get; set; }
        public int Canvas_StartY { get; set; }
        public int Canvas_Width { get; set; }
        public int Canvas_Height { get; set; }
        public float Scale { get; set; }      
        public int PageTemplateId { get; set; }       

    }


}
