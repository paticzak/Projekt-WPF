using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KinomaniakInterfejsPart1wpf.Classes
{
    public class RootObjectMovies
    {
        public int page { get; set; }
        public List<Movie> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }

        public void ConvertGenresIdToNames(List<Genre> genres)
        {
            foreach (Movie movie in results)
            {
                for (int i = 0; i < movie.genre_ids.Length; i++)
                {
                    for (int j = 0; j < genres.Count; j++)
                    {
                        if (movie.genre_ids[i] == genres[j].id)
                        {
                            movie.genres[i] = genres[j].name;
                        }
                    }

                }
            }
        } 
    }
}
