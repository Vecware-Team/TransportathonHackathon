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
import { ActivatedRoute, Router } from '@angular/router';
import { HubConnection } from '@microsoft/signalr';
import { GetByUserResponse } from 'src/app/models/response-models/messages/getByUserResponse';
import { GetByReceiverAndSenderResponse } from 'src/app/models/response-models/messages/getByReceiverAndSenderResponse';
import { MessageService } from 'src/app/services/message.service';
import { SignalrService } from 'src/app/services/signalr.service';
import { TokenService } from 'src/app/services/token.service';
import { environment } from 'src/environments/environment';
import { Message } from 'src/app/models/domain-models/message';
import { faPaperPlane } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css'],
})
export class ChatComponent implements OnInit, AfterViewChecked {
  faPaperPlane = faPaperPlane;
  messages: GetByReceiverAndSenderResponse[];
  userId: string | undefined;
  connection: HubConnection;
  receiverId: string;
  users: GetByUserResponse[];
  disableScrollDown: boolean = false;
  index: number = 0;
  size: number = 20;
  messageForm: FormGroup;
  hasNext: boolean;
  getData: boolean = true;

  @ViewChild('scrollMe') myScrollContainer: ElementRef;

  constructor(
    private tokenService: TokenService,
    private messageService: MessageService,
    private signalRService: SignalrService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}

  async ngOnInit() {
    this.index = 0;
    this.createMessageForm();
    this.userId = this.tokenService.getUserWithJWT()?.id;
    await this.getConnection();
    this.messages = [];
    this.activatedRoute.params.subscribe({
      next: (params) => {
        this.receiverId = params['receiverId'];
        this.getMessages(0, 20);
      },
    });
    this.getUsers();
  }

  ngAfterViewChecked() {
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
    } catch (err) {}
  }

  async getConnection() {
    this.connection = await this.signalRService.startConnection(
      environment.baseUrl + 'messages'
    );

    this.connection.on('ReceiveMessage', (data: Message) => {
      this.getUsers();

      if (data.senderId != this.receiverId) return;

      this.messages.push({
        id: data.id,
        isRead: data.isRead,
        messageText: data.messageText,
        receiverId: data.receiverId,
        senderId: data.senderId,
        receiverUserName: data.receiver.userName,
        senderUserName: data.sender.userName,
        sendDate: data.sendDate,
      });

      this.disableScrollDown = false;
      this.scrollToBottom();
    });

    this.connection.on('MessageSended', (data: Message) => {
      this.getUsers();
      this.messages.push({
        id: data.id,
        isRead: data.isRead,
        messageText: data.messageText,
        receiverId: data.receiverId,
        senderId: data.senderId,
        receiverUserName: '',
        senderUserName: '',
        sendDate: data.sendDate,
      });

      this.disableScrollDown = false;
      this.scrollToBottom();
    });
  }

  getUsers() {
    this.messageService.getByUser(this.userId!).subscribe({
      next: (data) => {
        this.users = data;
      },
    });
  }

  getMessages(index: number, size: number) {
    if (!this.getData) return;
    this.getData = false;

    if (this.receiverId != null) {
      this.messageService
        .getByReceiverAndSender(this.receiverId, this.userId!, index, size)
        .subscribe({
          next: (data) => {
            this.messages = this.messages.reverse();
            if (this.messages == null || index == 0) this.messages = [];
            data.items.forEach((e) => {
              this.messages.push(e);
            });

            this.messages = this.messages.reverse();

            this.hasNext = data.hasNext;
            if (this.hasNext) this.index = data.index;
            this.getData = true;

            if (index == 0) {
              this.disableScrollDown = false;
              this.scrollToBottom();
            }
          },
          error: (error) => {},
        });
    }
  }

  async send() {
    let messageFormValue = Object.assign({}, this.messageForm.value);
    let message = messageFormValue.message;
    if (!this.messageForm.valid) return;

    await this.connection.invoke('SendMessage', this.receiverId, message);
    this.messageForm.reset();
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
    if (event.target.scrollTop <= 100 && this.hasNext) {
      if (
        this.messages.length * this.index >= this.size * this.index &&
        this.getData
      ) {
        this.getMessages(this.index + 1, this.size);
      }
    }
  }

  async changePage(userId: string) {
    this.index = 0;
    this.hasNext = false;
    this.messages = [];
    await this.router.navigateByUrl('/chat/' + userId);
    this.activatedRoute.params.subscribe({
      next: (params) => {
        this.receiverId = params['receiverId'];
        this.getMessages(0, 20);
      },
    });
  }
}
