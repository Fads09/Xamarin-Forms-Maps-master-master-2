using System;

using Xamarin.Forms;

namespace Maps
{
	public class App : Application
	{
		public static double ScreenHeight;
		public static double ScreenWidth;

		public App()
		{
			

            var tabs = new TabbedPage();

            // demonstrates the map control with zooming and map-types
            tabs.Children.Add(new MapPageCS { Title = "Map", Icon = "ic_streetview.png" });

            tabs.Children.Add(new Shopping { Title = "Shopping", Icon = "ic_local_mall.png" });

            tabs.Children.Add(new Restaurant { Title = "Restaurant", Icon = "ic_local_dining.png" });

            tabs.Children.Add(new Entertainment { Title = "Entertainment", Icon = "ic_local_movies.png" });


            MainPage = tabs;
		}

	
	}
}
