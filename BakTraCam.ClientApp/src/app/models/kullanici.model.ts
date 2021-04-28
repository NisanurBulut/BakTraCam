import { BasicBase } from './ortak.model';

export interface KullaniciModelBasic extends BasicBase {
    Ad: string;
    Unvan: string;
}

export interface KullaniciModel extends BasicBase {
    Ad: string;
    UnvanId: number;
}
