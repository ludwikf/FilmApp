using Microsoft.AspNetCore.Mvc;
using FilmApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmApp.Controllers
{
    public class FilmController : Controller
    {

        private static IList<Film> films = new List<Film>
        {
            new Film(){Id = 1, Name = "Film1", Description = "opis filmu1", Price=3},
            new Film(){Id = 2, Name = "Film2", Description = "opis filmu2", Price=5},
            new Film(){Id = 3, Name = "Film3", Description = "opis filmu3", Price=3},
        };

 
        public IActionResult Index()
        {
            return View(films);
        }

    
        public ActionResult Create()
        {
            return View(new Film());
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));
        }

    
        public ActionResult Details(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            return View(film);
        }

     
        public ActionResult Edit(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            return View(film);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film updatedFilm)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film != null)
            {
                film.Name = updatedFilm.Name;
                film.Description = updatedFilm.Description;
                film.Price = updatedFilm.Price;
            }
            return RedirectToAction(nameof(Index));
        }

    
        public ActionResult Delete(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film != null)
            {
                films.Remove(film);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
