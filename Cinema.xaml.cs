using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using KinomaniakInterfejsPart1wpf.Annotations;
using KinomaniakInterfejsPart1wpf.Classes;

namespace KinomaniakInterfejsPart1wpf
{
    /// <summary>
    /// Interaction logic for Cinema.xaml
    /// </summary>
    public partial class Cinema : Window
    {
        public List<Movie> Movies { get; set; }

        public Cinema(List<Movie> movies)
        {
            InitializeComponent();
            DataContext = this;
            Movies = movies;
        }

        private void ListBoxMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LabelGenres.Content = string.Join(",", ((Movie) ListBoxMovies.SelectedItem).genres);
                // Brak bindowania, probem z DataContext
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new MovieDetails((Movie)ListBoxMovies.SelectedItem).ShowDialog();
        }

    }
}
