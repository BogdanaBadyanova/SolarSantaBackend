using Microsoft.EntityFrameworkCore;
using SecretSanta.Dto;
using SecretSanta.Domain;

namespace SecretSanta.Infrastructure.Repositories
{
  public interface IBoxRepository
  {
    Task<PaginatedResponse<Box>> GetPagedBoxesAsync(GetPagedBoxesRequest request);
  }

  public class BoxRepository : IBoxRepository
  {
    private readonly SecretSantaContext _context;

    public BoxRepository(SecretSantaContext context)
    {
      _context = context;
    }

    public async Task<PaginatedResponse<Box>> GetPagedBoxesAsync(GetPagedBoxesRequest request)
    {
      var query = _context.Boxes.AsQueryable();

      // Применение фильтрации по имени коробки
      if (!string.IsNullOrEmpty(request.Name))
      {
        query = query.Where(b => b.Name.Contains(request.Name));
      }

      // Пагинация
      var totalCount = await query.CountAsync();
      var items = await query
        .Skip((request.Page - 1) * request.Size)
        .Take(request.Size)
        .ToListAsync();

      return new PaginatedResponse<Box>
      {
        Items = items,
        TotalCount = totalCount
      };
    }
  }
}
