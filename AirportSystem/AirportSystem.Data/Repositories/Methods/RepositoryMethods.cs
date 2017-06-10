using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Data.Repositories.Methods
{
    static class RepositoryMethods
    {
        public static IEnumerable<T> GetAll<T>(DbContext context) 
            where T: class
        {
            return context.Set<T>().ToList();
        }

        public static T GetById<T>(int id, IEnumerable<T> allElements)
            where T : IBaseModel

        {
            var searchedElement = from element in allElements
                                  where element.Id == id
                                  select element;

            return searchedElement.ToList()[0];
        }
    }
}
