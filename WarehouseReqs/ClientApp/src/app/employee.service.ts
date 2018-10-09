import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { takeUntil } from "rxjs/operators"

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
    return this.http.get("/api/employees/WhseEmployees");
  }
}
