import { Entity } from 'src/app/core/models/entity';
import { AppUser } from './appUser';

export interface Message extends Entity<string> {
  senderId: string;
  receiverId: string;
  messageText: string;
  sendDate: Date;
  isRead: boolean;
  sender: AppUser;
  receiver: AppUser;
}
