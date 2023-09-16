import { EventEmitter, Injectable, Output } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CommentStoreService {
  @Output() createCommentEventStore = new EventEmitter<string>();
  constructor() {}

  createCommentEvent(transportRequestId: string) {
    this.createCommentEventStore.emit(transportRequestId);
  }
}
