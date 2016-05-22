using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinomaniakInterfejsPart1wpf.Classes
{
    class GenreConverter
    {
        public static List<Movie> ConvertGenresIdToNames(List<Movie> movies, List<Genre> genres  )
        {
            foreach (Movie movie in movies)
            {
                foreach (int t1 in movie.genre_ids)
                {
                    foreach (Genre t in genres.Where(t => t1 == t.id))
                    {
                        movie.genres.Add(t.name);
                        movie.genresString += t.name;
                    }
                }
            }
            return movies;
        }
    }
}
