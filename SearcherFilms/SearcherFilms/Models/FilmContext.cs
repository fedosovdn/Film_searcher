using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SearcherFilms.Models
{
    /// <summary>
    /// Class of the Data Base
    /// </summary>
    public class FilmsContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Filmography> Filmographis { get; set; }
    }
}