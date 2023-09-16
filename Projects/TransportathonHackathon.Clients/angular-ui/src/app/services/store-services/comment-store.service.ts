import { EventEmitter, Injectable, Output } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CommentStoreService {
  transportRequestId: string;
  constructor() {}

  createCommentEvent(transportRequestId: string) {
    this.transportRequestId = transportRequestId;
  }
}
