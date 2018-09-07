import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class ItemsProvider {

  locations: any;
  lots: any;

  constructor(public http: HttpClient) { }

  getItemDescription(item) {
    let headers = new HttpHeaders({ 'Content-Type': "application/json" });

    return this.http.get(`/api/items/${item}`, { headers: headers });
  }

  loadLocations(itemReqId) {
    this.http.get(`/api/items/location/${itemReqId}`).subscribe(response => {
      this.locations = response;
    });
  }
  loadLocationsWithLot(itemReqId) {
    return this.http.get(`/api/items/ItemLot/${itemReqId}`);
  }

  loadShortageLocations(itemReqId) {
    return this.http.get(`/api/items/shortagelocation/${itemReqId}`);
  }
}
