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
    BirHafta = 2,
    IkiHafta = 3,
    UcHafta = 4,
    BirAy = 5,
    IkiAy = 6,
    UcAy = 7,
    AltiAy = 8,
    BirSene = 9
}
export enum BakimTip {
    Planli = 1,
    Talep = 2,
    Ariza = 3,
    Periyodik = 4
}
export enum BakimDurum {
    Planlandi = 1,
    Tamamlandi = 2,
    Iptal = 3,
    Devam = 4
}
