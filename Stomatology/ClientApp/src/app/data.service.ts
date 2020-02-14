import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Doctor } from './doctor';

@Injectable()
export class DataService {

  private url = "/api/doctors";

  constructor(private http: HttpClient) {
  }

  getDoctors() {
    return this.http.get(this.url);
  }
}
