using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Cinema : Window, INotifyPropertyChanged
    {
        public ICollectionView Movies { get; set; }

        private string _titleFilter;

        public string TitleFilter
        {
            get { return _titleFilter; }
            set
            {
                _titleFilter = value;
                OnPropertyChanged(nameof(TitleFilter));
                Filter();
            }
        }

        public Cinema(List<Movie> movies)
        {
            InitializeComponent();
            DataContext = this;
            Movies = CollectionViewSource.GetDefaultView(movies);
        }

        private ListCollectionView View
        {
            get { return (ListCollectionView)CollectionViewSource.GetDefaultView(Movies); }
        }

        private void ListBoxMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlockGenres.Text = string.Join("\n", ((Movie)ListBoxMovies.SelectedItem).genres);
            // Brak bindowania, probem z DataContext
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new MovieDetails((Movie)ListBoxMovies.SelectedItem).ShowDialog();
        }

        private void Filter()
        {
            View.Filter = delegate (object item)
            {
                var movie = item as Movie;
                if (movie == null) return false;
                return movie.title.ToLower().Contains(TitleFilter.ToLower());
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void ComboBoxItemSort_OnSelected(object sender, RoutedEventArgs e)
        {
            Movies.SortDescriptions.Add(new SortDescription("title", ListSortDirection.Ascending));
        }

         private void ComboBoxItemGrouping_OnSelected(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.SortDescriptions.Add(new SortDescription("title", ListSortDirection.Ascending));
            FirstLetterConverter grouper = new FirstLetterConverter();
            View.GroupDescriptions.Add(new PropertyGroupDescription("title", grouper));
        }

        private void ComboBoxItemWithoutGrouping_OnSelected(object sender, RoutedEventArgs e)
        {
            if(View != null)
            {
                View.GroupDescriptions.Clear();
            }
            
        }

        private void ComboBoxItemGroupingGenre_OnSelected(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.SortDescriptions.Add(new SortDescription("title", ListSortDirection.Ascending));
            GenreGrouper grouper = new GenreGrouper();
            View.GroupDescriptions.Add(new PropertyGroupDescription("genresString", grouper));
        }
    }
}
