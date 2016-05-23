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
        public static List<Movie> GetMoviesWithoutGenres()
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

        public static List<Movie> GetUpcomingMoviesWithourGenres()
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
            var movies = GetUpcomingMoviesWithourGenres();
            var genres = GetGenres();
            return GenreConverter.ConvertGenresIdToNames(movies, genres);

        }

        public static List<Movie> GetMovies()
        {
            var movies = GetMoviesWithoutGenres();
            var genres = GetGenres();
            var deletedMovies = GetDeletedMovies();
            if (deletedMovies != null)
            {
                foreach (Movie deletedMovie in deletedMovies)
                {
                    var itemToRemove = movies.SingleOrDefault(r => r.id == deletedMovie.id);
                    if (itemToRemove != null)
                    {
                        movies.Remove(itemToRemove);
                    }
                }
            }
            return GenreConverter.ConvertGenresIdToNames(movies, genres);
        }

        public static List<Genre> GetGenres()
        {
            var responseData =
                    File.ReadAllText(@"C:\Users\Kamil\Desktop\Studia\WPF\Projekt\Projekt-WPF\genres.txt");
            var model = JsonConvert.DeserializeObject<RootObjectGenres>(responseData);
            return model.genres;
        }

        public static List<Movie> GetMoviesToWatch()
        {
            string responseData = string.Empty;
            try
            {
                responseData =
                    File.ReadAllText(@"C:\Users\Kamil\Desktop\Studia\WPF\Projekt\Projekt-WPF\wishesMovies.txt");
            }
            catch
            {
                MessageBox.Show("Zła ścieżka");
                return new List<Movie>();
            }
            var model = JsonConvert.DeserializeObject<List<Movie>>(responseData);
            return model;
        }

        public static List<Movie> GetDeletedMovies()
        {
            string responseData = string.Empty;
            try
            {
                responseData =
                    File.ReadAllText(@"C:\Users\Kamil\Desktop\Studia\WPF\Projekt\Projekt-WPF\deletedMovies.txt");
            }
            catch
            {
                MessageBox.Show("Zła ścieżka");
                return new List<Movie>();
            }
            var model = JsonConvert.DeserializeObject<List<Movie>>(responseData);
            return model;
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
