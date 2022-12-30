import { Injectable } from "@angular/core";
import {HttpClient} from "@angular/common/http";
import { Product } from "../models/Product";
import { environment } from "src/environments/environment";

@Injectable(
    {
        providedIn: 'root'
    }
)
export class ProductService {
    baseUrl: string;
    constructor(private http: HttpClient) {
        this.baseUrl = environment.apiBaseUrl + "/products";
    }

    getProductsByCateogry(categoryId: string) {
        return this.http.get<Product[]>(this.baseUrl + "/getProductsByCategory/" + categoryId);
    }

}