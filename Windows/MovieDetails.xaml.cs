using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KinomaniakInterfejsPart1wpf.Classes;

namespace KinomaniakInterfejsPart1wpf
{
    /// <summary>
    /// Interaction logic for MovieDetails.xaml
    /// </summary>
    public partial class MovieDetails : Window
    {
        public Movie SelectedMovie { get; set; }
        public List<VideoInformation> Videos { get; set; }

        public MovieDetails(Movie movie)
        {
            InitializeComponent();
            SelectedMovie = movie;
            Task.Run(() => DownloadVideoInformation()).Wait();
            DataContext = this;
            MovieTrailer.Navigate(new Uri("https://www.youtube.com/embed/" + Videos[0].key + "?autoplay=1"));

        }

        protected override void OnClosed(EventArgs e)
        {
            MovieTrailer.Dispose();
            this.Close();
        }

        public async Task DownloadVideoInformation()
        {
            Videos = await TmdbDownloader.DownloadVideoInformation(SelectedMovie.id);
        }


        private void SaveCommandOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void SaveCommandOnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
