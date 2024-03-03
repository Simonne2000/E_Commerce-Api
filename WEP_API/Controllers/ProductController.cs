using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEP_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;
    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }



    [HttpGet("GetProducts")]
    public IActionResult GetProducts()
    {
        return Ok(_unitOfWork.Products.GetAll());
    }



    [HttpGet("GetProductsAsync")]
    public async Task<IActionResult> GetProductsAsync()
    {
        return Ok(await _unitOfWork.Products.GetAllAsync());
    }


    [HttpGet("GetProductById")]
    public IActionResult GetProduct(int id)
    {
        return Ok(_unitOfWork.Products.GetById(id));
    }
    [HttpGet("FindByIdWithDept")]
    public IActionResult FindByIdWithDept(int id)
    {
        return Ok(_unitOfWork.Products.Find(m => m.ProductId == id));
    }
    [HttpGet("GetProductByIdAsync")]
    public async Task<IActionResult> GetProductAsync(int id)
    {
        if (id == 0)
            return BadRequest();
        else
            return Ok(await _unitOfWork.Products.GetByIdAsync(id));
    }

    [HttpPost("AddProduct")]
    public IActionResult Create(Product Product)
    {
        var m = _unitOfWork.Products.Add(Product);
        _unitOfWork.Save();
        return Ok(m);
    }
    [HttpPost("AddProducts")]
    public IActionResult Create(IEnumerable<Product> Products)
    {
        var m = _unitOfWork.Products.AddRange(Products);
        _unitOfWork.Save();
        return Ok(m);
    }
    [HttpPut("UpdateProduct")]
    public IActionResult Update(Product Product)
    {
        var m = _unitOfWork.Products.Update(Product);
        _unitOfWork.Save();
        return Ok(m);
    }
    [HttpDelete("DeleteProduct")]
    public IActionResult Delete(int id)
    {
        var Product = _unitOfWork.Products.GetById(id);
        _unitOfWork.Products.Delete(Product);
        _unitOfWork.Save();
        return Ok();
    }
    [HttpDelete("DeleteProducts")]
    public IActionResult Delete(IEnumerable<Product> Products)
    {
        _unitOfWork.Products.DeleteRange(Products);
        _unitOfWork.Save();
        return Ok();
    }
    [HttpGet("SearchProductsByName")]
    public IEnumerable<Product> GetProducts(string name)
    {
        return (_unitOfWork.Products.FindAll(m => m.ProductName.Contains(name)));
    }


}