import {
  AfterViewChecked,
  Component,
  ElementRef,
  OnInit,
  QueryList,
  ViewChild,
  ViewChildren,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  styleUrls: ['./chat.component.css'],
})
export class ChatComponent implements OnInit, AfterViewChecked {
  messages: GetByReceiverAndSenderResponse[];
  userId: string | undefined;
  connection: HubConnection;
  receiverId: string;
  users: GetByUserResponse[];
  disableScrollDown: boolean = false;
  index: number = 0;
  messageForm: FormGroup;

  @ViewChild('scrollMe') myScrollContainer: ElementRef;
  @ViewChildren('item') itemElements: QueryList<any>;

  constructor(
    private tokenService: TokenService,
    private messageService: MessageService,
    private signalRService: SignalrService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder
  ) {}

  async ngOnInit() {
    this.createMessageForm();
    this.userId = this.tokenService.getUserWithJWT()?.id;
    await this.getConnection();
    this.getMessages(this.index, 20);
    this.getUsers();
  }

  ngAfterViewChecked() {
    this.scrollToBottom();

    this.itemElements.changes.subscribe((_) => this.onItemElementsChanged());
  }

  private onItemElementsChanged(): void {
    this.scrollToBottom();
  }
  createMessageForm() {
    this.messageForm = this.formBuilder.group({
      message: ['', [Validators.required, Validators.minLength(1)]],
    });
  }

  scrollToBottom(): void {
    if (this.disableScrollDown) {
      return;
    }
    try {
      this.myScrollContainer.nativeElement.scrollTop =
        this.myScrollContainer.nativeElement.scrollHeight;
      console.log(this.myScrollContainer.nativeElement.scrollHeight);
    } catch (err) {}
  }

  async getConnection() {
    this.connection = await this.signalRService.startConnection(
      environment.baseUrl + 'messages'
    );
    this.connection.on('UserJoined', (data) => {
      console.log('USER JOINED');

      console.log(data);
    });

    this.connection.on('Clients', (data) => {
      console.log('CLIENTS');

      console.log(data);
    });

    this.connection.on('ReceiveMessage', (data) => {
      this.getUsers();
      console.log('RECEIVED MESSAGE');

      this.messages.splice(0, 0, {
        id: '',
        isRead: false,
        messageText: data,
        receiverId: this.userId!,
        senderId: this.receiverId,
        receiverUserName: '',
        senderUserName: '',
        sendDate: new Date(),
      });
    });
    this.disableScrollDown = false;

    this.scrollToBottom();
  }

  getUsers() {
    this.messageService.getByUser(this.userId!).subscribe({
      next: (data) => {
        this.users = data;
      },
    });
  }

  getMessages(index: number, size: number) {
    this.activatedRoute.params.subscribe({
      next: (params) => {
        this.receiverId = params['companyId'];

        if (this.receiverId != null)
          this.messageService
            .getByReceiverAndSender(this.receiverId, this.userId!, index, size)
            .subscribe({
              next: (data) => {
                this.index += 1;
                if (this.messages == null) this.messages = [];
                console.log(index);

                data.items.forEach((e) => {
                  this.messages.push(e);
                });
              },
              error: (error) => {
                console.log(error);
              },
            });
      },
    });
  }

  async send() {
    let messageFormValue = Object.assign({}, this.messageForm.value);
    let message = messageFormValue.message;
    console.log(message);

    if (!this.messageForm.valid) return;

    await this.connection.invoke('SendMessage', this.receiverId, message);
    this.messages.splice(0, 0, {
      id: '',
      isRead: false,
      messageText: message,
      receiverId: this.receiverId,
      senderId: this.userId!,
      receiverUserName: '',
      senderUserName: '',
      sendDate: new Date(),
    });
    this.messageForm.reset();

    this.disableScrollDown = false;
    this.scrollToBottom();
  }

  keyPress(event: any) {
    this.send();
  }

  onScroll(event: any) {
    let element = this.myScrollContainer.nativeElement;
    let atBottom =
      element.scrollHeight - element.scrollTop === element.clientHeight;
    if (this.disableScrollDown && atBottom) {
      this.disableScrollDown = false;
    } else {
      this.disableScrollDown = true;
    }
    if (event.target.scrollTop <= 100) {
      setTimeout(() => this.getMessages(this.index, 20), 2000);
      console.log('Mesaj getirildi');
    }
  }
}
