using System.Security.Claims;
using ChaosFinance.API.DTOs.Requests;
using ChaosFinance.API.DTOs.Responses;
using ChaosFinance.Domain.Entities;
using ChaosFinance.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChaosFinance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private int GetUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
        {
            throw new UnauthorizedAccessException("Invalid user ID in token.");
        }
        return userId;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        if (!Enum.TryParse<CategoryType>(request.Type, true, out var categoryType))
        {
            return BadRequest(new ErrorResponse { Message = "Invalid category type. Must be 'Expense' or 'Income'." });
        }

        var userId = GetUserId();
        var category = await categoryService.Create(userId, request.Name, categoryType, request.Color, request.Limit);

        var response = new CategoryResponse
        {
            Id = category.Id,
            UserId = category.UserId,
            Name = category.Name,
            Type = category.Type.ToString(),
            Color = category.Color,
            Limit = category.Limit
        };

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var userId = GetUserId();
        var category = await categoryService.GetById(id, userId);

        if (category == null)
        {
            return NotFound(new ErrorResponse { Message = "Category not found." });
        }

        var response = new CategoryResponse
        {
            Id = category.Id,
            UserId = category.UserId,
            Name = category.Name,
            Type = category.Type.ToString(),
            Color = category.Color,
            Limit = category.Limit
        };

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = GetUserId();
        var categories = await categoryService.GetByUserId(userId);

        var response = categories.Select(c => new CategoryResponse
        {
            Id = c.Id,
            UserId = c.UserId,
            Name = c.Name,
            Type = c.Type.ToString(),
            Color = c.Color,
            Limit = c.Limit
        });

        return Ok(response);
    }

    [HttpGet("type/{type}")]
    public async Task<IActionResult> GetByType(string type)
    {
        if (!Enum.TryParse<CategoryType>(type, true, out var categoryType))
        {
            return BadRequest(new ErrorResponse { Message = "Invalid category type. Must be 'Expense' or 'Income'." });
        }

        var userId = GetUserId();
        var categories = await categoryService.GetByUserIdAndType(userId, categoryType);

        var response = categories.Select(c => new CategoryResponse
        {
            Id = c.Id,
            UserId = c.UserId,
            Name = c.Name,
            Type = c.Type.ToString(),
            Color = c.Color,
            Limit = c.Limit
        });

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryRequest request)
    {
        if (!Enum.TryParse<CategoryType>(request.Type, true, out var categoryType))
        {
            return BadRequest(new ErrorResponse { Message = "Invalid category type. Must be 'Expense' or 'Income'." });
        }

        var userId = GetUserId();
        
        try
        {
            var category = await categoryService.Update(id, userId, request.Name, categoryType, request.Color, request.Limit);

            var response = new CategoryResponse
            {
                Id = category.Id,
                UserId = category.UserId,
                Name = category.Name,
                Type = category.Type.ToString(),
                Color = category.Color,
                Limit = category.Limit
            };

            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new ErrorResponse { Message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = GetUserId();
        
        try
        {
            await categoryService.Delete(id, userId);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new ErrorResponse { Message = ex.Message });
        }
    }
} 