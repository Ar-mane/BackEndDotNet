using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogApp.Models
{
    [Table("Categorie")]
    public class Category
    {
        [Key] public int Id { get; set; }

        public string Label { get; set; }
        [JsonIgnore] public ICollection<Product> products { get; set; }
    }
}