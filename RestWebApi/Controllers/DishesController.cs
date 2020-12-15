using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestWebApi.Interfaces;
using RestWebApi.Models;

namespace RestWebApi.Controllers
{
    /// <summary>
    /// A controller for all CRUD operations on the Dish type.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly ICrudService crudService;

        public DishesController(ICrudService crud)
        {
            crudService = crud;
        }

        [HttpGet]
        public ActionResult<List<Dish>> Get() =>
            crudService.Read();

        [HttpGet("{id:length(24)}", Name = "GetDish")]
        public ActionResult<Dish> Get(string id)
        {
            var dish = crudService.ReadById(id);

            if (dish == null)
            {
                return NotFound();
            }

            return dish;
        }

        [HttpPost]
        public ActionResult<Dish> Create(Dish dish)
        {
            crudService.Create(dish);

            return CreatedAtRoute("GetDish", new { id = dish.Id.ToString() }, dish);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Dish dishToUpdate)
        {
            var dish = crudService.ReadById(id);

            if (dish == null)
            {
                return NotFound();
            }

            crudService.Update(id, dishToUpdate);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var dish = crudService.ReadById(id);

            if (dish == null)
            {
                return NotFound();
            }

            crudService.DeleteById(dish.Id);

            return NoContent(); 
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(Dish dish)
        {
            crudService.DeleteById(dish.Id);

            return NoContent(); 
        }
    }
}