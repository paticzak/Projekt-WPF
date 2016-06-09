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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KinomaniakInterfejsPart1wpf
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public DateTime ChosenDay { get; set; }
        public Calendar()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        //wyświetlało komunikat do konkretnego dnia, tylko wiadomośc zawsze taka sama, zmienia się jedynie data
        //private void Chosen_Day_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    string msg;
 
        //    if (ChosenDay == null)
        //        msg = "Choose a day.";
        //    else
        //        msg = string.Format("My favorite day is {0:D}",ChosenDay");
 
        //    MessageBox.Show(msg);
        //}

        private void add_event_Click(object sender, RoutedEventArgs e)
        {
            EventModalWindow eventt = new EventModalWindow();
            eventt.Occasion = new Event();
            if(eventt.ShowDialog() == true)
            {                 
                Event happening = new Event();
                if (ChosenDay != null)
                {
                    happening.eventName = string.Format("My favorite day is {0:D}", ChosenDay); // nic nie wyświetla
                }
                happening.eventName = eventt.Occasion.eventName;
                happening.eventPlace = eventt.Occasion.eventPlace;
                //eventList.Items.Add(happening); // wyrzuca błąd :(
            }
        }
    }
}
