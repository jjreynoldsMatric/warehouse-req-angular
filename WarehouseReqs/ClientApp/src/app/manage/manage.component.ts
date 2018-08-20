import { Component, OnInit, Input } from "@angular/core";
import { ngxZendeskWebwidgetService } from "ngx-zendesk-webwidget";
import { RequisitionProvider } from "../requisition.service";
import { ReasonCode, ItemLocViewModel, Employee, Requisition, Item } from "../../../models/models";
import { ActivatedRoute, Router } from "@angular/router";

import { IssuePartsComponent } from "../issue-parts/issue-parts.component";
@Component({
    selector: "app-manage",
    templateUrl: "./manage.component.html",
    styleUrls: ["./manage.component.css"]
})
export class ManageComponent implements OnInit {

    @Input() requesition: Requisition;


    req: any;
    employee: Employee;
    items: Item[];
    locations: ItemLocViewModel;
    today: number;
    reasonCode: ReasonCode;
    ReqId: any;
    sub: any;


    constructor(public reqService: RequisitionProvider, private _ngxZendeskWebwidgetService: ngxZendeskWebwidgetService, private route: ActivatedRoute, public router: Router) {
        _ngxZendeskWebwidgetService.show();
    }

    ngOnInit() {
        this.ReqId = +this.route.snapshot.paramMap.get("ReqId");
        //console.log(this.route.snapshot.paramMap.keys);
        //console.log(this.ReqId);
        this.reqService.getRequisition(this.ReqId).subscribe(data => {
            this.req = data;
            //console.log("***************************")
            //console.log(this.req)
            //console.log("***************************")

        });

    }
    openFeedback() {
        this._ngxZendeskWebwidgetService.activate();
    }

    issueParts(item) {
        let id = item.id;
        //console.log("THIS IS THE REQ" + id);
        this.router.navigate(["/issue-parts", this.ReqId, id]);
    }

    createShortage(item) {
        let id = item.id;
        //console.log("THIS IS THE REQ" + id);
        this.router.navigate(["/create-shortage", this.ReqId, id]);
    }

    edit(req) {
        this.router.navigate(["/edit", this.ReqId]);
    }

    delete() {
        this.router.navigate(["/confirm", this.ReqId]);
    }
}
