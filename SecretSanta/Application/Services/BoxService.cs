using SecretSanta.Dto;
using SecretSanta.Domain;
using SecretSanta.Infrastructure.Repositories;

namespace SecretSanta.Application.Services
{
  public interface IBoxService
  {
    Task<PaginatedResponse<Box>> GetPagedBoxesAsync(GetPagedBoxesRequest request);
  }

  public class BoxService : IBoxService
  {
    private readonly IBoxRepository _boxRepository;

    public BoxService(IBoxRepository boxRepository)
    {
      _boxRepository = boxRepository;
    }

    public async Task<PaginatedResponse<Box>> GetPagedBoxesAsync(GetPagedBoxesRequest request)
    {
      return await _boxRepository.GetPagedBoxesAsync(request);
    }
  }
}
