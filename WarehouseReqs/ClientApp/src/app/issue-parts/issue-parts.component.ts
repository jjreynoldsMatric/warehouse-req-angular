import { Component, OnInit } from "@angular/core";
import { PartRequest } from "../../../models/partRequest";
import { FormGroup, FormBuilder, Validators } from "../../../node_modules/@angular/forms";
import { EmployeeProvider } from "../employee.service";
import { ItemsProvider } from "../items.service";
import { RequisitionProvider } from "../requisition.service";
import { ngxZendeskWebwidgetService } from "../../../node_modules/ngx-zendesk-webwidget";
import { ActivatedRoute, Router } from "@angular/router";
import { takeUntil } from "rxjs/operators"
import { Subject } from "rxjs"


@Component({
  selector: "app-issue-parts",
  templateUrl: "./issue-parts.component.html",
  styleUrls: ["./issue-parts.component.css"]
})
export class IssuePartsComponent implements OnInit {
  reqItem: any;
  chosenLocation: any;
  employee: any;
  error: any;
  partRequest: PartRequest;
  issuePartsForm: FormGroup;
  lots: any;
  reqItemId: number;
  reqId: number;
  whseEmployees: any;
  private _destroyed$ = new Subject();

  constructor(private employeeService: EmployeeProvider, private itemsService: ItemsProvider, private reqService: RequisitionProvider, private fb: FormBuilder, private _ngxZendeskWebwidgetService: ngxZendeskWebwidgetService, private route: ActivatedRoute, public router: Router) {
    _ngxZendeskWebwidgetService.show();
    this.partRequest = new PartRequest;
  }
  openFeedback() {
    this._ngxZendeskWebwidgetService.activate();
  }
  ngOnInit() {
    this.reqItemId = +this.route.snapshot.paramMap.get("ReqItemId");
    this.reqId = +this.route.snapshot.paramMap.get("ReqId");
    this.reqService.getRequisitionItem(this.reqItemId).subscribe(data => {
      this.reqItem = data;
      console.log(this.reqItem);
      takeUntil(this._destroyed$);
    });
    this.itemsService.loadLocationsWithLot(this.reqItemId).subscribe(data => {
      this.lots = data;
      takeUntil(this._destroyed$);
    });
    this.employeeService.loadWhseEmployees().subscribe(response => {
      this.whseEmployees = response;
      takeUntil(this._destroyed$);

    });


    this.issuePartsForm = this.fb.group({
      employee: ["", Validators.required],
      quantity: ["", Validators.compose([Validators.required, Validators.pattern("^-{0}[0-9]+\.?[0-9]*$")])],
      location: ["", Validators.required]
    });

  }

  public ngOnDestroy(): void {
    this._destroyed$.next();
  }

  issueParts() {
    this.partRequest.processedBy = this.issuePartsForm.get("employee").value;
    this.partRequest.quantity = this.issuePartsForm.get("quantity").value;
    this.partRequest.location = this.issuePartsForm.get("location").value.location;
    this.partRequest.lot = this.issuePartsForm.get("location").value.lot;
    this.partRequest.itemReqId = this.reqItemId;

    console.log(this.partRequest);
    this.reqService.issueParts(this.partRequest).subscribe(response => {
      this.router.navigate(["/manage", this.reqId]);
      takeUntil(this._destroyed$);

    }, err => {
      this.error = err;
      takeUntil(this._destroyed$);

    });
  }

  cancel() {
    this.router.navigate(["/manage", this.reqId]);
  }

}
