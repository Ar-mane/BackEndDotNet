using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CatalogApp.Models;

namespace CatalogApp.Controllers {
    
    [Route("/api/categories")]
    public class CategoryRest : Controller {
        private CatalogRepository CatalogRepository { get; set; }

        public CategoryRest(CatalogRepository repository) {
            this.CatalogRepository = repository;
        }

        [HttpGet("{Id}")]
        public Category Get(int Id) {
            return CatalogRepository.Categories.FirstOrDefault(c => c.Id == Id);
        }

        [HttpGet]
        public IEnumerable<Category> getALl()
        {
            return CatalogRepository.Categories;
        }


        [HttpGet("{Id}/products")]
        public IEnumerable<Product> Products(int Id)
        {
            Category category = CatalogRepository.Categories.Include(cat => cat.products)
                .FirstOrDefault(c => c.Id == Id);
            return category.products;
        }

        [HttpPut("{Id}")]
        public Category Update([FromBody] Category category, int Id)
        {
            category.Id = Id;
            CatalogRepository.Categories.Update(category);
            CatalogRepository.SaveChanges();
            return category;
        }

        [HttpPost]
        public Category Save([FromBody] Category category)
        {
            CatalogRepository.Categories.Add(category);
            CatalogRepository.SaveChanges();
            return category;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            Category category = CatalogRepository.Categories.FirstOrDefault(c => c.Id == Id);
            CatalogRepository.Remove(category ?? throw new InvalidOperationException());
        }
    }
}