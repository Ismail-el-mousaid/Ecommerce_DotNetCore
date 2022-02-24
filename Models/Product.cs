using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }

        // Mode Lazy (la charge à la demande)
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}
