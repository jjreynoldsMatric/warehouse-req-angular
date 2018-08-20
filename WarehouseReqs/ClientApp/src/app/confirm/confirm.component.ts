import { Component, OnInit } from "@angular/core";
import { RequisitionProvider } from "../requisition.service";
import { Requisition } from "../../../models/models";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
    selector: "app-confirm",
    templateUrl: "./confirm.component.html",
    styleUrls: ["./confirm.component.css"]
})
export class ConfirmComponent implements OnInit {
    req: Requisition;
    reqId: any;
    errorMessage: any;
    constructor(public reqService: RequisitionProvider, private route: ActivatedRoute, public router: Router) { }

    ngOnInit() {
        this.reqId = +this.route.snapshot.paramMap.get("ReqId");
    }

    confirm() {
        this.reqService.deleteReq(this.reqId).subscribe(response => {
            console.log(`Deleted Req: ${this.reqId}`);
            this.router.navigate(["/open-requisitions"]);
        }, err => {
            this.errorMessage = err;
            console.error("Could not delete the req");
        });

    }

    cancel() {
        this.router.navigate(["/manage", this.reqId]);

    }


}

