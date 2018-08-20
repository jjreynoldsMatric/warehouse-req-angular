import { Component, OnInit } from "@angular/core";
import { PartRequest } from "../../../models/partRequest";
import { FormGroup, FormBuilder, Validators } from "../../../node_modules/@angular/forms";
import { EmployeeProvider } from "../employee.service";
import { ItemsProvider } from "../items.service";
import { RequisitionProvider } from "../requisition.service";
import { ngxZendeskWebwidgetService } from "../../../node_modules/ngx-zendesk-webwidget";
import { ActivatedRoute, Router } from "@angular/router";

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
    reqItemId: any;
    reqId: any;

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
            //console.log(this.reqItem);
        });
        this.itemsService.loadLocationsWithLot(this.reqItemId).subscribe(data => {
            this.lots = data;
        });
        this.employeeService.loadWhseEmployees();


        this.issuePartsForm = this.fb.group({
            employee: ["", Validators.required],
            quantity: ["", Validators.compose([Validators.required, Validators.pattern("^[0-9]+$")])],
            location: ["", Validators.required]
        });

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
        }, err => {
            this.error = err;
        });
    }

    cancel() {
        this.router.navigate(["/manage", this.reqId]);
    }

}
