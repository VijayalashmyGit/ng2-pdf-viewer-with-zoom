import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ApiResponse } from '../models/apiResponse';
import { ChaptersViewModel } from '../models/chapters.model';

@Injectable({
  providedIn: 'root'
})

export class HomeService {

  private baseUrl: string = environment.apiBaseUrl;
  constructor(private httpClient: HttpClient) { }

  getAllChapters() {

    return this.httpClient.get<ApiResponse<ChaptersViewModel>>(this.baseUrl + "Chapters/GetAllChapters");
  }

}
