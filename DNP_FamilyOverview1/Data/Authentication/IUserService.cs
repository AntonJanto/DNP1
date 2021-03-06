﻿using DNP_FamilyOverview1.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNP_FamilyOverview1.Data.Authentication
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
        Task RegisterUserAsync(string username, string password);
    }
}
