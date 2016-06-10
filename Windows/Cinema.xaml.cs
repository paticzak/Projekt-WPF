using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KinomaniakInterfejsPart1wpf.Classes;

namespace KinomaniakInterfejsPart1wpf
{
    /// <summary>
    /// Interaction logic for Cinema.xaml
    /// </summary>
    public partial class Cinema : UserControl
    {
        public Cinema()
        {
            InitializeComponent();
            Movies = new ObservableCollection<Movie>(FileOperations.GetUpcomingMovies());
            MoviesView = CollectionViewSource.GetDefaultView(Movies);
            DataContext = this;
        }

        public ICollectionView MoviesView { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new MovieDetails((Movie) ListBoxMovies.SelectedItem).ShowDialog();
        }
    }
}
