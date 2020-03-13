﻿using Home_todo_list___web_api.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Home_todo_list___web_api.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
    }
}