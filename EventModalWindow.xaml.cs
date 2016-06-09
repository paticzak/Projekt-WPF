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

namespace KinomaniakInterfejsPart1wpf
{
    /// <summary>
    /// Interaction logic for EventModalWindow.xaml
    /// </summary>
    public partial class EventModalWindow : Window
    {
        public EventModalWindow()
        {
            InitializeComponent();
        }

        public Event Occasion { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // date.Text = Occasion.eventDate;
            name.Text = Occasion.eventName;
            place.Text = Occasion.eventPlace;

        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            //Occasion.eventDate = date.Text;
            Occasion.eventName = name.Text;
            Occasion.eventPlace = place.Text;
            DialogResult = true;
            Close();

        }

   
    }
}
