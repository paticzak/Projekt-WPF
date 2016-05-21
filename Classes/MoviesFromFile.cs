﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KinomaniakInterfejsPart1wpf.Classes
{
    class MoviesFromFile
    {
        public static List<Movie> GetMovies()
        {
            var movies = new List<Movie>();
            string responseData = File.ReadAllText(@"C:\Users\Kamil\Desktop\Studia\WPF\Projekt\Projekt-WPF\movies.txt");
            var model = JsonConvert.DeserializeObject<List<RootObjectMovies>>(responseData);
            foreach (var x in model)
            {
                movies.AddRange(x.results);
            }
            return movies;
        } 
    }
}
