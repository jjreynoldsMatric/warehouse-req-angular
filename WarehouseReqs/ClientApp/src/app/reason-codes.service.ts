import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { takeUntil } from "rxjs/operators"

@Injectable({
  providedIn: "root"
})
export class ReasonCodesProvider {
  reasonCodes: any;
  constructor(public http: HttpClient) { }

  loadReasonCodes() {
    return this.http.get("/api/reasoncodes");
  }

}
