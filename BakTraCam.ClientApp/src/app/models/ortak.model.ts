


export interface Base {
    Id: number;
    Olusturan: string;
    OlusturmaZamani: Date;
    Degistiren: string;
    DegistirmeZamani: Date;
}

export interface BasicBase {
    Id: number;
}

export interface SoftDelete {
    AktifMi: true;
}

export interface EditObjectInArray<T> {
    Index: number;
    Object: T;
}

export interface Select {
    Key: any;
    Name: string;
    Group: string;
}
