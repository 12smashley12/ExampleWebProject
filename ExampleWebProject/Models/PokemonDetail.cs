using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleWebProject.Models
{
    public class PokemonDetail
    {
        public int Id { get; set; }
        public double Height { get; set; }
        public string Name { get; set; }
        public SpriteList Sprites { get; set; }
        public List<PokemonDetailType> Types { get; set; }
        public double Weight { get; set; }
    }

    public class SpriteList
    {
        public string Back_Default { get; set; }
        public string Front_Default { get; set; }
    }

    public class PokemonDetailType
    {
        public int Slot { get; set; }
        public PokemonDetailType2 Type { get; set; }
    }

    public class PokemonDetailType2
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}