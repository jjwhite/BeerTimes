using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace BeerTimes
{
    public class SearchPage : ContentPage
    {
        public SearchPage()
        {
           Title = "Search";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                       SearchField,
                       SearchButton,
                       ResultsList
                    }
            };

            SearchButton.Clicked += async (sender, e) =>
            {
                Task<List<Beer>> getBeersTask = Beer.GetBeersByName(SearchField.Text);
                List<Beer> r = await getBeersTask;

                List<string> listSource = new List<string>();
                foreach (Beer b in r)
                {
                    listSource.Add(b.name);
                }

                ResultsList.ItemsSource = listSource.ToArray();

            };
        }

        public Entry SearchField = new Entry()
        {
            Placeholder = "Enter a Beer"
        };

        public Button SearchButton = new Button()
        {
            Text = "Search"
        };

        ListView ResultsList = new ListView();


    }
}
