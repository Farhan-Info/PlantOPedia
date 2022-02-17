import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiRootConfig } from "../apiconfig/apiconfig";
import { IOrder } from "./order";

@Injectable({
  providedIn: 'root'
})
export class Orderservice_api {

  private orderUrl:string = " ";
  constructor(private http: HttpClient,
               config: ApiRootConfig) {
                this.orderUrl = config.rootUrl + '/api/order';
                }

  getOrders(): Observable<IOrder[]> {
    return this.http.get<IOrder[]>(this.orderUrl)
  }
  getOrdersByUserId(uid: any): Observable<IOrder[]> {
    return this.http.get<IOrder[]>(this.orderUrl+"/"+uid);
  }

  addOrder(order: any): Observable<IOrder[]>{
    return this.http.post<IOrder[]>(this.orderUrl, order);
  }

  deleteOrder(OrderId: any): Observable<any> {
    return this.http.delete(this.orderUrl + "/" + OrderId);
}


}
