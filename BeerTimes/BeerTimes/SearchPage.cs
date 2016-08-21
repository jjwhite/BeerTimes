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

                List<BeerCell> listSource = new List<BeerCell>();

                var cell = new DataTemplate(typeof(ImageCell));
                cell.SetBinding(TextCell.TextProperty, "Name");
                cell.SetBinding(TextCell.DetailProperty, new Binding("Brewery", stringFormat: "{0}"));
                cell.SetBinding(ImageCell.ImageSourceProperty, "Image");

                foreach (Beer b in r)
                {
                    string brewery = "";
                    string icon = "";
                    if (b.breweries != null && b.breweries.Count > 0)
                    {
                        brewery = b.breweries[0].name;
                        if (b.breweries[0].images != null && !String.IsNullOrEmpty(b.breweries[0].images.icon))
                        {
                            icon = b.breweries[0].images.icon;
                        }
                    }
                    
                    listSource.Add(new BeerCell(
                        b.id,
                        b.name,
                        brewery,
                        icon
                        ));
                }

                ResultsList.ItemsSource = listSource;
                ResultsList.ItemTemplate = cell;

            };


            ResultsList.ItemSelected += (sender, e) =>
            {
                //((ListView)sender).SelectedItem = null;

                BeerCell bc = e.SelectedItem as BeerCell;
                //App.Current.MainPage(new SingleBeerPage(bc.Id));

                //RootPage rp = App.Current.MainPage as RootPage;
                //rp.Detail = new NavigationPage(new SingleBeerPage(bc.Id));

                Navigation.PushModalAsync(new SingleBeerPage(bc.Id));
                
                
                //MyBeerLocal b = new MyBeerLocal()
                //{
                //    id = bc.Id,
                //    name = bc.Name
                //};

                //b.save();


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

        public ListView ResultsList = new ListView();



    }


    public class BeerCell
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Brewery { get; set; }
        public string Image { get; set; }

        public BeerCell(string id, string name, string brewery, string image)
        {
            this.Id = id;
            this.Name = name;
            this.Brewery = brewery;
            this.Image = image;
        }
    }


}
