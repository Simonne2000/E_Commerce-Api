using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEP_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{


    private readonly IUnitOfWork _unitOfWork;
    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }



    // GET: api/<CategoryController>
    [HttpGet("GetCategories")]
    public IActionResult GetCategories()
    {
        return Ok(_unitOfWork.Categories.GetAll());
    }



    [HttpGet("GetCategoriesAsync")]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        return Ok(await _unitOfWork.Categories.GetAllAsync());
    }


    [HttpGet("FindByIdWithDept")]
    public IActionResult FindByIdWithDept(int id)
    {
        return Ok(_unitOfWork.Categories.Find(m => m.CategoryId == id));
    }
    [HttpGet("GetCategoryByIdAsync")]
    public async Task<IActionResult> GetCategoryAsync(int id)
    {
        if (id == 0)
            return BadRequest();
        else
            return Ok(await _unitOfWork.Categories.GetByIdAsync(id));
    }


    [HttpPost("AddCategory")]
    public IActionResult Create(Category Category)
    {
        var m = _unitOfWork.Categories.Add(Category);
        _unitOfWork.Save();
        return Ok(m);
    }

    [HttpPost("AddCategories")]
    public IActionResult Create(IEnumerable<Category> Categories)
    {
        var c = _unitOfWork.Categories.AddRange(Categories);
        _unitOfWork.Save();
        return Ok(c);
    }


    // PUT api/<CategoryController>/5
    [HttpPut("UpdateCategory")]
    public IActionResult Update(Category Category)
    {
        var c = _unitOfWork.Categories.Update(Category);
        _unitOfWork.Save();
        return Ok(c);
    }


    // DELETE api/<CategoryController>/5
    [HttpDelete("DeleteCategory")]
    public IActionResult Delete(int id)
    {
        var Category = _unitOfWork.Categories.GetById(id);
        _unitOfWork.Categories.Delete(Category);
        _unitOfWork.Save();
        return Ok();
    }
    [HttpDelete("DeleteCategories")]
    public IActionResult Delete(IEnumerable<Category> Categories)
    {
        _unitOfWork.Categories.DeleteRange(Categories);
        _unitOfWork.Save();
        return Ok();
    }
}
