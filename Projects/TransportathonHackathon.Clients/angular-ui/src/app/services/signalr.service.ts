import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  constructor(private tokenService: TokenService) { }

  async startConnection(url: string): Promise<HubConnection> {
    let hubConnection: HubConnection = new HubConnectionBuilder()
      .withUrl(url, { accessTokenFactory: () => this.tokenService.getToken() ?? "" })
      .withAutomaticReconnect([1000, 2000, 2000, 2000, 5000, 5000, 10000])
      .build();

    await hubConnection.start();

    return hubConnection;
  }
}
