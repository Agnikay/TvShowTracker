﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvShowTracker.Model.DataAccess
{
    public interface IUserRepository
    {
        User FindUserByLoginAndPassword(string name, string password);
    }
}
