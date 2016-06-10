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

namespace KinomaniakInterfejsPart1wpf
{
    /// <summary>
    /// Interaction logic for EventModalWindow.xaml
    /// </summary>
    public partial class EventModalWindow : Window, INotifyPropertyChanged
    {
        public DateTime Date { get; set; }
     
        private string eventName;

        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                OnPropertyChanged("EventName");
            }
        }

        private string place;

        public string Place
        {
            get { return place; }
            set
            {
                place = value;
                OnPropertyChanged("Place");
            }
        }

        public EventModalWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        public EventModalWindow(Event occasion)
        {
            Date = occasion.eventDate;
            Place = occasion.eventPlace;
            EventName = occasion.eventName;    
            InitializeComponent();
            DataContext = this;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}