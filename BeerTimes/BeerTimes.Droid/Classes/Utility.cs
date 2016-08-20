using System.IO;
using BeerTimes.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Utility_Android))]

namespace BeerTimes.Droid
{
    public class Utility_Android : IUtility
    {
        public void LogMessage(string title, string message)
        {
            string _msg = System.Environment.NewLine + "*********************************************"
            + System.Environment.NewLine + message
            + System.Environment.NewLine + "*********************************************"
            + System.Environment.NewLine;
            Android.Util.Log.Debug(title, _msg);
        }

        public string GetDBPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BeerTimes.db");
        }

    }
}