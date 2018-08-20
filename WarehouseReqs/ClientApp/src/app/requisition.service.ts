import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { PartRequest } from "../../models/partRequest";

@Injectable({
    providedIn: "root"
})
export class RequisitionProvider {

    req: any;
    requisitions: Object;
    errorMessage: string;

    constructor(public http: HttpClient) { }

    loadRequisitions() {
        return this.http.get("/api/requisitions/all");
    }
    getRequisition(itemReqId) {
        //let params = new HttpParams().set("itemReqId", itemReqId);
        return this.http.get(`/api/requisitions/${itemReqId}`);

    }
    getRequisitionItem(reqItemId) {
        return this.http.get(`/api/requisitions/items/${reqItemId}`);
    }
    saveRequisition(requisition) {
        return this.http.post("/api/requisitions/save", requisition);
    }

    createShortage(partRequest: PartRequest) {
        return this.http.post("/api/requisitions/shortage", partRequest);
    }

    issueParts(partRequest: PartRequest) {
        return this.http.post("/api/requisitions/issue", partRequest);
    }

    deleteReq(reqId) {

        return this.http.delete(`/api/requisitions/Delete/${reqId}`);

    }

    updateRequisition(requisition) {

        return this.http.patch("/api/requisitions/Update", requisition);
    }

    removeReqItem(reqId, reqItemId) {

        return this.http.delete(`/api/requisitions/RemoveReqItem/${reqId}/${reqItemId}`);
    }

    getOperNum(jobNum, itemNum) {
        return this.http.get(`/api/requisitions/GetOper/${jobNum}/${itemNum}`);
    }
    isJobValid(jobNum) {
        return this.http.get(`/api/requisitions/job/${jobNum}`);
    }
}
