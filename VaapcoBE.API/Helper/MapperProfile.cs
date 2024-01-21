using AutoMapper;
using VaapcoBE.API.RequestDTO;
using VaapcoBE.API.ResponseDTO;
using VaapcoBE.BL.DTO;

namespace VaapcoBE.API.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<NewsHeadlineDTO, AddHeadlineRequest>().ReverseMap();
            CreateMap<GetHeadlinesDTO, GetHeadlinesResponse>().ReverseMap();
            CreateMap<UpdateHeadlineDTO, UpdateHeadlineRequest>().ReverseMap();
            CreateMap<AddEventsDTO,AddEventsRequest>().ReverseMap();
            CreateMap<GetEventsDTO, GetEventsResponse>().ReverseMap();
            CreateMap<UpdateEventsDTO, UpdateEventsRequest>().ReverseMap();
            CreateMap<RegisterUserBL, RegisterUserRequest>().ReverseMap();
        }
    }
}
