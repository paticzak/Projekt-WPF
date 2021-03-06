﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinomaniakInterfejsPart1wpf.Classes
{
    public class Movie
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public int[] genre_ids { get; set; }
        public List<string> genres = new List<string>();
        public string genresString { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string release_date { get; set; }
        public string overview { get; set; }
        private string posterPath;
        public string poster_path
        {
            get { return "https://image.tmdb.org/t/p/w342" + posterPath; } //  "w92 w154 w185 w342 w500 w780 original dostepne rozmiary
            set
            {
                if (value != null)
                {
                    posterPath = value;
                }
            }
        }
        public double popularity { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public bool wish { get; set; }
        public bool watched { get; set; }
        public string review { get; set; }
        public override string ToString()
        {
            return title;
        }

    }

}
