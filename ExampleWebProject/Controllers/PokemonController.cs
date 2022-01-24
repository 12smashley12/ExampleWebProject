using ExampleWebProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ExampleWebProject.Controllers
{
    public class PokemonController : Controller
    {
        static HttpClient _httpClient = new HttpClient();
        // GET: Pokemon
        public async Task<ActionResult> Index()
        {
            IEnumerable<Pokemon> pokemonList = null;

            HttpResponseMessage response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=1200");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                AllPokemonResponse allPokemon = JsonConvert.DeserializeObject<AllPokemonResponse>(json);
                pokemonList = allPokemon.Results;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View(pokemonList);
        }

        public async Task<ActionResult> Random()
        {
            PokemonDetail pokemon = null;
            int randomId = new Random().Next(1, 899);

            HttpResponseMessage response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/" + randomId);
            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                pokemon = JsonConvert.DeserializeObject<PokemonDetail>(json);
                pokemon.Height /= 10;
                pokemon.Weight /= 10;
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View(pokemon);
        }

        public async Task<ActionResult> Details(string id)
        {
            if(String.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("Index");
            }

            PokemonDetail pokemon = null;

            HttpResponseMessage response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/" + id);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                pokemon = JsonConvert.DeserializeObject<PokemonDetail>(json);
                pokemon.Height /= 10;
                pokemon.Weight /= 10;
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View(pokemon);
        }
    }
}