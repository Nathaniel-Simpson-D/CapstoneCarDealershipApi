using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealerCapstone.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealerCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly DealershipBdContext _context;
        public CarController(DealershipBdContext context)
        {
            if(context.CarModels.Count() == 0)
            {
                context.CarModels.Add(new CarModel() {Color="Blue",Make="Chirchill",Model="Britian",Year=1940 });
                context.SaveChanges();
            }
           
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarModel>>> GetAllCars()
        {
            var list = await _context.CarModels.ToArrayAsync();
            return list;
        }
        [HttpGet("{id}")]
        public async Task<CarModel> GetACar(int id)
        {
            var car = _context.CarModels.Find(id);
            return car;
        }
    }
}