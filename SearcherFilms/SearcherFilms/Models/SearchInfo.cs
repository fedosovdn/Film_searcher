using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearcherFilms.Models
{
    /// <summary>
    /// The model for containing information
    /// from html-form
    /// </summary>
    public class SearchInfo
    {
        public string textOfSearch {get; set;}
        public string typeOfSearhing { get; set; }
    }
}