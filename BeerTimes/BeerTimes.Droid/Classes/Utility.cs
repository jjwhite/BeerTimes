using System.IO;
using BeerTimes.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Utility_Android))]

namespace BeerTimes.Droid
{
    public class Utility_Android
    {
        public void LogMessage(string title, string message)
        {
            string _msg = System.Environment.NewLine + "*********************************************"
            + System.Environment.NewLine + message
            + System.Environment.NewLine + "*********************************************"
            + System.Environment.NewLine;
            Android.Util.Log.Debug(title, _msg);
        }

    }
}