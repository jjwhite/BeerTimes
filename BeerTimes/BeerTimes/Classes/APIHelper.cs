using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeerTimes
{
    public class APIHelper
    {
        public const string BreweryDBEndpoint = "http://api.brewerydb.com/v2/";
        public const string BreweryDBKey = "b1f0db75a3f10f879d9161b65467b7e3";

        public HttpClient httpClient { get; set; }

        public APIHelper()
        {
            httpClient = new HttpClient();
        }

    }

    public class APIResult
    {
        public string status { get; set; }
        public int numberOfPages { get; set; }
        public int currentPage { get; set; }
    }

    public class BeersResult : APIResult {
        public List<Beer> data;
    }

    public class BeerResult : APIResult {
        public Beer data;
    }


}
