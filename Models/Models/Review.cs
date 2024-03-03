using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class Review
{
    // Review class representing reviews for products
    public int ReviewId { get; set; }
    public int ProductId { get; set; } // Foreign key to Product
    public Product Product { get; set; } // Navigation property
    public string ReviewText { get; set; }
    public string Author { get; set; }
}
