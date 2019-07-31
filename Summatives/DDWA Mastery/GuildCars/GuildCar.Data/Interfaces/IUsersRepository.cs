﻿using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<UsersItem> GetAllUsers();
    }
}
