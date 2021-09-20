using Microsoft.AspNetCore.Mvc;
using MyDog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDog.Server.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class MyDogController : ControllerBase
    {
        static List<Breed> breed = new List<Breed>
        {
            new Breed { Id = 1,  Name = "West"},
            new Breed { Id = 2 , Name = "Border Collie"}
        };

        static List<MyDog.Shared.MyDog> myDogs = new List<MyDog.Shared.MyDog>
        {
            new MyDog.Shared.MyDog { Id = 1, Name = "Max", Color = "White" , BirthDate = Convert.ToDateTime("10/12/2004"), Breed = breed[0] },
            new MyDog.Shared.MyDog { Id = 2, Name = "Toto", Color = "Black" , BirthDate = Convert.ToDateTime("01/12/2022"), Breed = breed[1] },
        };


        [HttpGet("breed")]
        public async Task<IActionResult> GetBreed()
        {
            return Ok(breed);
        }


        [HttpGet]
        public async Task<IActionResult> GetMyDogs()
        {
            return Ok(myDogs);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetSingleDog(int id)
        {
            var dog = myDogs.FirstOrDefault(d => d.Id == id);
            if (dog is null)
                return NotFound("Dog wasn't found. Too bad. :(");

            return Ok(dog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDog(MyDog.Shared.MyDog dog)
        {
            dog.Id = myDogs.Max(d => d.Id + 1);
            myDogs.Add(dog);

            return Ok(myDogs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDog(MyDog.Shared.MyDog dog, int id)
        {

            var dbDog = myDogs.FirstOrDefault(d => d.Id == id);
            if (dbDog is null)
                return NotFound("Dog wasn't found. Too bad. :(");

            var index = myDogs.IndexOf(dbDog);
            myDogs[index] = dog; 

            return Ok(myDogs);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id)
        {

            var dbDog = myDogs.FirstOrDefault(d => d.Id == id);
            if (dbDog is null)
                return NotFound("Dog wasn't found. Too bad. :(");

            myDogs.Remove(dbDog);

            return Ok(myDogs);
        }
    }
}
