import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiRootConfig } from "../apiconfig/apiconfig";
import { IUser } from "../login/login";

@Injectable({
    providedIn: 'root'
  })

export class ProfileService {


    private userUrl:string = " ";
    
    constructor(private http: HttpClient,
                config:ApiRootConfig) {
                    this.userUrl = config.rootUrl + '/api/user';
                }


    getUserDetail(uid : any ) : Observable<IUser> {
        return this.http.get<IUser>(this.userUrl + "/" + uid);

    }
}