import { OnInit, Component } from '@angular/core';
import { ApiResponse } from '../models/apiResponse';
import { ChaptersViewModel } from '../models/chapters.model';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {
  chapters_model: any;

  constructor(private homeService: HomeService) { }

  ngOnInit() {
    this.homeService.getAllChapters().subscribe((data: ApiResponse<ChaptersViewModel>) => {
      this.chapters_model = data;
    });

  }

}
