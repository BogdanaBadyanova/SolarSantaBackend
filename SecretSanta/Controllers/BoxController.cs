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
    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<Box>>> GetPagedBoxes([FromQuery] GetPagedBoxesRequest request)
    {
      var result = await _boxService.GetPagedBoxesAsync(request);
      return Ok(result);
    }
  }
}
