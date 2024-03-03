using E_Commerce_Api.API;
using E_Commerce_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace E_Commerce_Api.Controllers;

public class HomeController : Controller
{
    private IApiConsume _api;


    public HomeController(IApiConsume api)
    {
        _api = api;
    }

    public override void OnActionExecuting(ActionExecutingContext db)
    {
        //var categ = _db.Categories.FindAll(m=>m.CategoryId !=0,0,100,orderBy:m=>m.OrderId);
        var categ = _api.GetAll<Category>("Category/GetCategories");
        ViewBag.categ = categ;
        //ViewData["categ"] = categ;
        base.OnActionExecuting(db);

    }
    public IActionResult Index(string searchcriteria)
    {
        IEnumerable<Product> products;
        if(searchcriteria == null)
        {
            products = _api.GetAll<Product>("Product/GetProducts");
          //  ViewBag.Product = Product;
        }
        else
        {
            products = _api.GetAll<Product>("Product/SearchProductsByName?name="+searchcriteria);
            //var Product = _api.GetAll<Product>("Product/GetProducts");
            //ViewBag.Product = Product;
        }

        ViewBag.Product = products;

        return View(_api.GetAll<Category>("Category/GetCategories"));
    }
    [Authorize]
    public IActionResult ShopDetails(int id)
    {
        var product = _api.GetById<Product>($"Product/GetProductById?id={id}");

        if (product != null)
        {
            return View(product);
        }
        else
        {
            // Handle the case where the product with the specified ID is not found
            return RedirectToAction("ProductNotFound");
        }
    }
    public IActionResult shop()
    {

        CategoryProduct categoryProduct = new CategoryProduct();
        categoryProduct.Products = _api.GetAll<Product>("Product/GetProducts");
        categoryProduct.Categories = _api.GetAll<Category>("Category/GetCategories");
        return View(categoryProduct);
    }
    [Authorize]
    public IActionResult UpdateQuantity()
    {

        return View();
    }

    public IActionResult ContactUS()
    {
        return View();
    }

    [Authorize]
    public IActionResult AddToCart(int id)
    {
        CookieOptions cookieOptions = new CookieOptions();
        cookieOptions.Expires = DateTime.Now.AddDays(20);
        var p = _api.GetById<Product>($"Product/GetProductById?id={id}"); ;
        var _oldCookie = Request.Cookies["amazoncart"];
        List<Product> _products = new List<Product>();


        if (_oldCookie != null)
        {

            _products = JsonConvert.DeserializeObject<List<Product>>(_oldCookie);

        }
        _products.Add(p);
        string json = JsonConvert.SerializeObject(_products);
        Response.Cookies.Append("amazoncart", json, cookieOptions);

        return RedirectToAction(nameof(Index));

    }
    [Authorize]
    public IActionResult Cart()
    {

        var cart = Request.Cookies["amazoncart"].ToString();
        var ps = JsonConvert.DeserializeObject<List<Product>>(cart);

        decimal totalPrice = 0;
        foreach (var product in ps)
        {
            totalPrice += product.Price;
        }

        ViewBag.TotalPrice = totalPrice;
        return View(ps);
    }
    [Authorize]
    public IActionResult checkout()
    {
        var cart = Request.Cookies["amazoncart"].ToString();
        var ps = JsonConvert.DeserializeObject<List<Product>>(cart);

        decimal totalPrice = 0;
        foreach (var product in ps)
        {
            totalPrice += product.Price;
        }

        ViewBag.TotalPrice = totalPrice;
        return View(ps);

    }
    public IActionResult CategoryDetails(int id)
    {


        return View(_api.GetById<Category>("Category / GetCategoryByIdAsync"));
    }
   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}