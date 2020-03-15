using AutoMapper;
using Dtos;
using Home_todo_list___web_api.Entities;

namespace Home_todo_list___web_api.Other
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterAccountDto, RegisterAccountModel>();
            CreateMap<RegisterAccountModel, RegisterAccountDto>();
        }
    }
}
