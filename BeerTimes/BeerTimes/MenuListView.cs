using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace BeerTimes
{
    public class MenuListView : ListView
    {
        public MenuListView()
        {
            List<MenuItem> data = new MenuListData();
            ItemsSource = data;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;

            var cell = new DataTemplate(typeof(ImageCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");

            ItemTemplate = cell;
            SelectedItem = data[0];
        }
    }

    public class MenuItem
    {
        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }
    }

    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            this.Add(new MenuItem()
            {
                Title = "Search",
                TargetType = typeof(SearchPage)
            });

            this.Add(new MenuItem()
            {
                Title = "My Beers",
                TargetType = typeof(MyBeersPage)
            });

            this.Add(new MenuItem()
            {
                Title = "Wishlist",
                TargetType = typeof(WishlistPage)
            });

            //this.Add(new MenuItem()
            //{
            //    Title = "Accounts",
            //    IconSource = "accounts.png",
            //    TargetType = typeof(AccountsPage)
            //});

            //this.Add(new MenuItem()
            //{
            //    Title = "Opportunities",
            //    IconSource = "opportunities.png",
            //    TargetType = typeof(OpportunitiesPage)
            //});
        }
    }
}