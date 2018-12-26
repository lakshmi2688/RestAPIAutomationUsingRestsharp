using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class RestAPIHelper
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string baseURL = "https://samples.openweathermap.org";
        public static string baseURLPost = "http://216.10.245.166";

        //GET REQUEST WITH NO PARAMETERS PASSED EXPLICITLY
        public static RestClient GetUrl(string resource)
        {
            var url = baseURL + resource;
            Console.WriteLine("url : " + url);
            return client = new RestClient(url);
        }

        public static RestRequest GetRequest()
        {
            restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public static IRestResponse GetResponse()
        {
            return client.Execute(restRequest);
        }


        //GET REQUEST WITH PARAMETERS PASSED EXPLICITLY
        public static RestRequest GetRequestWithParams(string zip,string country,string appid)
        {
            restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");
            restRequest.Resource = "/data/{id}/weather";
            restRequest.AddUrlSegment("id", "2.5");
            restRequest.AddParameter("zip", "94040," + country);
            restRequest.AddParameter("appid", "b6907d289e10d714a6e88b30761fae22");
            return restRequest;
        }

        //POST REQUEST WITH PARAMETERS PASSED EXPLICITLY

        public static RestClient GetPostUrl(string resource)
        {
            var url = baseURLPost + resource;
            Console.WriteLine("url : " + url);
            return client = new RestClient(url);
        }

        public static RestRequest PostRequest(string postkey)
        {
            restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("key", postkey);
            restRequest.AddJsonBody(CreatePostRequestBody());
            return restRequest;
        }


        private static PostRequestBody CreatePostRequestBody()
        {
            return new PostRequestBody()
            {
                //below line is similar to location.lat = -38.383494, location.lng = 33.427362
                location = new Location() { lat = -38.383494, lng = 33.427362 },
                accuracy = 50,
                name = "Frontline house",
                phone_number = "(+91) 983 893 3937",
                address = "29, side layout, cohen 09",
                types = new string[] { "shoe park", "shop" },
                website = new Uri("http://google.com"),
                language = "French-IN"
            };
        }

        public class Location
        {
            public double lat;
            public double lng;
        }

        private class PostRequestBody
        {
            /*
           {
                "location":{
                  "lat" : -38.383494,
                  "lng" : 33.427362
              },
              "accuracy":50,
              "name":"Frontline house",
              "phone_number":"(+91) 983 893 3937",
              "address" : "29, side layout, cohen 09",
              "types": ["shoe park","shop"],
              "website" : "http://google.com",
              "language" : "French-IN"
             }

          */

            public Location location;
            public int accuracy;
            public string name;
            public string phone_number;
            public string address;
            public string[] types;
            public Uri website;
            public string language;

            public PostRequestBody()
            {
                this.location = new Location();
                this.types = new string[] { };
                this.website = new Uri("http://www.google.com");
            }
        }


        //DELETE REQUEST WITH PARAMS
        public static RestRequest DeleteRequest(string deletekey)
        {
            restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("key", deletekey);
            restRequest.AddJsonBody(CreateDeleteRequestBody());
            return restRequest;
        }

        private class DeleteRequestBody
        {
            public string place_id;
        }

        private static DeleteRequestBody CreateDeleteRequestBody()
        {
            return new DeleteRequestBody()
            {
                place_id = "c7ef02976eef1b852c3e76dee6d46413"
            };
        }

    }
}
