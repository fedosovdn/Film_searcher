using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearcherFilms.Models
{
    public class Actor
    {
        public int ID { get; set; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public virtual ICollection<Filmography> Filmographis { set; get; }
    }
}