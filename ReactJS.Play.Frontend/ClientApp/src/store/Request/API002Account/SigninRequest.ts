export interface SigninRequest {
    type: 'REQUEST_ACCOUNT_SIGNIN';
    account: string;
    password: string;
}