using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Net.Http;
using Newtonsoft.Json;

namespace Maps
{
    public class Restaurant : ContentPage
    {
        Map map;

        public Restaurant()
        {
            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 360,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

           
            var centerLat = 32.754795;
            var centerLng = -97.331384;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(centerLat, centerLng), Distance.FromMiles(0.1))); // Santa Cruz golf course
            var client = new HttpClient();
            var uri = " https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=32.754795,-97.331384&radius=400&type=restaurant&key=AIzaSyCoR5KG31h_taL3kdyPqEHeciZMe5_1R50";
              
            string obstring = client.GetStringAsync(uri).Result;
            var responses = JsonConvert.DeserializeObject<GoogleResponse>(obstring);
            if (responses.results != null)
            {
                foreach (var response in responses.results)
                {
                    var position = new Position(response.geometry.location.lat, response.geometry.location.lng); // Latitude, Longitude
                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = response.name,
                        Address = response.vicinity
                    };
                    map.Pins.Add(pin);
                }
            }
 
           

            // put the page together
            Content = new StackLayout
            {
                Spacing = 0,
                Children = {
                    map
                }
            };
        }
    }
}