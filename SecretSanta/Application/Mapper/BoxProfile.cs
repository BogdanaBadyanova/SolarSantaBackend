using AutoMapper;
using SecretSanta.Application.Utils;
using SecretSanta.Domain;
using SecretSanta.Dto;

namespace SecretSanta.Application.Mapper
{
  public class BoxProfile : Profile
  {
    public BoxProfile()
    {
      CreateMap<Box, BoxView>();
      
      CreateMap<Box, BoxDetail>()
        .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.Participants.Select(p => p.Name).ToList()));

      CreateMap<CreateBoxRequest, Box>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))    
        .ForMember(dest => dest.IdCode, opt => opt.MapFrom(src => IdCode.Generate())); 
    }
  }
}