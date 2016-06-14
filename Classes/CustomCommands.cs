using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KinomaniakInterfejsPart1wpf.Classes
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Add = new RoutedUICommand();
        public static readonly RoutedUICommand Delete = new RoutedUICommand();
        public static readonly RoutedUICommand Edit = new RoutedUICommand();
        public static readonly RoutedUICommand ShowDetails = new RoutedUICommand();
        public static readonly RoutedUICommand ChangeContent = new RoutedUICommand();
        public static readonly RoutedUICommand Close = new RoutedUICommand();
        public static readonly RoutedUICommand Save = new RoutedUICommand();
        public static readonly RoutedUICommand Print = new RoutedUICommand();

    }
}

