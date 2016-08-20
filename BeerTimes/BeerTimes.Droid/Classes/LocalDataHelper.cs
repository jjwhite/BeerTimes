using System;
using Xamarin.Forms;
using Android.Content;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite.Net.Interop;
using BeerTimes.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(LocalDataHelper_Android))]

namespace BeerTimes.Droid
{
    class LocalDataHelper_Android : Java.Lang.Object, ILocalDataHelper
    {
        public LocalDataHelper_Android() { }

        public ISQLitePlatform GetPlatform()
        {
            return new SQLitePlatformAndroid();
        }
    }
}