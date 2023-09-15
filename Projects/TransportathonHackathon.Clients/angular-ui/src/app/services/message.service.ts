import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Paginate } from '../core/models/pagination/paginate';
import { GetByReceiverAndSenderResponse } from '../models/response-models/messages/getByReceiverAndSenderResponse';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { GetByUserResponse } from '../models/response-models/messages/getByUserResponse';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  constructor(private httpClient: HttpClient) {}

  getByReceiverAndSender(
    receiver: string,
    sender: string,
    index: number = 0,
    size: number = 20
  ): Observable<Paginate<GetByReceiverAndSenderResponse>> {
    return this.httpClient.get<Paginate<GetByReceiverAndSenderResponse>>(
      environment.apiUrl +
        'messages/getbysenderandreceiver?receiverId=' +
        receiver +
        '&senderId=' +
        sender +
        '&PageRequest.Index=' +
        index +
        '&PageRequest.Size=' +
        size
    );
  }

  getByUser(userId: string): Observable<GetByUserResponse[]> {
    return this.httpClient.get<GetByUserResponse[]>(
      environment.apiUrl + 'messages/getbyuser?userId=' + userId
    );
  }
}
