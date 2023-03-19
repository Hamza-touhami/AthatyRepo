import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Category } from '../models/Category';
import { CategoryService } from '../services/CategoryService';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  public categories : Observable<Category[]>;
  
  constructor(private service:CategoryService) { }

  ngOnInit(): void {
    this.categories = this.service.getCategories();
  }

}
