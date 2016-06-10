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
    /// Interaction logic for EventModelessWindow.xaml
    /// </summary>
    public partial class EventModelessWindow : Window, INotifyPropertyChanged
    {

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

        public EventModelessWindow(Event occasion)
        {
            Place = occasion.eventPlace;
            Name = occasion.eventName;
            InitializeComponent();
            DataContext = this;
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
