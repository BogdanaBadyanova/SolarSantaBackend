using AutoMapper;
using SecretSanta.Domain;
using SecretSanta.Dto;
using SecretSanta.Infrastructure.Repositories;

namespace SecretSanta.Application.Services
{
  public interface IBoxService
  {
    Task<PaginatedResponse<BoxView>> GetPagedBoxesAsync(GetPagedBoxesRequest request);
    Task<BoxView> CreateBoxAsync(CreateBoxRequest request);
    Task<BoxDetail> GetByIdAsync(Guid id);
    Task DeleteAsync(Guid id);
  }

  public class BoxService : IBoxService
  {
    private readonly IBoxRepository _boxRepository;
    private readonly IMapper _mapper;

    public BoxService(IBoxRepository boxRepository, IMapper mapper)
    {
      _boxRepository = boxRepository;
      _mapper = mapper;
    }

    public async Task<PaginatedResponse<BoxView>> GetPagedBoxesAsync(GetPagedBoxesRequest request)
    {
      var boxes = await _boxRepository.GetPagedBoxesAsync(request);
      var boxViews = _mapper.Map<IEnumerable<BoxView>>(boxes.Items);

      return new PaginatedResponse<BoxView>
      {
        Items = boxViews,
        TotalCount = boxes.TotalCount
      };
    }
    
    public async Task<BoxView> CreateBoxAsync(CreateBoxRequest request)
    {
      var box = _mapper.Map<Box>(request);
      await _boxRepository.AddAsync(box);
      return _mapper.Map<BoxView>(box);
    }

    public async Task<BoxDetail> GetByIdAsync(Guid id)
    {
      var box = await _boxRepository.GetByIdAsync(id);
      return _mapper.Map<BoxDetail>(box);
    }
    
    public async Task DeleteAsync(Guid id)
    {
      await _boxRepository.DeleteAsync(id);
    }
  }
}
