using AutoMapper;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.InputDtos;
using Home_todo_list___entities.OutputDtos;
using Home_todo_list___infrastructure.Entities;

namespace Home_todo_list___web_api.Other
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterAccountDto, RegisterAccountModel>().ReverseMap();

            CreateMap<User, RegisterAccountModel>().ReverseMap();

            CreateMap<UserRegisteredDto, User>().ReverseMap();

            CreateMap<AuthenticateDto, AuthenticateUserModel>().ReverseMap();

            CreateMap<UserAuthenticatedDto, User>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Project, ProjectDto>().ReverseMap();

            CreateMap<ProjectModel, Project>().ReverseMap();

            CreateMap<ProjectModel, ProjectDto>().ReverseMap();
        }
    }
}
