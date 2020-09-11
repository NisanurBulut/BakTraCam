import { DatePipe } from '@angular/common';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PostResult } from 'app/models';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs/Observable';
import { finalize, map } from 'rxjs/operators';



@Injectable()
export class BaseService {
    public baseUrl = environment.apiBaseUrl;

    constructor( public http: HttpClient) {
    }
    protected getAll<T>(url: string): Observable<T[]> {
        return this.http.get<T[]>(this.baseUrlUpdate(url)).pipe(
            finalize(() => {
            })
        );
    }

    protected get<T>(url: string, id: number): Observable<T> {
        return this.http.get<T>(this.baseUrlUpdate(url), {
            params: new HttpParams().set('id', id.toString())
        }).pipe(
            finalize(() => {
            })
        );
    }

    protected getOnly<T>(url: string, params = new HttpParams()): Observable<T> {
        console.log('getonly');
        return this.http.get<T>(this.baseUrlUpdate(url), { params: params }).pipe(
            map((response: T) => {
                return response;
            }),
            finalize(() => {
            })
        );
    }

    protected delete(url: string): Observable<string> {
        return this.http.get(this.baseUrlUpdate(url)).pipe(
            map((response: { success: boolean }) => {
                if (response.success) {
                    return 'OK';
                }
            }),
            finalize(() => {
            })
        );
    }

    protected getWithoutParams<T>(url: string): Observable<T> {
        return this.http.get<T>(this.baseUrlUpdate(url)).pipe(
            finalize(() => {
            })
        );
    }

    protected getWithExternalParams<T>(url: string, params: HttpParams): Observable<T> {
        return this.http.get<T>(this.baseUrlUpdate(url), {
            params: params
        }).pipe(
            finalize(() => {
            })
        );
    }

    protected setValue<T>(url: string, objectId: number, propertyName: string, value: any): Observable<any> {
        return this.http.post(this.baseUrlUpdate(url), { Id: objectId, PropertyName: propertyName, Value: value })
            .pipe(
                map((response: HttpResponse<any>) => {
                    if (response.ok) {
                        return value;
                    }
                }),
                finalize(() => {
                })
            );
    }

    protected postValue<T>(url: string, object: T): Observable<PostResult> {
        return this.http.post(this.baseUrlUpdate(url), object)
            .pipe(
                map((response: PostResult) => {
                    return response;
                }),
                finalize(() => {
                })
            );
    }

    protected deleteValue(url: string): Observable<PostResult> {

        return this.http.delete(this.baseUrlUpdate(url))
            .pipe(
                map((response: PostResult) => {
                    return response;
                }),
                finalize(() => {
                })
            );
    }

    protected baseUrlUpdate(url: string): string {
        return (url.startsWith('/')) ? this.baseUrl + url : url;
    }
}
