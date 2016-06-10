using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinomaniakInterfejsPart1wpf.Classes;

namespace KinomaniakInterfejsPart1wpf.BasicClasses
{
    class MyList : List<Movie>
    {
        private readonly static MyList instance = new MyList();

        private MyList() { }

        public static MyList Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
