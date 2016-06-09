using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinomaniakInterfejsPart1wpf
{
    public class Event
    {
        //public DateTime eventDate { get; set; }
        public string eventName { get; set; }
        public string eventPlace { get; set; }

        
        //public string eventPriority { get; set; } // grafika w postaci różnokolorowych gwiazdek ????

        public override string ToString()
        {
            return eventName + " " + eventPlace;
        }
    }

}
