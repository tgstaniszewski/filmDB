using FilmDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB
{
    public class FilmManager
    {
        public FilmManager AddFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                context.Add(filmModel);
                try
                {
                    context.SaveChanges();

                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    filmModel.ID = 0;
                    context.Add(filmModel);
                    context.SaveChanges();

                }
            }
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            using (var context = new FilmContext())
            {
                var FilmModel = context.Films.SingleOrDefault(x => x.ID == id);
                context.Films.Remove(FilmModel);
                context.SaveChanges();

            }
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext())
            {
                context.Update(filmModel);
                context.SaveChanges();
            }

            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            using (var context = new FilmContext())
            {
                var FilmModel = context.Films.SingleOrDefault(x => x.ID == id);
                if (newTitle == null)
                {
                    newTitle = "Brak Tytułu";
                }
                FilmModel.Title = newTitle;
                UpdateFilm(FilmModel);                

            }
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            using (var context = new FilmContext())
            {
                var film = context.Films.SingleOrDefault(x => x.ID == id);
                return film;
            }
        }

        public List<FilmModel> GetFilms()
        {
            using (var context = new FilmContext())
            {
                var films = context.Films.ToList();
                return films;
            }
        }

        
    }
}
