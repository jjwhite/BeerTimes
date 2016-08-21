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
            Content = new StackLayout
            {
                Children =
                {
                    BeerList
                }
            };

            //MyBeerLocal.BuildMockBeerList();
            CreateBeerList();
            BeerList.ItemSelected += (sender, e) =>
            {
                MyBeerCell bc = e.SelectedItem as MyBeerCell;
                Navigation.PushModalAsync(new SingleBeerPage(bc.Id));
            };

        }

        private void CreateBeerList()
        {
            List<MyBeerLocal> localBeer = MyBeerLocal.GetMyBeers();
            List<MyBeerCell> listSource = new List<MyBeerCell>();

            var cell = new DataTemplate(typeof(ImageCell));
            cell.SetBinding(TextCell.TextProperty, "Name");

            foreach (MyBeerLocal b in localBeer)
            {
                listSource.Add(new MyBeerCell(
                        b.id,
                        b.name
                        ));
            }

            BeerList.ItemsSource = listSource;
            BeerList.ItemTemplate = cell;
        }




    }


    public class MyBeerCell
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public MyBeerCell(string id, string name)
        {
            this.Id = id;
            this.Name = name;

        }
    }
}
