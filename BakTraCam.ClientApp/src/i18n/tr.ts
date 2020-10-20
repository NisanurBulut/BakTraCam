import { MatPaginatorIntl } from '@angular/material/paginator';

export const locale = {
    lang: 'tr',
    data: {
        'GENERAL': {
            'BACK_TO_FILTER': 'Filtreler',
            'ALL_OF': 'Tümü',
            'NONE_OF': 'Hiçbirisi',
            'THERE_IS': 'Var',
            'THERE_ISNT': 'Yok',
            'YES': 'Evet',
            'NO': 'Hayır',
            'CREATE': 'Yeni oluştur',
            'ADD': 'Ekle',
            'SAVE': 'Kaydet',
            'DELETE': 'Sil',
            'EDIT': 'Düzenle',
            'REMOVE': 'Kaldır',
            'VIEW': 'Görüntüle',
            'IGNORE': 'Yoksay',
            'FILTER': 'Filtrele',
            'ARE_U_SURE': 'Emin misiniz?',
            'YES_AM_SURE': 'Evet, eminim',
            'CANCEL': 'Vazgeç',
            'OK': 'Tamam',
            'WARNING': 'Uyarı',
            'WARNING!': 'Uyarı!',
            'ATTENTION': 'Dikkat',
            'ATTENTION!': 'Dikkat!',
            'CREATE_DATE': 'Oluşturulma Zamanı',
            'MODIFY_DATE': 'Düzenlenme Zamanı',
            'SEARCH': 'Ara...',
            'NO_RECORDS': 'Eşleşen kayıt bulunamadı',
            'HOUR': 'Saat',
            'MINUTE': 'Dakika',
            'ACTION_BUTTON_TEXT': 'İşlemler',
            'ADD_TO_SHORTCUT': 'Favorilere ekleyin/kaldırın',
            'EXPORT_EXCEL': 'Excel\'e aktar',
            'DOWNLOAD': 'İndir',
            'YEAR': 'Yıl',
            'MONTH': 'Ay',
            'GOTO_PAGE': 'Git...',
            'SUM': 'TOPLAM',
            'MESSAGES': {
                'ASK_FOR_CANCEL': 'Dikkat!',
                'ASK_FOR_CANCEL_MESSAGE': 'Çıkarsanız girdiğiniz veriler kaybolacak. Çıkmak istediğinizden emin misiniz?'
            }
        },
        'HOME': {
            'TITLE': 'Anasayfa',
        },
        'BAKIM': {
            'PLURAL': 'Bakımlar',
            'SINGULAR': 'Bakım',
            'VALIDATIONS': {
            },
            'MESSAGES': {
            }
        },
        'ENUMS': {
            'BakimTip': {
                'Planli': 'Planlı',
                'Talep': 'Talep',
                'Ariza': 'Arıza',
                'Periyodik': 'Periyodik',
            },
            'BakimPeriod': {
                'Gun': 'Gün',
                'BirHafta': 'Bir Hafta',
                'IkiHafta': 'İki Hafta',
                'UcHafta': 'Üç Hafta',
                'BirAy': 'Bir Ay',
                'IkiAy': 'İki Ay',
                'UcAy': 'Üç Ay',
                'AltiAy': 'Altı Ay',
                'BirSene': 'Bir Sene'
            },
            'BakimDurum': {
                'Beklemede': 'Bekliyor',
                'Tamamlandi': 'Tamamlandı',
                'Devam': 'Devam Ediyor',
                'Iptal': 'İptal',
            },
            'Unvan': {
                'Sorumlu': 'Sorumlu',
                'BakimElemani': 'Bakım Elemanı'
            }
        },
    }
};

const turkishRangeLabel = (pageIndex: number, pageSize: number, length: number) => {

    if (length <= 0 || pageSize <= 0) { return `Kayıt bulunamadı.`; }

    const lastPage = Math.ceil(length / pageSize);

    return `${pageIndex + 1} / ${lastPage}`;
};

export function getTurkishPaginatorIntl(): MatPaginatorIntl {
    const paginatorIntl = new MatPaginatorIntl();

    paginatorIntl.itemsPerPageLabel = 'Sayfa başına kayıt:';
    paginatorIntl.nextPageLabel = 'Sonraki';
    paginatorIntl.previousPageLabel = 'Önceki';
    paginatorIntl.firstPageLabel = 'İlk Sayfa';
    paginatorIntl.lastPageLabel = 'Son Sayfa';
    paginatorIntl.getRangeLabel = turkishRangeLabel;

    return paginatorIntl;
}
