import { Injectable } from '@angular/core';
import { Observable, Subject, throwError } from 'rxjs';
import { Iproduct } from './iproduct';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private productsUrl = 'api/items';
  constructor(private http: HttpClient) { }

  getProducts(): Observable<Iproduct[]>{
    return this.http.get<Iproduct[]>(this.productsUrl).pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
      catchError(this.handleError)
    );

  }
  handleError(err: HttpErrorResponse){
    //In a real world app, we may send the server to some remote logging inrastructure
    //Instead of just logging it to the console
    let errorMessage = '';
    if(err.error instanceof ErrorEvent){
        //A client-side or network error occured. Handle it accordingly
        errorMessage = `An error occured: ${err.error.message}`;
    }else {
        //The backend returned an unsuccessful response code.
        //The response body may contain clues as to what went wrong.
        errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
}
}
