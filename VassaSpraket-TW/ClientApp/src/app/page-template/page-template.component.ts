import { Component, inject } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { PageTemplateService } from './page-template.service';
import { ActivatedRoute } from '@angular/router';
import { PageTemplateViewModel } from '../models/page-template.model';
import { catchError, map, of, switchMap } from 'rxjs';


type State = {
  state: 'loading';
} | {
  state: 'loaded';
  pageTemplate: PageTemplateViewModel;
} | {
  state: 'error';
  error: any;
}

@Component({
  selector: 'app-page-template',
  templateUrl: './page-template.component.html',
  styleUrls: ['./page-template.component.scss']
})
export class PageTemplateComponent {
  private readonly pageTemplateService = inject(PageTemplateService);
  readonly model = toSignal(inject(ActivatedRoute).paramMap.pipe(
    switchMap(params => this.pageTemplateService.getPageTemplateById(Number(params.get('id')))),
    map((result): State => {
      if (result.success) {
        return { state: 'loaded', pageTemplate: result.payload };
      } else {
        throw result.errorMessage;
      }
    }),
    catchError(error => of<State>({ state: 'error', error })),
  ), { initialValue: { state: 'loading' } as State});
}
