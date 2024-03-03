using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;


public class Product
{
    // Review class representing reviews for products
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string DEfaultImages { get; set; }
    public string? Images { get; set; }
    public int CategoryId { get; set; } // Foreign key to Category
    public Category Category { get; set; } // Navigation property

    public List<Review> Reviews { get; set; } // Navigation property

  
}