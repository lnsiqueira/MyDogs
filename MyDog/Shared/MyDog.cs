using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDog.Shared
{
    public class MyDog
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } 
        public string Color { get; set; }
        public DateTime BirthDate { get; set; }
        public Breed Breed { get; set; } = new Breed();

    }
}
