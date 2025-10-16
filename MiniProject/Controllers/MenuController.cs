using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _service;
    public MenuController(IMenuService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var menu = await _service.GetByIdAsync(id);
        return menu == null ? NotFound() : Ok(menu);
    }

    [HttpPost]
    public async Task<IActionResult> Create(MenuDtos dto) => Ok(await _service.CreateAsync(dto));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, MenuDtos dto)
    {
        dto.Id = id;
        return Ok(await _service.UpdateAsync(dto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _service.DeleteAsync(id));
}
