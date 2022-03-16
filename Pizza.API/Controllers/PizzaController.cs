using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizza.API.Models;

namespace Pizza.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Pizzas> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Pizzas
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
            })
            .ToArray();
        }
    }
}
