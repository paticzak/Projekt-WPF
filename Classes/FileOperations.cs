using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace KinomaniakInterfejsPart1wpf.Classes
{
    class FileOperations
    {
        private static List<Movie> GetMoviesWithoutGenres()
        {
            var movies = new List<Movie>();
            string responseData = string.Empty;
            try
            {
                responseData =
                    File.ReadAllText(@"C:\Users\Kamil\Desktop\Studia\WPF\Projekt\Projekt-WPF\movies.txt");
            }
            catch
            {
                MessageBox.Show("Zła ścieżka");
                return movies;
            }
            var model = JsonConvert.DeserializeObject<List<RootObjectMovies>>(responseData);
            foreach (var x in model)
            {
                movies.AddRange(x.results);
            }
            return movies;
        }

        private static List<Movie> GetUpcomingMoviesWithoutGenres()
        {
            var movies = new List<Movie>();
            var responseData =
                   File.ReadAllText(@"C:\Users\Kamil\Desktop\Studia\WPF\Projekt\Projekt-WPF\upcomingMovies.txt");
            var model = JsonConvert.DeserializeObject<RootObjectMovies>(responseData);
            movies.AddRange(model.results);
            return movies;
        }

        public static List<Movie> GetUpcomingMovies()
        {
            var movies = GetUpcomingMoviesWithoutGenres();
            var genres = GetGenres();
            return GenreConverter.ConvertGenresIdToNames(movies, genres);

        }

        public static List<Movie> GetMovies()
        {
            var movies = GetMoviesWithoutGenres();
            var genres = GetGenres();
            return GenreConverter.ConvertGenresIdToNames(movies, genres);
        }

        public static List<Genre> GetGenres()
        {
            var responseData =
                    File.ReadAllText(@"C:\Users\Kamil\Desktop\Studia\WPF\Projekt\Projekt-WPF\genres.txt");
            var model = JsonConvert.DeserializeObject<RootObjectGenres>(responseData);
            return model.genres;
        }

        public static bool SaveMovieToFile(string serializeObject, string path)
        {
            try
            {
                var responseData =
                    File.ReadAllText(path);
                if (responseData == string.Empty)
                {
                    responseData += "[]";
                }
                responseData = responseData.Remove(responseData.Length - 1);
                responseData += serializeObject + "," + "]";
                File.WriteAllText(path, responseData);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
