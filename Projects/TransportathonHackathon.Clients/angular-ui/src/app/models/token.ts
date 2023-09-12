import { RefreshToken } from './refreshToken';
import { TokenModel } from './tokenModel';

export interface Token {
  refreshToken: RefreshToken;
  accessToken: TokenModel;
}
