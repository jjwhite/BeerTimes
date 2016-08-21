using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace BeerTimes
{
    public class App : Application
    {

        //public Entry SearchField = new Entry()
        //{
        //    Placeholder = "Enter a Beer"
        //};

        //public Button SearchButton = new Button()
        //{
        //    Text = "Search"
        //};

        //ListView ResultsList = new ListView();

        public App()
        {

            // The root page of your application
            
            MainPage = new RootPage();

          
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //           SearchField,
            //           SearchButton,
            //           ResultsList
            //        }
            //    }
            //};


            //SearchButton.Clicked += async (sender, e) =>
            //{
            //    Task<List<Beer>> getBeersTask = Beer.GetBeersByName(SearchField.Text);
            //    List<Beer> r = await getBeersTask;

            //    List<string> listSource = new List<string>();
            //    foreach (Beer b in r)
            //    {
            //        listSource.Add(b.name);
            //    }

            //    ResultsList.ItemsSource = listSource.ToArray();

            //};

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        
    }
}
