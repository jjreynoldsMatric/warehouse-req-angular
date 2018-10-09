import { Component, OnInit, Input } from "@angular/core";

import { FormGroup, FormBuilder, Validators, FormArray } from "@angular/forms";

import { ArrayType } from "@angular/compiler/src/output/output_ast";


import { Requisition } from "../../../models/models";
import { RequisitionItem } from "../../../models/requisitionItem";
import { ngxZendeskWebwidgetService } from "ngx-zendesk-webwidget";
import { EmployeeProvider } from "../employee.service";
import { ReasonCodesProvider } from "../reason-codes.service";
import { RequisitionProvider } from "../requisition.service";
import { ActivatedRoute, Router } from "@angular/router";
import { forEach } from "@angular/router/src/utils/collection";
import { takeUntil } from "rxjs/operators"
import { Subject } from "rxjs"

@Component({
  selector: "app-edit",
  templateUrl: "./edit.component.html",
  styleUrls: ["./edit.component.css"]
})
export class EditComponent implements OnInit {

  reasonCode: string;
  @Input() itemsArray: ArrayType[];
  itemReqId: number;
  newReqForm: FormGroup;
  index: number;
  requisition: Requisition;
  empIndex: number;
  empDept: any;
  employee: any;
  errorMessage: string;
  newForm: FormGroup;
  arrayControl: any;
  editReq: any;
  editRI: RequisitionItem[];
  jobValid: any;
  private _destroyed$ = new Subject();

  constructor(private employeeService: EmployeeProvider, private reasonCodesService: ReasonCodesProvider, private fb: FormBuilder, private reqService: RequisitionProvider, private _ngxZendeskWebwidgetService: ngxZendeskWebwidgetService, private route: ActivatedRoute, public router: Router) {
    this.itemsArray = [];
    this.requisition = new Requisition;
    this.requisition.requisitionItem = new Array<RequisitionItem>();
    _ngxZendeskWebwidgetService.show();
  }

  ngOnInit() {
    this.employeeService.loadEmployees();
    this.reasonCodesService.loadReasonCodes();
    this.itemReqId = +this.route.snapshot.paramMap.get("ReqId");

    this.reqService.getRequisition(this.itemReqId).subscribe(response => {
      this.editReq = response;
      //console.log("EDIT REQ VVV");
      //console.log(this.editReq);
      this.editRI = this.editReq.requisitionItem;
      this.newForm = this.fb.group({
        employee: [this.editReq.employee, Validators.required],
        job: [this.editReq.job, Validators.compose([Validators.pattern("^[0-9]+$")])],
        requisitionItem: this.fb.array([

        ])
      });
      this.arrayControl = <FormArray>this.newForm.controls["requisitionItem"];
      this.editRI.forEach(item => {
        let newItem = this.fb.group({
          item: [item.item, Validators.required],
          quantity: [item.quantity, Validators.compose([Validators.required, Validators.pattern("^-{0}[0-9]+\.?[0-9]*$")])],
          reasonCode: [item.reasonCode],
          operation: [item.operation],

        });

        this.arrayControl.push(newItem);
        this.setValidators();
      });
      for (let i = 0; i < this.arrayControl.length; i++) {
        this.arrayControl.controls[i].get("reasonCode").setValue(this.editRI[i].reasonCode);
      }
      this.setValidators();
      //console.log(this.editReq);
      this.newReqForm = this.newForm;
      takeUntil(this._destroyed$);

    });
  }

  public ngOnDestroy(): void {
    this._destroyed$.next();
  }

  openFeedback() {
    this._ngxZendeskWebwidgetService.activate();
  }

