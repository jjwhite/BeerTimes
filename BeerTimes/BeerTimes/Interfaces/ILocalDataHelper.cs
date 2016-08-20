using System;
using SQLite.Net.Interop;

namespace BeerTimes
{
    public interface ILocalDataHelper
    {
        ISQLitePlatform GetPlatform();
    }
}
