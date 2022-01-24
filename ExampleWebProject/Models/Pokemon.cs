using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleWebProject.Models
{
    public class AllPokemonResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Pokemon> Results { get; set; }
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}