
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Filter } from '../models/filter';
import { Item } from '../models/item';
import { ItemPayload } from '../models/item-payload';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  itemsUrl = `${environment.itemsApiUrl}/items`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getItems(page: number, pageSize: number, filter: Filter): Observable<ItemPayload> {
    let categoriesString: string = "";
    filter.categories.forEach(cc => categoriesString = categoriesString + cc + "#");
    if (categoriesString.length > 0)
      categoriesString = categoriesString.substring(0, categoriesString.length - 1);

    let params = new HttpParams()
      .set("name", filter.name)
      .set("pageNumber", page.toString())
      .set("pageSize", pageSize.toString())
      .set("category", categoriesString);

    return this.http.get<ItemPayload>(this.itemsUrl, { params: params })
      .pipe(catchError(this.handleError<ItemPayload>('getItems', { items: [], count: 0 })));
  }

  getItem(id: string): Observable<Item> {
    const url = `${this.itemsUrl}/${id}`;
    return this.http.get<Item>(url)
      .pipe(catchError(this.handleError<Item>(`getItem/${id}`, { new_id: "0", new_name: "", new_price: 0, new_category: "", new_description: "" })));
  }

  handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    }
  }

  constructor(private http: HttpClient) { }
}