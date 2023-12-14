
using VassaSpraket_TW.Data.Models;
using VassaSpraket_TW.Enums;
using VassaSpraket_TW.Helpers;

namespace VassaSpraket_TW.Models
{
    public class PageTemplateViewModel
    {

        public int Id { get; set; }
        public string PdfSrc { get; set; }
        public string ThumbnailImg { get; set; }
        public int ChapterId { get; set; }
        public List<LabelCanvasPosViewModel> Rows { get; set; }

         public static implicit operator PageTemplateViewModel(PageTemplate pageTemplate) => new PageTemplateViewModel
        {
            Id = pageTemplate.Id,
            PdfSrc = string.IsNullOrEmpty(pageTemplate.PdfSrc) ? "" : GetBaseUrl() + pageTemplate.PdfSrc,
            ThumbnailImg = string.IsNullOrEmpty(pageTemplate.ThumbnailImg) ? "" : GetBaseUrl() + pageTemplate.ThumbnailImg,
          
            ChapterId = pageTemplate.ChapterId,         
            Rows = pageTemplate.Rows == null ? new List<LabelCanvasPosViewModel>() : pageTemplate.Rows.Select<LabelCanvasPos, LabelCanvasPosViewModel>(b => b).ToList()

        };

        private static string GetBaseUrl()
        {
            return PathResolverHelper.ResolveUrl(PathResolverEnum.PageTemplate);
        }

    }

    public class LabelCanvasPosViewModel
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



        public static implicit operator LabelCanvasPosViewModel(LabelCanvasPos labelCanvasPos) => new LabelCanvasPosViewModel
        {
            Id = labelCanvasPos.Id,
            PageNumber = labelCanvasPos.PageNumber,
            LabelCanvas_Top = labelCanvasPos.LabelCanvas_Top,
            LabelCanvas_Left = labelCanvasPos.LabelCanvas_Left,
            LabelCanvas_Width = labelCanvasPos.LabelCanvas_Width,
            LabelCanvas_Height = labelCanvasPos.LabelCanvas_Height,
            Canvas_StartX = labelCanvasPos.Canvas_StartX,
            Canvas_StartY = labelCanvasPos.Canvas_StartY,
            Canvas_Width = labelCanvasPos.Canvas_Width,
            Canvas_Height = labelCanvasPos.Canvas_Height,
            Scale = labelCanvasPos.Scale,           
            PageTemplateId = labelCanvasPos.PageTemplateId
        };

    }

    

}
