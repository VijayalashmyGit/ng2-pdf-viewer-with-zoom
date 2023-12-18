import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CanvasRenderService {

  constructor() { }

  renderPageToCanvas(currentData: any, preCanvas: any, pdfEvent: any, isHover: boolean) {
    let canvas = preCanvas.nativeElement;
    let context = canvas.getContext('2d');

     var factor_calc: any = 1.9 + (0.003 * (953 - window.innerHeight));
     const factor = Number(factor_calc.toFixed(1));

    let rectCoordinates = isHover ? {
      x: currentData.canvas_StartX / factor,
      y: currentData.canvas_StartY / factor,
      width: currentData.canvas_Width / factor,
      height: currentData.canvas_Height / factor
    } : {
      x: currentData.canvas_StartX,
      y: currentData.canvas_StartY,
      width: currentData.canvas_Width,
      height: currentData.canvas_Height
    };

    canvas.width = rectCoordinates.width;
    canvas.height = rectCoordinates.height;

    if (pdfEvent) {
      pdfEvent.getPage(currentData.pageNumber).then((page: any) => {
        const scaling = isHover ? currentData.scale / factor : currentData.scale;
        const adjustedViewport = page.getViewport({
          scale: scaling,
          offsetX: -rectCoordinates.x,
          offsetY: -rectCoordinates.y
        });

        const renderContext = {
          canvasContext: context,
          viewport: adjustedViewport
        };
        const renderTask = page.render(renderContext);
        renderTask.promise.then(() => {
          const imageData = context.getImageData(0, 0, rectCoordinates.width, rectCoordinates.height);
          context.clearRect(0, 0, canvas.width, canvas.height);
          context.putImageData(imageData, 0, 0);
        }).catch((error: any) => {
          console.error('Page rendering failed', error);
        });
      });
    }
  }
}
