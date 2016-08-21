using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BeerTimes
{
    public class Beer
    {
        public string id { get; set; }
        public string abv { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string originalGravity { get; set; }
        public string ibu { get; set; }
        public Style style { get; set; }
        public List<Brewery> breweries { get; set; }

        public static async Task<Beer> GetBeerById(string id)
        {
            try
            {
                APIHelper api = new APIHelper();
                string request = APIHelper.BreweryDBEndpoint
                    + "beer/" + WebUtility.UrlEncode(id)
                    + "?withBreweries=Y"
                    + "&key=" + APIHelper.BreweryDBKey;

                HttpResponseMessage response = await api.httpClient.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    BeerResult b = new BeerResult();
                    b = JsonConvert.DeserializeObject<BeerResult>(result);
                    if (b.data != null)
                    {
                        return b.data;
                    }

                    return new Beer();

                }
            }
            catch (Exception ex)
            {
                return new Beer();
            }

            return new Beer();
        }
    

    public static async Task<List<Beer>> GetBeersByName(string name)
    {
        try
        {
            APIHelper api = new APIHelper();
            string request = APIHelper.BreweryDBEndpoint
                + "search?q=" + WebUtility.UrlEncode(name)
                + "&type=beer"
                + "&withBreweries=Y"
                + "&key=" + APIHelper.BreweryDBKey;

            HttpResponseMessage response = await api.httpClient.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                BeersResult b = new BeersResult();
                b = JsonConvert.DeserializeObject<BeersResult>(result);
                if (b.data != null)
                {
                    return b.data;
                }

                return new List<Beer>();
                //This not be working for some reason
                //Utility.LogMessage("Search Results for " + name, result);

            }
        }
        catch (Exception ex)
        {
            return new List<Beer>();
        }

        return new List<Beer>();
    }
}

public class Style
{
    public int id { get; set; }
    public string name { get; set; }
}

public class Brewery
{
    public string id { get; set; }
    public string name { get; set; }
    public BreweryImages images { get; set; }

}

public class BreweryImages
{
    public string medium { get; set; }
    public string large { get; set; }
    public string icon { get; set; }
}





}
