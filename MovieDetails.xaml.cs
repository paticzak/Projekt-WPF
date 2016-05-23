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

        //public WebBrowser UrlVideo
        //{
        //    get
        //    {
        //        return new WebBrowser()
        //        {
        //            Source = new Uri("https://www.youtube.com/embed/" + Videos[0].key + "?autoplay=1")
        //        };

        //    }
        //}

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
            //MovieTrailer.Source = null;
            this.Close();
        }



        public async Task DownloadVideoInformation()
        {
            Videos = await TmdbDownloader.DownloadVideoInformation(SelectedMovie.id);
        }
    }
}
