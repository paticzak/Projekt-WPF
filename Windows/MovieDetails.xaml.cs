using System;
using System.Collections.Generic;
using System.IO;
using System.Printing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Xps.Packaging;
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

        private void PrintCommandOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Print();
        }

        private void PrintCommandOnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Print()
        {
            var xMargin = 0;
            var yMargin = 0;
            PrintDialog printDlg = new PrintDialog();

            PrintTicket pt = printDlg.PrintTicket;
            Double printableWidth = pt.PageMediaSize.Width.Value;
            Double printableHeight = pt.PageMediaSize.Height.Value;

            Double xScale = (printableWidth - xMargin * 2) / printableWidth;
            Double yScale = (printableHeight - yMargin * 2) / printableHeight;


            this.LayoutTransform = new MatrixTransform(xScale, 0, 0, yScale, xMargin, yMargin);

            Nullable<Boolean> print = printDlg.ShowDialog();
            if (print == true)
            {
                //now print the visual to printer to fit on the one page.
                printDlg.PrintVisual(this, "Print Page");
            }
        }
    }
}
