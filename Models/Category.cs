using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public String NameCategory { get; set; }

        //Mode Lazy (chaque catégorie peut contient pls produits)
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
