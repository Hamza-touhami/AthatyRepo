import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/CategoryService';
import { Category } from '../models/Category';
import { ItemService } from '../services/ItemService';
import { Product } from '../models/Product';
import { ProductService } from '../services/ProductService';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {

  categories: Category[];
  cities: string[];
  products: Product[];
  selectedCategory: string = "null";
  selectedCity: string = "null";
  selectedProduct: string = "null";

  constructor(private categoryService: CategoryService, 
              private itemService: ItemService,
              private productService: ProductService) { }

  ngOnInit(): void {
    this.fetchCategories();
    this.fetchCities();

  }

  fetchCities() {
      this.itemService.getCities().subscribe((
      data: string[]) => this.cities = data
      );  
  }
  
  fetchCategories() {
    this.categoryService.getCategories().subscribe((
      data: Category[]) => this.categories = data
      );
  }

  fetchProducts(categoryId: string) {
    this.productService.getProductsByCateogry(categoryId).subscribe((
      data: Product[]) => this.products = data
    );
  }


  /* Events */
  onCategorySelected(categoryId: string) {
    this.fetchProducts(categoryId)
  }

}
