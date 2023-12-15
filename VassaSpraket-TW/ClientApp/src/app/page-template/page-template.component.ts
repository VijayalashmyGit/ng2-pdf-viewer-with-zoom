import { Component, OnInit } from '@angular/core';
import { PageTemplateService } from './page-template.service';
import { ActivatedRoute } from '@angular/router';
import { ApiResponse } from '../models/apiResponse';
import { PageTemplateViewModel } from '../models/page-template.model';

@Component({
  selector: 'app-page-template',
  templateUrl: './page-template.component.html',
  styleUrls: ['./page-template.component.scss']
})
export class PageTemplateComponent implements OnInit {
  model: any;
  currentIndex: number = 1;
  totalPages: number = 0;
  filteredData: any = [];
  isNavBtnShow: boolean;
  constructor(private route: ActivatedRoute, private pageTemplateService: PageTemplateService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      this.pageTemplateService.getPageTemplateById(Number(id)).subscribe((data: ApiResponse<PageTemplateViewModel>) => {
        this.model = data.payload;
        this.loadHotspot();
      });
    });

  }

  loadPrevPage() {
    this.currentIndex--;
    this.loadHotspot();
  }

  loadNxtPage() {
    this.currentIndex++;
    this.loadHotspot();

  }

  updateTotalPages(totalPages: number) {
    this.totalPages = totalPages;

  }

  updatebtn(isLoaded: boolean) {
    this.isNavBtnShow = isLoaded;
  }

  // filter the label, canvas position based on the pagenumber
  loadHotspot() {
    this.filteredData = this.model.rows.filter((item: { pageNumber: number; }) => item.pageNumber === this.currentIndex);

  }

}
