import { Observable, Subject, observeOn } from "rxjs";
import { AccountClient } from "./AccountClient";
import { HttpClient } from "@angular/common/http";
import { environment } from "./commons";
import { Router } from "@angular/router";

export class LoginHelper{
    constructor(){}
    public _KEY_ : string = "SIMETRICA_TOKEN";
    public Token: string = "";
    public username: Subject<string> = new Subject<string>();
    public TokenObj: any = null;

    public SaveTokenObj(tokenObj:any) { 
        this.Token = tokenObj.token;
        this.TokenObj = tokenObj;
        this.username.next(tokenObj.username);
        localStorage.setItem(this._KEY_, JSON.stringify(tokenObj));
    }

    public LoadTokenObj():any
    {
        let temp = localStorage.getItem(this._KEY_);
        if(temp != null)
        {
            this.TokenObj = JSON.parse(temp);
            this.Token = this.TokenObj.token;
            this.username.next(this.TokenObj.username);
            return this.TokenObj;
        }

        return null;
    }

    public checkForLogin()
    {
        if(this.Token == "")
        {
            this.LoadTokenObj();
            let headers = {
                Authorization: `Bearer ${this.Token}`,
                'Content-Type': 'application/json'
            };
            fetch(environment.baseUrl + "account/is-authenticated",{headers} ).then((r)=> r.json()).then((r)=>{
                if(!r.success)
                {
                    window.location.pathname = "/login";
                }
            }).catch(r=> window.location.pathname = "/login");
        }
        else
        return;
        
    }
}