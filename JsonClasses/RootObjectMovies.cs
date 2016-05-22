using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KinomaniakInterfejsPart1wpf.Classes
{
    public class RootObjectMovies
    {
        public int page { get; set; }
        public List<Movie> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
 
    }
}
