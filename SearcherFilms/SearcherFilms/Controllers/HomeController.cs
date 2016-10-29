using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearcherFilms.Models;

namespace SearcherFilms.Controllers
{
    public class HomeController : Controller
    {
        FilmsContext db = new FilmsContext();//The data base

        //search request by information about name of the film
        public IQueryable<Film> GetFilmByNameFilm(string searcherInfo)
        {
            var films = (from Films in db.Films
                         where Films.Name == searcherInfo
                         select Films);
            return films;
        }

        //search request by information about actor of the film
        //Searching is possible either according information about
        //only firstname or only lastname or both at one time
        public IQueryable<Film> GetFilmByNameActor(string searcherInfo)
        {
            //processing of non-valid data
            if (searcherInfo == null) searcherInfo = "00000";
            else { searcherInfo = searcherInfo.Trim(); if (searcherInfo == "") searcherInfo = "00000"; }
            
            string[] searchInfo = searcherInfo.Split();
            string str1 = searchInfo[0];
            if (searchInfo.Length == 1)
            {
                var Films = (from filmographis in db.Filmographis
                             join films in db.Films on filmographis.FilmID equals films.ID
                             join actors in db.Actors on filmographis.ActorID equals actors.ID
                             where actors.FirstName.Contains(str1) || actors.LastName.Contains(str1)
                             select films);
                return Films;
            }
            else
            {
                string str2 = searchInfo[1];
                var Films = (from filmographis in db.Filmographis
                             join films in db.Films on filmographis.FilmID equals films.ID
                             join actors in db.Actors on filmographis.ActorID equals actors.ID
                             where (actors.FirstName.Contains(str1) || actors.LastName.Contains(str1))
                             && (actors.FirstName.Contains(str2) || actors.LastName.Contains(str2))
                             select films);
                return Films;
            }
        }

        //search request by information about ganre of the film
        public IQueryable<Film> GetFilmByGanre(string searcherInfo)
        {
            var films = (from Films in db.Films
                         where Films.Ganre == searcherInfo
                         select Films);
            return films;
        }

        //Starting page
        public ActionResult Index()
        {
            return View();
        }

        //Page with the information according to the search request
        [HttpGet]
        public ActionResult FilmInfo(SearchInfo searcherInfo)
        {
            string textOfSearch = searcherInfo.textOfSearch;
            string typeOfSearching = searcherInfo.typeOfSearhing;
            IQueryable<Film> selectedFilms;

            //searching film/films according to the type of searching
            if (typeOfSearching == "byNameFilm") selectedFilms = GetFilmByNameFilm(textOfSearch);
            else
            {
                if (typeOfSearching == "byNameActor") selectedFilms = GetFilmByNameActor(textOfSearch);
                else selectedFilms = GetFilmByGanre(textOfSearch);
            }
            if (!selectedFilms.Any()) return View("NothingFound");
            return View(selectedFilms);
        }
    }
}
