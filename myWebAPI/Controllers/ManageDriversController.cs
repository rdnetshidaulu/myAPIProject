using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDS_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ManageDriversController : ControllerBase
    {
        private static readonly string[] Drivers = new[]
{
            "Adam", "Alex", "Aaron", "Ben", "Carl", "Dan", "David", "Edward", "Fred", "Frank", "George", "Hal", "Hank", "Ike", "John", "Jack", "Joe", "Larry", "Monte", "Matthew", "Mark", "Nathan", "Otto", "Paul", "Peter", "Roger", "Roger", "Steve", "Thomas", "Tim", "Ty", "Victor", "Walter"
        };

        private static readonly string[] Brand = new[]
        {
              "Abarth",
              "Alfa Romeo",
              "Aston Martin",
              "Audi",
              "Bentley",
              "BMW",
              "Bugatti",
              "Cadillac",
              "Chevrolet",
              "Chrysler",
              "Citroën",
              "Dacia",
              "Daewoo",
              "Daihatsu",
              "Dodge",
              "Donkervoort",
              "DS",
              "Ferrari",
              "Fiat",
              "Fisker",
              "Ford",
              "Honda",
              "Hummer",
              "Hyundai",
              "Infiniti",
              "Iveco",
              "Jaguar",
              "Jeep",
              "Kia",
              "KTM",
              "Lada",
              "Lamborghini",
              "Lancia",
              "Land Rover",
              "Landwind",
              "Lexus",
              "Lotus",
              "Maserati",
              "Maybach",
              "Mazda",
              "McLaren",
              "Mercedes-Benz",
              "MG",
              "Mini",
              "Mitsubishi",
              "Morgan",
              "Nissan",
              "Opel",
              "Peugeot",
              "Porsche",
              "Renault",
              "Rolls-Royce",
              "Rover",
              "Saab",
              "Seat",
              "Skoda",
              "Smart",
              "SsangYong",
              "Subaru",
              "Suzuki",
              "Tesla",
              "Toyota",
              "Volkswagen",
              "Volvo"
        };

        private readonly ILogger<ManageDriversController> _logger;

        public ManageDriversController(ILogger<ManageDriversController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ManageDrivers> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ManageDrivers
            {
                Driver = Drivers[rng.Next(Brand.Length)],
                Trips = rng.Next(0, 75),
                Vechile = Brand[rng.Next(Brand.Length)]
            })
            .ToArray();
        }
    }
}
