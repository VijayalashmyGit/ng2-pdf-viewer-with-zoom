export class PageTemplateViewModel{
  id: number;
  pdfSrc: string;
  thumbnailImg: string;
  chapterId: number;
  rows: LabelCanvasPosViewModel[];
}

export class LabelCanvasPosViewModel {
  id: number;
  pageNumber: number;
  labelCanvas_Top: string;
  labelCanvas_Left: string;
  labelCanvas_Width: string;
  labelCanvas_Height: string;
  canvas_StartX: number;
  canvas_StartY: number;
  canvas_Width: number;
  canvas_Height: number;
  scale: number;
  pageTemplateId: number;
}
