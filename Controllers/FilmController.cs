using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            //var Film = new FilmModel();
            //Film.ID = 1;
            //Film.Title = "tytanic";
            //Film.Year = 2021;

            var FilmManager = new FilmManager();
            //FilmManager.AddFilm(Film);
            // FilmManager.RemoveFilm(2);
            var films = FilmManager.GetFilms();
            return View(films);
        }


        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(FilmModel film)
        {
            var manager = new FilmManager();
            manager.AddFilm(film);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var manager = new FilmManager();
            var film = manager.GetFilm(id);
            return View(film);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            var manager = new FilmManager();
            var film = manager.GetFilm(id);
            if (film != null)
            {
                manager.RemoveFilm(id);
                return RedirectToAction("index");

            }
            else
            {
                return RedirectToAction("Remove", id);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var manager = new FilmManager();
            var film = manager.GetFilm(id);
            return View(film);
        }

        [HttpPost]
        public IActionResult Edit(FilmModel film)
        {
            var manager = new FilmManager();
            manager.UpdateFilm(film);
            return RedirectToAction("index");
        }


    }
}
