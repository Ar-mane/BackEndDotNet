using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CatalogApp.Models;

namespace CatalogApp.Controllers {
    
    [Route("/api/produits")]
    public class ProductRest : Controller {
        private CatalogRepository CatalogRepository { get; set; }
        
        //autoWired 
        public ProductRest(CatalogRepository repository) {
            this.CatalogRepository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> ListProdsucts() {
            return CatalogRepository.Products.Include(produit => produit.Category);
        }

        [HttpGet("{Id}")]
        public Product Get(int id)
        {
            return CatalogRepository.Products.Include(produit => produit.Category)
                .FirstOrDefault(p => p.Id == id);
        }

        [HttpGet("find")]
        public IEnumerable<Product> Search(string key)
        {
            return CatalogRepository
                .Products
                .Include(p => p.Category)
                .Where(produit => produit.Name.Contains(key));
        }

        [HttpGet("page")]
        public IEnumerable<Product> Page(int page = 0, int size = 1)
        {
            int Skip = (page - 1) * size;
            return CatalogRepository.Products
                .Include(p => p.CategoryId)
                .Skip(Skip)
                .Take(size);
        }

        [HttpPut("{Id}")]
        public Product Update(int Id, [FromBody] Product product)
        {
            product.Id = Id;
            CatalogRepository.Products.Update(product);
            CatalogRepository.SaveChanges();
            return product;
        }

        [HttpPost]
        public Product Save([FromBody] Product product)
        {
            CatalogRepository.Products.Add(product);
            CatalogRepository.SaveChanges();
            return product;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            Product product = CatalogRepository.Products.FirstOrDefault(c => c.Id == Id);
            CatalogRepository.Remove(product ?? throw new InvalidOperationException());
        }
    }
}