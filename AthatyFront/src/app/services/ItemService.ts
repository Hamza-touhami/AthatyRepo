import { Injectable } from "@angular/core";
import {HttpClient} from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Item } from "../models/Item";

@Injectable(
    {
        providedIn: 'root'
    }
)
export class ItemService {
    baseUrl: string;
    constructor(private http: HttpClient) {
        this.baseUrl = environment.apiBaseUrl + "/items";
    }

    getItems() {
        return this.http.get<Item[]>(this.baseUrl + "/getItems");
    }

    getCities() {
        return this.http.get<string[]>(this.baseUrl + "/getCities");
    }

}