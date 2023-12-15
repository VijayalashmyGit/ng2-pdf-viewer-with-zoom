import { Component, Input, ElementRef, ViewChildren, QueryList } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CanvasRenderService } from '../../services/canvasrender.service';
import { ZoomPdfComponent } from '../zoom-pdf/zoom-pdf.component';


@Component({
  selector: 'app-hotspot',
  templateUrl: './hotspot.component.html',
  styleUrls: ['./hotspot.component.scss']
})
export class HotspotComponent {
  @Input() filteredData: any;
  @Input() pdfEvent: any;
  @ViewChildren('preCanvas') preCanvas: QueryList<ElementRef>;
  isShowCanvas: boolean[] = [];

  constructor(public dialog: MatDialog, private canvasRenderService: CanvasRenderService) { }

  ngOnChanges() {
    this.isShowCanvas = this.filteredData.map(() => false);
    setTimeout(() => {
      this.filteredData.forEach((data: any, index: number) => {
        this.canvasRenderService.renderPageToCanvas(data, this.preCanvas.toArray()[index], this.pdfEvent, true);
      });
    }, 0);
  }

  onMouseOver(currentLabel: number): void {
    this.isShowCanvas = this.isShowCanvas.map((_, index) => index === currentLabel);
  }

  onMouseLeave(): void {
    this.isShowCanvas = this.isShowCanvas.map(() => false);
  }

  openDialog(currentLabel: number): void {
    this.dialog.open(ZoomPdfComponent, {
      maxWidth: '92vw',
      width: '100%',
      height: '87vh',
      panelClass: 'custom-border-dialog',
      data: { pdfEvent: this.pdfEvent, currentCanvas: currentLabel, canvasData: this.filteredData }
    });
  }

}
