using System;
using CatalogApp.Models;

namespace CatalogApp.Services
{
    public static class PreExecute
    {
        public static void Init(CatalogRepository database)
        {
            Console.WriteLine("init ...");

            database.Categories.Add(new Category {Label = "Location"});
            database.Categories.Add(new Category {Label = "Vente"});
            database.Products.Add(new Product {Name = "Chambre a loué", Price = 2000, CategoryId = 1});
            database.Products.Add(new Product {Name = "Garconier ", Price = 2100, CategoryId = 1});
            database.Products.Add(new Product
                {Name = "Appartement a vendre", Price = 1500000, CategoryId = 2});
            database.Products.Add(new Product
                {Name = "appartement a vendre  ", Price = 2000000, CategoryId = 2});
            database.SaveChanges();
            
            Console.WriteLine("started");
        }
    }
}