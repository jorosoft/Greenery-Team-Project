﻿using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Data.Repositories.Methods
{
    static class RepositoryMethods
    {
        public static IQueryable<T> GetAll<T>(DbContext context) 
            where T: class
        {
            return context.Set<T>();
        }

        public static void Update<T>(DbContext context,T entity)
            where T: IBaseModel
        {

        }
    }
}
