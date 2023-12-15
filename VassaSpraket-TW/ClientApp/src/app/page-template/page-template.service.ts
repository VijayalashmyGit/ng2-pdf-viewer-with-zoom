import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiResponse } from '../models/apiResponse';
import { PageTemplateViewModel } from '../models/page-template.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PageTemplateService {

  private baseUrl: string = environment.apiBaseUrl;
  constructor(private httpClient: HttpClient) { }

  getPageTemplateById(id: number) {
    return this.httpClient.get<ApiResponse<PageTemplateViewModel>>(`${this.baseUrl}PageTemplate/GetById?id=${id}`);
  }

}
