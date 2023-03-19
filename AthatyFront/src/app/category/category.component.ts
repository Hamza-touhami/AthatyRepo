import { Component, Input, OnInit } from '@angular/core';
import { Category } from '../models/Category';
import { CategoryService } from '../services/CategoryService';
@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})

export class CategoryComponent implements OnInit {
  
  @Input() categ: Category;

  constructor(private _service:CategoryService) {
   }
  ngOnInit(): void {
  }
}
