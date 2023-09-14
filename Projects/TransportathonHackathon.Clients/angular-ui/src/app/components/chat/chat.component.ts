import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HubConnection } from '@microsoft/signalr';
import { GetByUserResponse } from 'src/app/models/response-models/messages/GetByUserResponse';
import { GetByReceiverAndSenderResponse } from 'src/app/models/response-models/messages/getByReceiverAndSenderResponse';
import { MessageService } from 'src/app/services/message.service';
import { SignalrService } from 'src/app/services/signalr.service';
import { TokenService } from 'src/app/services/token.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  messages: GetByReceiverAndSenderResponse[];
  userId: string | undefined;
  message: string = "";
  connection: HubConnection;
  receiverId: string;
  users: GetByUserResponse[];

  constructor(private tokenService: TokenService, private messageService: MessageService, private signalRService: SignalrService, private activatedRoute: ActivatedRoute) { }

  async ngOnInit() {
    this.userId = this.tokenService.getUserWithJWT()?.id;
    await this.getConnection();
    this.getMessages();
    this.getUsers();
  }

  async getConnection() {
    this.connection = await this.signalRService.startConnection(environment.baseUrl + "messages");
    this.connection.on("UserJoined", data => {
      console.log("USER JOINED");

      console.log(data);

    })

    this.connection.on("Clients", data => {
      console.log("CLIENTS");

      console.log(data);
    })

    this.connection.on("ReceiveMessage", data => {
      console.log("RECEIVED MESSAGE");

      this.messages.push({ id: "", isRead: false, messageText: data, receiverId: this.userId!, senderId: this.receiverId, receiverUserName: "", senderUserName: "", sendDate: new Date() });

    })

  }

  getUsers() {
    this.messageService.getByUser(this.userId!).subscribe({
      next: (data) => {
        this.users = data;
      }
    })
  }

  getMessages() {
    this.activatedRoute.params.subscribe({
      next: (params) => {
        this.receiverId = params["companyId"];

        if (this.receiverId != null)
          this.messageService.getByReceiverAndSender(this.receiverId, this.userId!).subscribe({
            next: (data) => {
              this.messages = data.items;
            },
            error: (error) => {
              console.log(error);
            }
          });
      }
    })
  }

  async send() {
    await this.connection.invoke("SendMessage", this.receiverId, this.message)
    this.messages.push({ id: "", isRead: false, messageText: this.message, receiverId: this.receiverId, senderId: this.userId!, receiverUserName: "", senderUserName: "", sendDate: new Date() });
    this.message = "";
  }

  change(event: any) {
    this.message = event.target.value
  }
}