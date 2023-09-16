export interface GetByReceiverAndSenderResponse {
  id: string;
  senderId: string;
  receiverId: string;
  messageText: string;
  sendDate: Date;
  isRead: boolean;
  senderUserName: string | null;
  receiverUserName: string | null;
}
