using System;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BeerTimes
{
    class SingleBeerPage : ContentPage
    {
        public Label name;
        public Label brewery;
        public Entry comments;
        public Entry rating;

        public Button addToMyBeers;
        public Beer theBeer;

        public SingleBeerPage(string beerId)
        {
            var ignore = LoadBeer(beerId);

        }

        async Task LoadBeer(string beerId)
        {
            Task<Beer> getBeerTask = Beer.GetBeerById(beerId);
            theBeer = await getBeerTask;
            Title = theBeer.name;
            name = new Label()
            {
                Text = theBeer.name
            };

            brewery = new Label() {
                Text = theBeer.breweries.Count > 0 ? theBeer.breweries[0].name : ""
            };

            addToMyBeers = new Button()
            {
                Text = "Add To My Beers"
            };

            comments = new Entry()
            {
                MinimumHeightRequest = 200d,
                Placeholder = "Enter your comments"
            };

            rating = new Entry() {
                Placeholder = "0-5"
            };

            addToMyBeers.Clicked += AddToMyBeers_Clicked;

            Content = new StackLayout {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                       name,
                       brewery,
                       rating,
                       comments,
                       addToMyBeers
                    }
            };
        
        }

        private void AddToMyBeers_Clicked(object sender, System.EventArgs e)
        {
            MyBeerLocal b = new MyBeerLocal()
            {
                id = theBeer.id,
                name = theBeer.name,
                rating = Convert.ToInt16(rating.Text),
                comment = comments.Text

            };

            b.save();
        }
    }
}
