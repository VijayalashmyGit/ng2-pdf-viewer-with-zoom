import { Component, Input, signal, computed } from '@angular/core';
import { PageTemplateViewModel } from '../../models/page-template.model';
import { PDFDocumentProxy } from 'ng2-pdf-viewer';


@Component({
  selector: 'app-pdf-viewer',
  templateUrl: './pdf-viewer.component.html',
  styleUrls: ['./pdf-viewer.component.scss'],
})
export class PdfViewerComponent {
  readonly pdfLoaded = signal(false);
  readonly currentPage = signal(1);
  readonly totalPages = signal(1);

  @Input({ required: true }) set model(value: PageTemplateViewModel) {
    this.modelSignal.set(value);
  }
  protected readonly modelSignal = signal<PageTemplateViewModel>({
    chapterId: 0,
    id: 0,
    pdfSrc: '',
    thumbnailImg: '',
    rows: [],
  });


  readonly showPrevPage = computed(() => this.currentPage() > 1);
  readonly showNextPage = computed(() => this.currentPage() < this.totalPages());

  readonly filteredData = computed(() => {
    const page = this.currentPage();
    return this.modelSignal().rows.filter(row => row.pageNumber === page)
  });

  afterLoadComplete(pdf: PDFDocumentProxy) {
    this.pdfLoaded.set(true);
    this.totalPages.set(pdf.numPages);
  }
}
