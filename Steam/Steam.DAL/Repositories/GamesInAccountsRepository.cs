﻿using Steam.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Repositories
{
    public class GamesInAccountsRepository : GenericRepository<GamesInAccounts>
    {
        public GamesInAccountsRepository(DbContext context) : base(context)
        {
        }
    }
}
