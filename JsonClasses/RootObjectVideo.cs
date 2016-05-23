using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinomaniakInterfejsPart1wpf.Classes;

namespace KinomaniakInterfejsPart1wpf.JsonClasses
{
    class RootObjectVideo
    {
        public int id { get; set; }
        public List<VideoInformation> results { get; set; }
    }
}
