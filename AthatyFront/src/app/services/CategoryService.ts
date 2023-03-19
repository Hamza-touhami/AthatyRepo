import { Injectable } from "@angular/core";
import {HttpClient} from "@angular/common/http";
import { Category } from "../models/Category";
import { environment } from "src/environments/environment";

@Injectable(
    {
        providedIn: 'root'
    }
)
export class CategoryService {
    baseUrl: string;
    constructor(private http: HttpClient) {
        this.baseUrl = environment.apiBaseUrl + "/categories";
    }

    public getCategories() {
        return this.http.get<Category[]>(this.baseUrl + "/getCategories");
    }

}