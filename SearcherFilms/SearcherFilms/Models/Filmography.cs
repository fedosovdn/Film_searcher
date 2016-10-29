using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearcherFilms.Models
{
    public class Filmography
    {
        public int ID { get; set; }
        public int FilmID { set; get; }
        public int ActorID { set; get; }
        public virtual Actor Actor { set; get; }
        public virtual Film Film { set; get; }
    }
}