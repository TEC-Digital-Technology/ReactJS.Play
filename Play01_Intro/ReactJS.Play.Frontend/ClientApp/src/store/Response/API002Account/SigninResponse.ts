import { ResponseBase } from "../ResponseBase";

export interface SigninResponse extends ResponseBase {
    type: "RESPONSE_ACCOUNT_SIGNIN";
    accessToken: string;
}