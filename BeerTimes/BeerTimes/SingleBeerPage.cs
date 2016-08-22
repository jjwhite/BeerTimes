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
        public Label commentLabel;
        public Editor comments;
        public Entry rating;

        public Button saveButton;
        public Button addToWishlist;
        public Button deleteButton;

        public StackLayout starLayout;
        public Image starImage1, starImage2, starImage3, starImage4, starImage5;

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

            starImage1 = new Image() { Source = "caprating_off.png" };
            
            starImage2 = new Image() { Source = "caprating_off.png" };
            starImage3 = new Image() { Source = "caprating_off.png" };
            starImage4 = new Image() { Source = "caprating_off.png" };
            starImage5 = new Image() { Source = "caprating_off.png" };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped1;
            starImage1.GestureRecognizers.Add(tapGestureRecognizer);

            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += OnTapGestureRecognizerTapped2;
            starImage2.GestureRecognizers.Add(tapGestureRecognizer2);

            var tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += OnTapGestureRecognizerTapped3;
            starImage3.GestureRecognizers.Add(tapGestureRecognizer3);

            var tapGestureRecognizer4 = new TapGestureRecognizer();
            tapGestureRecognizer4.Tapped += OnTapGestureRecognizerTapped4;
            starImage4.GestureRecognizers.Add(tapGestureRecognizer4);

            var tapGestureRecognizer5 = new TapGestureRecognizer();
            tapGestureRecognizer5.Tapped += OnTapGestureRecognizerTapped5;
            starImage5.GestureRecognizers.Add(tapGestureRecognizer5);

            starLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                      starImage1,
                      starImage2,
                      starImage3,
                      starImage4,
                      starImage5,

                    },
            };

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

            deleteButton = new Button()
            {
                Text = "Delete",
                BackgroundColor = Color.Red
            };


            commentLabel = new Label() {
                Text = "Enter your comments below:",
            };

            comments = new Editor()
            {
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            

            rating = new Entry() {
                Placeholder = "0-5"
            };

            if (theLocalBeer == null)
            {
                deleteButton.IsVisible = false;
            }
            else
            {
                comments.Text = theLocalBeer.comment;
                rating.Text = theLocalBeer.rating.ToString();
            }

            saveButton.Clicked += AddToMyBeers_Clicked;
            addToWishlist.Clicked += AddToWishlist_Clicked;
            deleteButton.Clicked += DeleteButton_Clicked;

            SetRating();

            Content = new StackLayout {
                Children = {
                       name,
                       brewery,
                       ibus,
                       abv,
                       //rating,
                       starLayout,
                       commentLabel,
                       comments,
                       saveButton,
                       addToWishlist,
                       deleteButton
                    },
                Padding = new Thickness(15,20,15, 20),
                Spacing = 15
            };
        
        }

        void OnTapGestureRecognizerTapped1(object sender, EventArgs args)
        {
            theLocalBeer.rating = 1;
            SetRating();

        }

        void OnTapGestureRecognizerTapped2(object sender, EventArgs args)
        {
            theLocalBeer.rating = 2;
            SetRating();

        }

        void OnTapGestureRecognizerTapped3(object sender, EventArgs args)
        {
            theLocalBeer.rating = 3;
            SetRating();

        }

        void OnTapGestureRecognizerTapped4(object sender, EventArgs args)
        {
            theLocalBeer.rating = 4;
            SetRating();

        }

        void OnTapGestureRecognizerTapped5(object sender, EventArgs args)
        {
            theLocalBeer.rating = 5;
            SetRating();

        }

        private void SetRating()
        {
            switch (theLocalBeer.rating) {
                case 1:
                    starImage1.Source = "caprating_on.png";
                    starImage2.Source = "caprating_off.png";
                    starImage3.Source = "caprating_off.png";
                    starImage4.Source = "caprating_off.png";
                    starImage5.Source = "caprating_off.png";
                    break;
                case 2:
                    starImage1.Source = "caprating_on.png";
                    starImage2.Source = "caprating_on.png";
                    starImage3.Source = "caprating_off.png";
                    starImage4.Source = "caprating_off.png";
                    starImage5.Source = "caprating_off.png";
                    break;

                case 3:
                    starImage1.Source = "caprating_on.png";
                    starImage2.Source = "caprating_on.png";
                    starImage3.Source = "caprating_on.png";
                    starImage4.Source = "caprating_off.png";
                    starImage5.Source = "caprating_off.png";
                    break;

                case 4:
                    starImage1.Source = "caprating_on.png";
                    starImage2.Source = "caprating_on.png";
                    starImage3.Source = "caprating_on.png";
                    starImage4.Source = "caprating_on.png";
                    starImage5.Source = "caprating_off.png";

                    break;

                case 5:
                    starImage1.Source = "caprating_on.png";
                    starImage2.Source = "caprating_on.png";
                    starImage3.Source = "caprating_on.png";
                    starImage4.Source = "caprating_on.png";
                    starImage5.Source = "caprating_on.png";

                    break;
            }

        }
        private void AddToMyBeers_Clicked(object sender, System.EventArgs e)
        {
            MyBeerLocal b = new MyBeerLocal()
            {
                id = theBeer.id,
                name = theBeer.name,
                rating = theLocalBeer.rating,
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
               rating = theLocalBeer.rating,
                comment = comments.Text,
                onwishlist = true

            };

            b.save();
        }

        private void DeleteButton_Clicked(object sender, System.EventArgs e)
        {
            theLocalBeer.delete();
        }
    }
}
