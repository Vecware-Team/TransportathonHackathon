import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ProfilePicture } from '../models/entities/profilePicture';
import { Observable } from 'rxjs';
import { ResponseModel } from '../core/models/responseModels/responseModel';
import { ListResponseModel } from '../core/models/responseModels/ListResponseModel';
import { ItemResponseModel } from '../core/models/responseModels/ItemResponseModel';

@Injectable({
  providedIn: 'root',
})
export class ProfilePictureService {
  apiUrl = environment.apiUrl + 'profilePictures/';
  constructor(private httpClient: HttpClient) {}

  add(
    file: File,
    profilePicture: ProfilePicture
  ): Observable<ResponseModel> {
    const formData = new FormData();
    formData.append('image', file);
    formData.append('userId', profilePicture.userId.toString());

    return this.httpClient.post<ResponseModel>(
      this.apiUrl + 'add',
      formData,
      {
        reportProgress: true,
      }
    );
  }

  update(
    file: File,
    profilePicture: ProfilePicture
  ): Observable<ResponseModel> {
    const formData = new FormData();
    formData.append('image', file);
    formData.append('userId', profilePicture.userId.toString());
    formData.append('path', profilePicture.path);
    formData.append('profilePictureId', profilePicture.id!.toString());

    return this.httpClient.post<ResponseModel>(
      this.apiUrl + 'update',
      formData,
      {
        reportProgress: true,
        responseType: 'json',
      }
    );
  }

  delete(profilePicture: ProfilePicture): Observable<ResponseModel> {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      body: profilePicture,
    };

    return this.httpClient.delete<ResponseModel>(
      this.apiUrl + 'delete',
      httpOptions
    );
  }

  getByUserId(userId: number): Observable<ItemResponseModel<ProfilePicture>> {
    return this.httpClient.get<ItemResponseModel<ProfilePicture>>(
      this.apiUrl + 'getbyuserid?userId=' + userId
    );
  }

  // getAllByUserIds(
  //   userIds: number[]
  // ): Observable<ListResponseModel<ProfilePicture>> {
  //   return this.httpClient.get<ListResponseModel<ProfilePicture>>(
  //     this.apiUrl + 'getallbyuserids',userIds
  //   );
  // }

  getall(): Observable<ListResponseModel<ProfilePicture>> {
    return this.httpClient.get<ListResponseModel<ProfilePicture>>(
      this.apiUrl + 'getall'
    );
  }

  get(id: number): Observable<ListResponseModel<ProfilePicture>> {
    return this.httpClient.get<ListResponseModel<ProfilePicture>>(
      this.apiUrl + 'get?id?=' + id
    );
  }
}
