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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KinomaniakInterfejsPart1wpf.Annotations;

namespace KinomaniakInterfejsPart1wpf
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : INotifyPropertyChanged
    {
        private List<Event> Events = new List<Event>();

        private DateTime chosenDay;

        public DateTime ChosenDay
        {
            get { return chosenDay; }
            set
            {
                chosenDay = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }

        public Event SelectedEvent
        {
            get { return Events.FirstOrDefault(x => x.eventDate == ChosenDay); }
            set
            {
                Events[Events.IndexOf(SelectedEvent)] = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }

        public Calendar()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void AddOn_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            EventModalWindow eventt = new EventModalWindow();
            if (eventt.ShowDialog() == true)
            {
                Events.Add(new Event(ChosenDay, eventt.EventName, eventt.Place));
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }

        private void EditOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            EventModalWindow eventt = new EventModalWindow(SelectedEvent);
            if (eventt.ShowDialog() == true)
            {
                SelectedEvent = new Event(eventt.Date, eventt.EventName, eventt.Place);
            }
        }

        private void DeleteOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Events.RemoveAt(Events.IndexOf(SelectedEvent));
            OnPropertyChanged(nameof(SelectedEvent));
        }

        private void ShowDetailsOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            new EventModelessWindow(SelectedEvent).Show();
        }

        private void AddOnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void EditDeleteDetailsOnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = SelectedEvent != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}