  setValidators() {
    if (this.newForm.controls["job"].value === "" || this.newForm.controls["job"].value === null) {
      for (let i = 0; i < this.arrayControl.length; i++) {
        this.arrayControl.controls[i].get("operation").disable();
        this.arrayControl.controls[i].get("reasonCode").enable();
        this.arrayControl.controls[i].get("reasonCode").setValidators(Validators.required);
      }
    }
    else {
      for (let i = 0; i < this.arrayControl.length; i++) {
        this.arrayControl.controls[i].get("operation").enable();
        this.arrayControl.controls[i].get("operation").setValidators(Validators.required);
        this.arrayControl.controls[i].get("reasonCode").disable();
      }
    }
    this.newForm.controls["job"].valueChanges.subscribe(() => {
      if (this.newForm.controls["job"]) {

        for (let i = 0; i < this.arrayControl.length; i++) {
          this.arrayControl.controls[i].get("operation").enable();
          this.arrayControl.controls[i].get("operation").setValidators(Validators.required);
          this.arrayControl.controls[i].get("reasonCode").disable();
        }
      }

      if (this.newForm.controls["job"].value == "") {
        console.log("NO JOB");
        for (let i = 0; i < this.arrayControl.length; i++) {
          this.arrayControl.controls[i].get("operation").disable();
          this.arrayControl.controls[i].get("reasonCode").enable();
          this.arrayControl.controls[i].get("reasonCode").setValidators(Validators.required);
        }
      }
    });
  }

  initItems() {

    return this.fb.group({
      item: ["", Validators.required],
      quantity: ["", Validators.required],
      lot: [""],
      reasonCode: ["", Validators.required],
      operation: [{ value: "", disabled: true }],
    });

  }

  initJobItems() {

    return this.fb.group({
      item: ["", Validators.required],
      quantity: ["", Validators.required],
      lot: [""],
      reasonCode: [{ value: "", disabled: true }],
      operation: ["", Validators.required],
    });

  }

  addItem() {
    console.log("Adding an item!");
    if (this.newForm.controls["job"].value !== "") {
      console.log("JOB ITEM");
      this.arrayControl.push(this.initJobItems());
    }
    else {
      console.log("NORMAL ITEM");
      this.arrayControl.push(this.initItems());
    }

  }
  getFormData() {
    this.requisition.id = this.editReq.id;
    this.requisition.employee = this.editReq.employee;
    this.requisition.department = this.editReq.department;

    if (this.newReqForm.controls.job.value === null || this.newReqForm.controls.job.value === undefined) {
      this.requisition.job = null;
    }
    else {
      this.requisition.job = this.newReqForm.controls.job.value;
    }
    this.requisition.filled = false;
    let reqitems = <FormArray>this.newReqForm.controls["requisitionItem"];

    for (var i = 0; i < reqitems.length; i++) {
      this.requisition.requisitionItem[i] = new RequisitionItem;
      this.requisition.requisitionItem[i].item = reqitems.at(i).value.item;
      this.requisition.requisitionItem[i].filled = this.editRI[i].filled;
      this.requisition.requisitionItem[i].operation = reqitems.at(i).value.operation;
      this.requisition.requisitionItem[i].quantity = reqitems.at(i).value.quantity;
      this.requisition.requisitionItem[i].quantityFilled = this.editRI[i].quantityFilled;
      this.requisition.requisitionItem[i].reasonCode = reqitems.at(i).value.reasonCode;
      this.requisition.requisitionItem[i].id = this.editRI[i].id;
    }

  }

  submit() {
    this.getFormData();

    console.log(this.requisition);
    this.reqService.updateRequisition(this.requisition).subscribe(response => {
      console.log("Should have PATCHED the req");
      let id = this.requisition.id;
      this.router.navigate(["/manage", id]);
      takeUntil(this._destroyed$);

    }, err => {
      this.errorMessage = err.error;
      takeUntil(this._destroyed$);

    });

    this.reqService.loadRequisitions();
  }
  onSelectChange(employee) {
    let index = this.empIndex;
    console.log(`ONSELECTCHANGE INDEX${index}`);
  }

  onRemove(index) {
    let reqItemId = this.editReq.requisitionItem[index].id;
    let reqId = this.editReq.id;
    let data = { reqId, reqItemId };
    //console.log(reqId);
    //console.log(reqItemId);

    this.router.navigate(["/confirm-remove-item", reqId, reqItemId]);


  }

  cancel() {

    this.router.navigate(["/manage", this.itemReqId]);
  }

  enterJob(job: string) {

    if (job) {
      this.reqService.isJobValid(job).subscribe(res => {
        if (res === true) {
          this.jobValid = "";
        }
        else if (res === false) {
          this.jobValid = "Please enter a valid, released job";
        }
        else {
          this.jobValid = "Uh something went wrong";
        }
        takeUntil(this._destroyed$);

      }, err => {
        this.jobValid = err;
        takeUntil(this._destroyed$);

      }
      );
    }

  }

}
