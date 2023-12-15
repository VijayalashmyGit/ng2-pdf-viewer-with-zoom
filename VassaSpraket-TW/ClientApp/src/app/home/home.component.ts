import { Component, inject, signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { HomeService } from './home.service';
import { ChaptersViewModel } from '../models/chapters.model';
import { catchError, map, of } from 'rxjs';


type State = {
  state: 'loading';
} | {
  state: 'loaded';
  chapters: ChaptersViewModel[];
} | {
  state: 'error';
  error: any;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  readonly data = toSignal(inject(HomeService).getAllChapters().pipe(
    map((result): State => {
      if (result.success) {
        return { state: 'loaded', chapters: result.payload };
      } else {
        throw result.errorMessage;
      }
    }),
    catchError(error => of<State>({ state: 'error', error })),
  ), { initialValue: { state: 'loading' } as State});

}
