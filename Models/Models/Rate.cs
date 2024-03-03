using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class Rate
{
    // Rate class representing product ratings
    public int RateId { get; set; }
    public int ProductId { get; set; } // Foreign key to Product
    public Product Product { get; set; } // Navigation property
    public int Stars { get; set; }
    public string Comment { get; set; }
}
