using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using Newtonsoft.Json;


namespace KinomaniakInterfejsPart1wpf
{
    /// <summary>
    /// Interaction logic for AllMovies.xaml
    /// </summary>
    public partial class AllMovies : UserControl, INotifyPropertyChanged
    {
        public AllMovies(TypeOfMovies type)
        {
            InitializeComponent();
            List<Movie> movies = new List<Movie>();
            movies = type == TypeOfMovies.AllMovies ? FileOperations.GetMovies() : FileOperations.GetMoviesToWatch();
            Movies = new ObservableCollection<Movie>(movies);
            MoviesView = CollectionViewSource.GetDefaultView(Movies);
            DataContext = this;
        }


        public ICollectionView MoviesView { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        private string _titleFilter;

        public string TitleFilter
        {
            get { return _titleFilter; }
            set
            {
                _titleFilter = value;
                OnPropertyChanged("TitleFilter");
                Filter();
            }
        }
        private ListCollectionView View
        {
            get { return (ListCollectionView)CollectionViewSource.GetDefaultView(MoviesView); }
        }

        private void ListBoxMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxMovies.SelectedItem != null)
            {
                TextBlockGenres.Text = string.Join("\n", ((Movie)ListBoxMovies.SelectedItem).genres);
            }
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

        private void ComboBoxItemSort_OnSelected(object sender, RoutedEventArgs e)
        {
            MoviesView.SortDescriptions.Add(new SortDescription("title", ListSortDirection.Ascending));
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
            if (View != null)
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

        public void AddToWishes()
        {
            var movie = (Movie)ListBoxMovies.SelectedItem;
            var serializeObject = JsonConvert.SerializeObject(movie);
            FileOperations.SaveMovieToFile(serializeObject,
                @"C:\Users\Kamil\Desktop\Studia\WPF\Projekt\Projekt-WPF\wishesMovies.txt");
        }

        public void DeleteMovie()
        {
            var movie = (Movie)ListBoxMovies.SelectedItem;
            var serializeObject = JsonConvert.SerializeObject(movie);
            Movies.Remove(movie);
            FileOperations.SaveMovieToFile(serializeObject,
                @"C:\Users\Kamil\Desktop\Studia\WPF\Projekt\Projekt-WPF\deletedMovies.txt");


        }

        private void AddToWishesCommandExecute(object sender, ExecutedRoutedEventArgs e)
        {
            AddToWishes();
        }

        private void AddToWishesCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ListBoxMovies.SelectedItem != null;
        }

        private void DeleteMovieCommandExecute(object sender, ExecutedRoutedEventArgs e)
        {
            DeleteMovie();
        }

        private void DeleteMovieCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ListBoxMovies.SelectedItem != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonCinema_Click(object sender, RoutedEventArgs e)
        {
            new ActualRepertuar().Show();
        }
    }
}

