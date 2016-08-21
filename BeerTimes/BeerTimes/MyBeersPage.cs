using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BeerTimes
{
    public class MyBeersPage : ContentPage
    {
        ListView BeerList = new ListView();

        public MyBeersPage()
        {
            Title = "My Beers";
            Content = new StackLayout {
                Children =
                {
                    BeerList
                }
            };

            //MyBeerLocal.BuildMockBeerList();
            CreateBeerList();


        }

        private void CreateBeerList()
        {
            List<MyBeerLocal> localBeer = MyBeerLocal.GetMyBeers();
            List<string> beerNames = new List<string>();

            foreach(MyBeerLocal b in localBeer)
            {
                beerNames.Add(b.name);
            }

            BeerList.ItemsSource = beerNames.ToArray();
        }
    }
}
