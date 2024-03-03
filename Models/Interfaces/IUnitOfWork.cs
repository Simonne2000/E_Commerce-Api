using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces;

public interface IUnitOfWork : IDisposable
{

    IRepository<Product> Products { get; }
    IRepository<Category> Categories { get; }
    IRepository<Order> Orders { get; }
    IRepository<OrderDetails> OrderDetails { get; }
    IRepository<Rate> Rates { get; }

    IRepository<Review> Review { get; }


    int Save();

}