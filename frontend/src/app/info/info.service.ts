import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class InfoService {

  private _data$: BehaviorSubject<any[]> = new BehaviorSubject(null)
  public data$: Observable<any[]> = this._data$
    .asObservable().pipe(
      filter(item => item !== null)
    );

  private _info$: BehaviorSubject<any[]> = new BehaviorSubject(null)
  public info$: Observable<any[]> = this._info$
    .asObservable().pipe(
      filter(item => item !== null)
    );

  fetch(id: string) {
    let url = `http://geoinfo.surayfer.com/api/infrastructureobjects/${id}/reviews`

    this._http.get(url)
      .subscribe((data: any[]) => {
        this._data$.next(data);
      });

    this._http.get(`http://geoinfo.surayfer.com/api/infrastructureobjects/${id}`)
      .subscribe((data: any) => {
        this._info$.next(data[0].data);
      });
  }

  constructor(
    private _http: HttpClient
  ) { }
}
