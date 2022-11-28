export class AuthToken {
    payload: any = null;
    constructor(protected readonly token: any,
        protected createdAt?: Date) {

    }

    getValue() {
        return this.token.access_token;
    }

    getRefreshToken(): string {
        return this.token.refresh_token;
    }
    setRefreshToken(refreshToken: string) {
        this.token.refresh_token = refreshToken;
    }
    getCreatedAt(): Date {
        return this.createdAt;
    }
    toString(): string {
        return JSON.stringify(this.token);
    }
    isValid(): boolean {
        return (!this.getTokenExpDate() || new Date() < this.getTokenExpDate());
    }
    getTokenExpDate(): Date {
        if (!this.token.hasOwnProperty('expires_in')) {
            return null;
        }
        return new Date(this.createdAt.getTime() + Number(this.token.expires_in) * 1000);
    }

}