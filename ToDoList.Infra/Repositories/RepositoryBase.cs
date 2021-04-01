﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Infra.Repositories
{
    public abstract class RepositoryBase
    {
        public RepositoryBase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected string ConnectionString;
    }
}
