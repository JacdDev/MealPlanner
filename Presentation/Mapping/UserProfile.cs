using Application.Users.Commands.CreateUser;
using AutoMapper;
using Presentation.Model.User;

namespace Presentation.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequest, CreateUserCommand>();
            CreateMap<CreateUserCommand, CreateUserRequest>();
        }
    }
}
