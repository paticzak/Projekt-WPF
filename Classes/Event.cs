using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinomaniakInterfejsPart1wpf.Annotations;

namespace KinomaniakInterfejsPart1wpf
{
    public class Event
    {
        public DateTime eventDate { get; set; }
        public string eventName { get; set; }
        public string eventPlace { get; set; }

        
        //public string eventPriority { get; set; } // grafika w postaci różnokolorowych gwiazdek ????

        public override string ToString()
        {
            return "Tittle: " + eventName + "\nPlace: " + eventPlace;
        }

        public Event(DateTime date, string name, string place)
        {
            eventName = name;
            eventDate = date;
            eventPlace = place;
        }

        public Event()
        {
            
        }
    }

}
