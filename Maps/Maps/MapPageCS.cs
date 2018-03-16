using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Maps
{
	public class MapPageCS : ContentPage
	{
		public MapPageCS()
		{
			var customMap = new CustomMap
			{
				MapType = MapType.Street,
				WidthRequest = App.ScreenWidth,
				HeightRequest = App.ScreenHeight
			};

			var pin = new CustomPin
			{
				Pin = new Pin
				{
					Type = PinType.Place,
                    Position = new Position(32.754795, -97.331384),
					Label = "Xamarin San Francisco Office",
                    Address = "Sundance Square, Fortworth TX"

				},
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"
			};

			customMap.CustomPins = new List<CustomPin> { pin };
			customMap.Pins.Add(pin.Pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(32.754795, -97.331384), Distance.FromMiles(0.08)));

			Content = customMap;
		}
	}
}
