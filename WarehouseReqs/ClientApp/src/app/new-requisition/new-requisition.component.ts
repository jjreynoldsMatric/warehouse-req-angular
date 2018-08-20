import { Component, OnInit, Input } from "@angular/core";
import { ngxZendeskWebwidgetService } from "ngx-zendesk-webwidget";
import { EmployeeProvider } from "../employee.service";
import { ReasonCodesProvider } from "../reason-codes.service";
import { RequisitionProvider } from "../requisition.service";
import { FormGroup, FormBuilder, Validators, FormArray } from "@angular/forms";
import { Requisition, RequisitionItem } from "../../../models/models";
import { ArrayType } from "@angular/compiler/src/output/output_ast";
import { Router } from "@angular/router";


@Component({
    selector: "app-new-requisition",
    templateUrl: "./new-requisition.component.html",
    styleUrls: ["./new-requisition.component.css"]
})
export class NewRequisitionComponent implements OnInit {
    @Input() itemsArray: ArrayType[];
    newReqForm: FormGroup;
    index: number;
    requisition: Requisition;
    empIndex: number;
    empDept: any;
    employee: any;
    errorMessage: string;
    newForm: FormGroup;
    arrayControl: any;
    employees: any;
    jobValid: any;

    constructor(private employeeService: EmployeeProvider, private reasonCodesService: ReasonCodesProvider, private fb: FormBuilder, private reqService: RequisitionProvider, private _ngxZendeskWebwidgetService: ngxZendeskWebwidgetService, public router: Router) {
        this.itemsArray = [];
        this.requisition = new Requisition;
        this.requisition.requisitionItem = new Array<RequisitionItem>();

        _ngxZendeskWebwidgetService.show();
    }

    ngOnInit() {

        this.newForm = this.fb.group({
            employee: ["", Validators.required],
            job: ["", Validators.compose([Validators.pattern("^[0-9]+$")])],
            requisitionItems: this.fb.array([
                this.initItems(),

            ])
        });
        this.arrayControl = <FormArray>this.newForm.controls["requisitionItems"];
        this.itemsArray.forEach(item => {
            let newItem = this.fb.group({
                item: ["", Validators.required],
                quantity: ["", Validators.compose([Validators.required, Validators.min(0), Validators.pattern("^[0-9]+$")])],
                reasonCode: ["", Validators.required],
                operation: [{ value: "", disabled: true }],
            });
          this.arrayControl.push(newItem);

        });
        this.setValidators();


        //console.log(this.arrayControl);

        this.newReqForm = this.newForm;
        this.employeeService.loadEmployees().subscribe(response => {

            this.employees = response;
            //console.log(this.employees)
        });;
        this.reasonCodesService.loadReasonCodes();
    }


    setValidators() {
        this.newForm.controls["job"].valueChanges.subscribe(() => {
            if (this.newForm.controls["job"]) {

                for (let i = 0; i < this.arrayControl.length; i++) {
                    this.arrayControl.controls[i].get("operation").enable();
                    this.arrayControl.controls[i].get("operation").setValidators(Validators.compose([Validators.pattern("^[0-9]+$"), Validators.required]));
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
    removeItem(index: number) {

        this.arrayControl.removeAt(index);
    }

    getFormData() {
        this.requisition.employee = this.newReqForm.get("employee").value.empFull;
        this.requisition.department = this.newReqForm.get("employee").value.empDept;
        this.requisition.job = this.newReqForm.controls.job.value;

        let reqitem = <FormArray>this.newReqForm.controls["requisitionItems"];
        this.requisition.requisitionItem = reqitem.value;
        for (let i = 0; i < reqitem.length; i++) {
            this.requisition.requisitionItem[i].item = reqitem.at(i).value.item;
            this.requisition.requisitionItem[i].quantity = reqitem.at(i).value.quantity;
            if (reqitem.at(i).value.lot === null) {
                this.requisition.requisitionItem[i].lot = 0;
            }

            this.requisition.requisitionItem[i].reasonCode = reqitem.at(i).value.reasonCode;
            if (reqitem.at(i).value.Operation === null) {
                this.requisition.requisitionItem[i].operation = 0;
            }
            else {
                this.requisition.requisitionItem[i].operation = reqitem.at(i).value.operation;
            }

        }
    }

    submit() {
        this.getFormData();
        console.log(this.requisition);
      this.reqService.saveRequisition(this.requisition).subscribe(response => {
            console.log("Should have posted the req");
            this.router.navigate(["/open-requisitions"]);
        }, err => {
            this.errorMessage = err.error;
        });

        this.reqService.loadRequisitions();
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
            }, err => {
                this.jobValid = err;
            }
            );
        }

    }
}
