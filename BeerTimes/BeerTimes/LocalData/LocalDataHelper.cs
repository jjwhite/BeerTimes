using System;
using SQLite.Net;
using SQLite.Net.Attributes;
using SQLite.Net.Interop;
using Xamarin.Forms;

namespace BeerTimes
{
    public class LocalDataHelper
    {
        public static SQLiteConnection localconn;

        public static ISQLitePlatform GetPlatform()
        {
            return DependencyService.Get<ILocalDataHelper>().GetPlatform();
        }

        public static SQLiteConnection GetConnection()
        {
           
            if (LocalDataHelper.localconn == null)
            {
                ISQLitePlatform platform = GetPlatform();
                platform.SQLiteApi.Shutdown();

                platform.SQLiteApi.Config(ConfigOption.Serialized);
                platform.SQLiteApi.Initialize();

                LocalDataHelper.localconn = new SQLiteConnectionWithLock(platform, new SQLite.Net.SQLiteConnectionString(Utility.GetDBPath(), true));

                //SQLiteConnection localconn = new SQLiteConnection(GetPlatform(), Settings.GetDBPath());
                LocalDataHelper.localconn.CreateTable<MyBeerLocal>();
                //localconn.CreateTable<MathwayUserLocal>();
                //localconn.CreateTable<ChatHistoryLocal>();
                //localconn.CreateTable<MathwaySolutionsLocal>();

                //Config.Init();

            }

            return LocalDataHelper.localconn;
        }
    }
}
