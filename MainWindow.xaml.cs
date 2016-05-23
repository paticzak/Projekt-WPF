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

        public MainWindow()
        {
            InitializeComponent();
            Movies = FileOperations.GetMovies();
            //Task.Run(() => DownloadUpcomingMovies()).Wait();
            new Cinema(TypeOfMovies.AllMovies).Show();
            this.Close();
        }



        private void MoviesWishes_Click(object sender, RoutedEventArgs e)
        {
            new Cinema(TypeOfMovies.Wishes).Show();
            this.Close();
            
        }

        public async void DownloadUpcomingMovies()
        {
           Movies= await TmdbDownloader.DownloadMovies();
        }
    }
}
