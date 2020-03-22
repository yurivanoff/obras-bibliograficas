import { Injectable } from '@angular/core';
import { Author } from '../_models/Author';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AuthorService {
  baseUrl = environment.apiUrl + 'Authors/';

  constructor(private http: HttpClient) {}

  getAuthors(): Observable<Author[]> {
    return this.http.get<Author[]>(this.baseUrl);
  }

  deleteAuthors(id: number) {
    return this.http.delete(this.baseUrl + id);
  }

  createAuthors(authors: Author[]){
    return this.http.post(this.baseUrl, authors);
  }

}
