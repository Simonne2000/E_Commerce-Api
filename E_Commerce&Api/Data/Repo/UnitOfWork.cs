using Models.Interfaces;
using Models;

namespace E_Commerce_Api.Data.Repo;

public class UnitOfWork : IUnitOfWork
{
    protected private ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Products = new Repository<Product>(context);
        Categories = new Repository<Category>(context);
        Orders = new Repository<Order>(context);
        OrderDetails = new Repository<OrderDetails>(context);
        Rates = new Repository<Rate>(context);
        Review = new Repository<Review>(context);
        


    }

    public IRepository<Product> Products { get; }

    public IRepository<Category> Categories { get; }

    public IRepository<Order> Orders { get; }

    public IRepository<OrderDetails> OrderDetails { get; }
    public IRepository<Rate> Rates { get; }

    public IRepository<Review> Review { get; }

   

    public void Dispose()
    {
        _context.Dispose();
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
}