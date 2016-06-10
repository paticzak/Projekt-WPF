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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MoviesWishes_Click(object sender, RoutedEventArgs e)
        {
            Content.Content = new AllMovies(TypeOfMovies.Wishes);
        }

        public async void DownloadUpcomingMovies()
        {
          // Movies= await TmdbDownloader.DownloadMovies();
        }

        private void BaseOfAllMovies_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = new AllMovies(TypeOfMovies.AllMovies);
        }

        private void MyWatchedMovies_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = new AllMovies(TypeOfMovies.Watched);
        }

        private void Cinema_Click(object sender, RoutedEventArgs e)
        {
            Content.Content = new Cinema();
        }

        private void MyCalendar_Click(object sender, RoutedEventArgs e)
        {
            Content.Content = new Calendar();
        }
    }
}
