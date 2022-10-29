using BlogApi.Domain.Interfaces;
using BlogApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Host.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TagController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public TagController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Tags = await _unitOfWork.Tag.GetAll();
        return Ok(Tags);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var tag = await _unitOfWork.Tag.GetById(id);
        if (tag == null)
            return NotFound();
        return Ok(tag);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Tag tag)
    {
        if (ModelState.IsValid)
        {
            tag.Id = Guid.NewGuid();

            await _unitOfWork.Tag.Add(tag);
            await _unitOfWork.CompleteAsync();
            return Ok(tag);
        }

        return new JsonResult("Something Went wrong") { StatusCode = 500 };
    }

    [HttpPut]
    public async Task<IActionResult> Update(Tag tag)
    {
        if (ModelState.IsValid)
        {
            await _unitOfWork.Tag.Update(tag);
            await _unitOfWork.CompleteAsync();
            return Ok(tag);
        }
        return new JsonResult("Something Went wrong") { StatusCode = 500 };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _unitOfWork.Tag.Delete(id))
            return Ok(true);
        return NotFound();
    }

}

