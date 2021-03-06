import { Component, Input, OnInit } from "@angular/core";
import { EmployeeProvider } from "../employee.service";
import { ItemsProvider } from "../items.service";
import { RequisitionProvider } from "../requisition.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { PartRequest } from "../../../models/partRequest";
import { Requisition, Employee } from "../../../models/models";
import { Router, ActivatedRoute } from "@angular/router";
import { takeUntil } from "rxjs/operators"
import { Subject } from "rxjs"

@Component({
  selector: "app-create-shortage",
  templateUrl: "./create-shortage.component.html",
  styleUrls: ["./create-shortage.component.css"]
})
export class CreateShortageComponent implements OnInit {
  @Input() employees: Employee[];

  reqId: any;
  reqItemId: any;
  reqItem: any;
  chosenLocation: any;
  employee: any;
  error: any;
  partRequest: PartRequest;
  issuePartsForm: FormGroup;
  shortageLocs: any;
  whseEmployees: any;
  private _destroyed$ = new Subject();


  constructor(private employeeService: EmployeeProvider, private itemsService: ItemsProvider, private reqService: RequisitionProvider, private fb: FormBuilder, private route: ActivatedRoute, public router: Router) {

  }


  ngOnInit() {
    this.reqItemId = +this.route.snapshot.paramMap.get("ReqItemId");
    this.reqId = +this.route.snapshot.paramMap.get("ReqId");

    console.log("LOAD STUFF FIRED");
    this.reqService.getRequisitionItem(this.reqItemId).subscribe(data => {
      this.reqItem = data;
      console.log(this.reqItem);
      takeUntil(this._destroyed$);

    });
    console.log("SHORTAGE LOCS VVV");
    this.itemsService.loadShortageLocations(this.reqItemId).subscribe(res => {
      this.shortageLocs = res;

      console.log(this.shortageLocs);
      console.log("SHORTAGE LOCS ^");
      takeUntil(this._destroyed$);

    });
    this.employeeService.loadWhseEmployees().subscribe(response => {
      this.whseEmployees = response;
      takeUntil(this._destroyed$);

    });


    this.partRequest = new PartRequest;
    this.issuePartsForm = this.fb.group({
      employee: ["", Validators.required],
      quantity: ["", Validators.compose([Validators.required, Validators.pattern("^-{0}[0-9]+\.?[0-9]*$")])],
      location: ["", Validators.required]
    });
  }

  public ngOnDestroy(): void {
    this._destroyed$.next();
  }

  getFormData() {
    this.partRequest.itemReqId = this.reqItemId;
    this.partRequest.processedBy = this.issuePartsForm.get("employee").value;
    this.partRequest.quantity = this.issuePartsForm.get("quantity").value;
    this.partRequest.location = this.issuePartsForm.get("location").value.location;
    this.partRequest.lot = null;

    console.log(this.partRequest);
  }

  createShortage() {
    this.getFormData();
    console.log(this.partRequest);
    this.reqService.createShortage(this.partRequest).subscribe(response => {
      console.log("Created Shortage");
      this.router.navigate(["/manage", this.reqId]);
      takeUntil(this._destroyed$);

    });

  }

  cancel() {
    this.router.navigate(["/manage", this.reqId]);

  }

}
