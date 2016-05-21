﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace KinomaniakInterfejsPart1wpf.Classes
{
    static class TmdbDownloader
    {
        public static async Task<List<Movie>> DownloadMovies()
        {
            List<Movie> movies = new List<Movie>();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var baseAddress = new Uri("http://api.themoviedb.org/3/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                for (int i = 96; i < 101; i++)
                {
                    using (
                        var response =
                            await
                                httpClient.GetAsync(
                                    "discover/movie?sort_by=popularity.desc&api_key=cdade19d0a427c5bab165ed826c78978&page=" + i)
                        )
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        var model = JsonConvert.DeserializeObject<RootObjectMovies>(responseData);
                        movies.AddRange(model.results);
                        //using (StreamWriter sw = File.AppendText(@"C:\Users\Kamil\Desktop\Studia\WPF\Projekt\Projekt-WPF\movies.txt"))
                        //{
                        //    sw.Write(responseData + ",");
                        //}  
                        // Zapisywanie filmów do pliku
                    }
                }
            }
            return movies;
        }

        public static async Task<List<Genre>> DownloadGenres()
        {
            var genres = new List<Genre>();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var baseAddress = new Uri("http://api.themoviedb.org/3/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");


                using (
                    var response =
                        await
                            httpClient.GetAsync(
                                "genre/movie/list?sort_by=popularity.desc&api_key=cdade19d0a427c5bab165ed826c78978")
                    )
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<RootObjectGenres>(responseData);
                    genres = model.genres;
                }
            }
            return genres;
        }

    }
}

