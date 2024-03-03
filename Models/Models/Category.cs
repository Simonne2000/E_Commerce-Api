using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

// Category class representing categories for grouping products
public class Category
{

    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string DefaultImages { get; set; }
    public string? Images { get; set; }
    public int ParentCategoryId { get; set; }
}