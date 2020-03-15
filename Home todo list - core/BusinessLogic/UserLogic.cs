using Home_todo_list___core.Abstraction.BusinessLogic;
using Home_todo_list___entities;
using Home_todo_list___infrastructure.Abstraction.Repositories;
using System;
using System.Collections.Generic;

namespace Home_todo_list___core.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;
        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Authenticate(string username, string password)
        {
            return _userRepository.Authenticate(username, password);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
