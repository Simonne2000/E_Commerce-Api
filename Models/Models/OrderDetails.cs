using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class OrderDetails
{
    // OrderDetails class representing details of an order for a product
    public int OrderDetailsId { get; set; }
    public int OrderId { get; set; } // Foreign key to Order
    public Order Order { get; set; } // Navigation property
    public int ProductId { get; set; } // Foreign key to Product
    public Product Product { get; set; } // Navigation property
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
