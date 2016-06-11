using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        private void ChangeContentCommandExecute(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter.Equals("Cinema"))
                Content.Content = new Cinema();
            else if (e.Parameter.Equals("AllMovies"))
                Content.Content = new AllMovies(TypeOfMovies.AllMovies);
            else if (e.Parameter.Equals("WatchedMovies"))
                Content.Content = new AllMovies(TypeOfMovies.Watched);
            else if (e.Parameter.Equals("Wishes"))
                Content.Content = new AllMovies(TypeOfMovies.Wishes);
            else if (e.Parameter.Equals("Calendar"))
                Content.Content = new Calendar();
        }

        private void ChangeContentCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
