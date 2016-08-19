using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BeerTimes
{
    public static class Utility
    {
        public static void LogMessage(string title, string message)
        {
            DependencyService.Get<IUtility>().LogMessage(title, message);
        }
    }
}
