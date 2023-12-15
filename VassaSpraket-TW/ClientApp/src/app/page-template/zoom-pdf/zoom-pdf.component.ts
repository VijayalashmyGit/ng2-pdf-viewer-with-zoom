import { Component, ViewChild, ElementRef, Inject, AfterViewInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CanvasRenderService } from '../../services/canvasrender.service';

@Component({
  selector: 'app-zoom-pdf',
  templateUrl: './zoom-pdf.component.html',
  styleUrls: ['./zoom-pdf.component.scss']
})
export class ZoomPdfComponent implements AfterViewInit {

  @ViewChild('cropCanvas', { static: true }) cropCanvas: ElementRef;

  pdf: any;
  currentData: any;
  currentCanvasCount = this.data.currentCanvas;
  totalCanvasCount: number = this.data.canvasData.length - 1;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private canvasRenderService: CanvasRenderService) { }

  ngAfterViewInit() {
    this.pdf = this.data.pdfEvent;
    this.renderCurrentCanvas(this.currentCanvasCount);
  }

  renderCurrentCanvas(count: any) {
    this.currentData = this.data.canvasData[count];
    setTimeout(() => {
      this.canvasRenderService.renderPageToCanvas(this.currentData, this.cropCanvas, this.pdf, false);
    }, 0);
  }

  loadprevcanvas() {
    this.currentCanvasCount--;
    this.renderCurrentCanvas(this.currentCanvasCount);
  }

  loadnxtcanvas() {
    this.currentCanvasCount++;
    this.renderCurrentCanvas(this.currentCanvasCount);
  }

}
