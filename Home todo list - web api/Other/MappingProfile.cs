using AutoMapper;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.InputDtos;

namespace Home_todo_list___web_api.Other
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterAccountDto, RegisterAccountModel>();
            CreateMap<RegisterAccountModel, RegisterAccountDto>();

            CreateMap<AuthenticateDto, AuthenticateUserModel>();
            CreateMap<AuthenticateUserModel, AuthenticateDto>();
        }
    }
}
