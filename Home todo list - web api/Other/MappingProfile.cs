﻿using AutoMapper;
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
            CreateMap<RegisterAccountDto, RegisterAccountModel>();
            CreateMap<RegisterAccountModel, RegisterAccountDto>();

            CreateMap<User, RegisterAccountModel>();
            CreateMap<RegisterAccountModel, User>();

            CreateMap<UserRegisteredDto, User>();
            CreateMap<User, UserRegisteredDto>();

            CreateMap<AuthenticateDto, AuthenticateUserModel>();
            CreateMap<AuthenticateUserModel, AuthenticateDto>();

            CreateMap<UserAuthenticatedDto, User>();
            CreateMap<User, UserAuthenticatedDto>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
