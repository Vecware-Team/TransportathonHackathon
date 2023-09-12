import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DriverService{
  apiUrl=environment.apiUrl+"drivers/";
  constructor(private httpClient:HttpClient) { }


}
