using BlogApi.Domain.Interfaces;
using BlogApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Host.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _unitOfWork.Category.GetAll();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var category = await _unitOfWork.Category.GetById(id);
        if (category == null)
            return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryPost category)
    {
        if (ModelState.IsValid)
        {
            category.Id = Guid.NewGuid();

            await _unitOfWork.Category.Add(category);
            await _unitOfWork.CompleteAsync();
            return Ok(category);
        }

        return new JsonResult("Something Went wrong") { StatusCode = 500 };
    }

    [HttpPut]
    public async Task<IActionResult> Update(CategoryPost category)
    {
        if (ModelState.IsValid)
        {
            await _unitOfWork.Category.Update(category);
            await _unitOfWork.CompleteAsync();
            return Ok(category);
        }
        return new JsonResult("Something Went wrong") { StatusCode = 500 };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _unitOfWork.Category.Delete(id))
            return Ok(true);
        return NotFound();
    }

}

