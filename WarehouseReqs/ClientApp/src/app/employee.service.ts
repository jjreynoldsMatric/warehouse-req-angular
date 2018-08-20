import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class EmployeeProvider {
  employees: any;
  whseEmployees: any;

  constructor(public http: HttpClient) { }

  loadEmployees() {
    return this.http.get("/api/employees");
  }

  loadWhseEmployees() {
      this.http.get("/api/employees/WhseEmployees").subscribe(response => {

      this.whseEmployees = response;

    });
  }
}
