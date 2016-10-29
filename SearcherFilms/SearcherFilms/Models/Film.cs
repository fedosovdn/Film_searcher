using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearcherFilms.Models
{
    public class Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Ganre { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Filmography> Filmographis { get; set; }
    }
}