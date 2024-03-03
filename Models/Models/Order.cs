using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerId { get; set; } // Assuming customerId is a string for simplicity
    public DateTime OrderDate { get; set; }
    public List<OrderDetails> OrderDetails { get; set; } // Navigation property
}