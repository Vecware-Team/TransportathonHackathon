export interface RefreshToken {
  id: number;
  userId: number;
  token: string;
  expireTime: Date;
}
