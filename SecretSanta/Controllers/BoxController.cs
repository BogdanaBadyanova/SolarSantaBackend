using Microsoft.AspNetCore.Mvc;
using SecretSanta.Application.Services;
using SecretSanta.Domain;
using SecretSanta.Dto;

namespace SecretSanta.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BoxesController : ControllerBase
  {
    private readonly IBoxService _boxService;

    public BoxesController(IBoxService boxService)
    {
      _boxService = boxService;
    }

    /// <summary>
    /// Получение пагинированного списка коробок
    /// </summary>
    /// <param name="request">Параметры пагинации</param>
    /// <returns>Пагинированный список коробок</returns>
    [HttpPost("paged-boxes")]
    public async Task<ActionResult<PaginatedResponse<BoxView>>> GetPagedBoxes([FromBody] GetPagedBoxesRequest request)
    {
      var result = await _boxService.GetPagedBoxesAsync(request);
      return Ok(result);
    }
    
    /// <summary>
    /// Создание новой коробки
    /// </summary>
    /// <param name="createBoxRequest">Данные для создания коробки</param>
    /// <returns>Созданная коробка</returns>
    [HttpPost]
    public async Task<ActionResult<BoxView>> CreateBox([FromBody] CreateBoxRequest createBoxRequest)
    {
      if (createBoxRequest == null)
      {
        return BadRequest("Invalid box data.");
      }

      var createdBox = await _boxService.CreateBoxAsync(createBoxRequest);

      return Ok(createdBox);
    }

    /// <summary>
    /// Получение коробки по ID
    /// </summary>
    /// <param name="id">ID коробки</param>
    /// <returns>Коробка</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BoxDetail>> GetBoxById(Guid id)
    {
      var box = await _boxService.GetByIdAsync(id);

      if (box == null)
      {
        return NotFound();
      }

      return Ok(box);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBox(Guid id)
    {
      try
      {
        await _boxService.DeleteAsync(id);
        return NoContent();
      }
      catch (Exception)
      {
        return NotFound();
      }
    }
  }
}
