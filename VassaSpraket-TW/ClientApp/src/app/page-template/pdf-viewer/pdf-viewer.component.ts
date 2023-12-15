import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-pdf-viewer',
  templateUrl: './pdf-viewer.component.html',
  styleUrls: ['./pdf-viewer.component.scss']
})
export class PdfViewerComponent implements OnInit {
  @Input() model: any;
  @Input() currentIndex: any;
  @Input() filteredData = [];
  pdfSrc: string = "";
  thumbnailImgUrl: string = "";
  pdfEvent: any;
  @Output() totalPagesLoaded: EventEmitter<number> = new EventEmitter();
  @Output() btnLoaded: EventEmitter<boolean> = new EventEmitter();

  isLoading = false;

  constructor() { }

  ngOnInit(): void {
    this.pdfSrc = this.model.pdfSrc;
    this.thumbnailImgUrl = this.model.thumbnailImg;
  }

  afterLoadComplete(pdfData: any) {
    this.pdfEvent = pdfData;
    this.totalPagesLoaded.emit(pdfData.numPages);
  }

  pageRendered(pdfData: any) {
    this.btnLoaded.emit(true);
    this.isLoading = true;
  }


}
