import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class ReasonCodesProvider {
  reasonCodes: any;
  constructor(public http: HttpClient) { }

  loadReasonCodes() {
    this.http.get("/api/reasoncodes").subscribe(response => {
      this.reasonCodes = response;
      //console.log(this.reasonCodes);

    });
  }

}
