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
        public Label abv;
        public Label ibus;
        public Label style;
        public Entry comments;
        public Entry rating;

        public Button saveButton;
        public Button addToWishlist;
        public Button delete;

        public Beer theBeer;
        public MyBeerLocal theLocalBeer;

        public SingleBeerPage(string beerId)
        {
            var ignore = LoadBeer(beerId);

        }

        async Task LoadBeer(string beerId)
        {
            Task<Beer> getBeerTask = Beer.GetBeerById(beerId);
            theBeer = await getBeerTask;

            theLocalBeer = MyBeerLocal.GetMyBeerById(beerId);
            

            Title = theBeer.name;
            name = new Label()
            {
                Text = theBeer.name,
                FontSize = 25.0,
                HorizontalTextAlignment = TextAlignment.Center,
            };

            brewery = new Label() {
                Text = theBeer.breweries.Count > 0 ? theBeer.breweries[0].name : ""
            };

            abv = new Label() {
                Text = "ABV: " + theBeer.abv
            };

            ibus = new Label() {
                Text = "IBUs: " + theBeer.ibu
            };

            saveButton = new Button()
            {
                Text = "Save",
                BackgroundColor = Color.Green
            };

            addToWishlist = new Button()
            {
                Text = "Add to Wishlist",
                BackgroundColor = Color.Gray
            };

            delete = new Button()
            {
                Text = "Delete",
                BackgroundColor = Color.Red
            };

           
            comments = new Entry()
            {
                MinimumHeightRequest = 200d,
                Placeholder = "Enter your comments"
            };
            

            rating = new Entry() {
                Placeholder = "0-5"
            };

            if (theLocalBeer == null)
            {
                delete.IsVisible = false;
            }
            else
            {
                comments.Text = theLocalBeer.comment;
                rating.Text = theLocalBeer.rating.ToString();
            }

            saveButton.Clicked += AddToMyBeers_Clicked;
            addToWishlist.Clicked += AddToWishlist_Clicked;

            Content = new StackLayout {
                Children = {
                       name,
                       brewery,
                       ibus,
                       abv,
                       rating,
                       comments,
                       saveButton,
                       addToWishlist,
                       delete
                    },
                Padding = new Thickness(15,20,15, 20),
                Spacing = 15
            };
        
        }

        private void AddToMyBeers_Clicked(object sender, System.EventArgs e)
        {
            MyBeerLocal b = new MyBeerLocal()
            {
                id = theBeer.id,
                name = theBeer.name,
                rating = Convert.ToInt16(rating.Text),
                comment = comments.Text,
                onwishlist = false

            };

            b.save();
        }

        private void AddToWishlist_Clicked(object sender, System.EventArgs e)
        {
            MyBeerLocal b = new MyBeerLocal()
            {
                id = theBeer.id,
                name = theBeer.name,
                rating = Convert.ToInt16(rating.Text),
                comment = comments.Text,
                onwishlist = true

            };

            b.save();
        }
    }
}
