export enum EnumCategory {
    Unvan,
    BakimPeriod,
    BakimDurum,
    BakimTip
}
export enum Unvan {
    Sorumlu = 1,
    BakimElemani = 2
}
export enum BakimPeriod {
    Gun = 1,
    BirHafta = 7,
    IkiHafta = 14,
    UcHafta = 21,
    BirAy = 29,
    IkiAy = 60,
    UcAy = 90,
    AltiAy = 180,
    BirSene = 365
}
export enum BakimTip {
    Planli = 1,
    Talep = 2,
    Ariza = 3,
    Periyodik = 4
}
export enum BakimDurum {
    Beklemede = 1,
    Tamamlandi = 2,
    Iptal = 3,
    Devam = 4
}
