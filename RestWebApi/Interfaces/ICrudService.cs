using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApi.Models;

namespace RestWebApi.Interfaces
{
    /// <summary>
    /// Interface for the service responsible for CRUD operations on the Dish type;
    /// This is the layer above the MongoDB DAL layer, and it communicates with it.
    /// </summary>
    public interface ICrudService
    {
        Dish Create(Dish dish);
        List<Dish> Read();
        Dish ReadById(string id);
        void Update(string id, Dish dishToUpdate);
        void DeleteById(string id);
        void DeleteByDish(Dish dishToDelete);
    }
}
