using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using KinomaniakInterfejsPart1wpf.Classes;
using System.Net.Http;
using System.Threading;

namespace KinomaniakInterfejsPart1wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; } 

        public MainWindow()
        {
            InitializeComponent();
            Task.Run(GetGenres).Wait();
            Task.Run(GetMovies).Wait();
            ConvertGenresIdToNames();
            Cinema cinema = new Cinema(Movies);
            cinema.Show();
            this.Close();
        }

        public async Task GetMovies()
        {
            Movies = await TmdbDownloader.DownloadMovies();
        }

        public async Task GetGenres()
        {
            Genres = await TmdbDownloader.DownloadGenres();
        }

        public void ConvertGenresIdToNames()
        {
            foreach (Movie movie in Movies)
            {
                foreach (int t1 in movie.genre_ids)
                {
                    foreach (Genre t in Genres.Where(t => t1 == t.id))
                    {
                        movie.genres.Add(t.name);
                    }
                }
            }
        }
    }
}
