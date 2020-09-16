export interface BakimModel {
    Id: number,
    Aciklama: string,
    Ad: string,
    Gerceklestiren1: number,
    Gerceklestiren2: number,
    Gerceklestiren3: number,
    Gerceklestiren4: number,
    Sorumlu1: number,
    Sorumlu2: number,
    Tarihi: Date,
    BaslangicTarihi: Date;
    BitisTarihi: Date;
    Durum: number,
    Period: number,
    Tip: number
}
export interface BakimModelBasic {
    Id: number,
    Aciklama: string,
    Ad: string,
    Gerceklestiren1: string,
    Gerceklestiren2: string,
    Gerceklestiren3: string,
    Gerceklestiren4: string,
    Sorumlu1: string,
    Sorumlu2: string,
    Tarihi: Date,
    Durum: number,
    Period: number,
    Tip: number
}
