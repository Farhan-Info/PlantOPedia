import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { ApiRootConfig } from "../apiconfig/apiconfig";
import { IProduct } from "./product";

@Injectable({
    providedIn:'root'
})
export class ProductService{
   
    
  private productUrl:string = '';
  private productTypeUrl: string = '';

  constructor(private http:HttpClient,
              config: ApiRootConfig){
                this.productUrl = config.rootUrl + '/api/product';
                this.productTypeUrl = config.rootUrl + '/api/productType';
              }

    getProducts() : Observable <IProduct[]> {
        return this.http.get<IProduct[]>(this.productUrl);
    }

  getProductTypes(): Observable<any> {
    return this.http.get<any>(this.productTypeUrl);
  }
    
    getProductById(pid : any ) : Observable<IProduct> {
        return this.http.get<IProduct>(this.productUrl + "/" + pid);

    }

    updateProduct(pid :any ,product : any) : Observable <any> {
        return this.http.put<any>(this.productUrl + "/" + pid, product );
    }

    deleteProduct(pid: any) :Observable <any> {
        return this.http.delete<any>(this.productUrl + "/" + pid);
    }

    
    addproduct(value: any):Observable <IProduct> {
      return this.http.post<IProduct>(this.productUrl, value);
    }
}
