using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Net.Http.Headers;
namespace RapidApiConsume.Controllers
{
    public class SearchLocationController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?children_number=2&locale=en-gb&children_ages=5%2C0&filter_by_currency=EUR&checkin_date=2024-06-20&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&dest_type=city&dest_id=-553173&adults_number=2&checkout_date=2024-06-25&order_by=popularity&include_adjacency=true&room_number=1&page_number=0&units=metric"),
                    Headers =
    {
        { "x-rapidapi-key", "key" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BookingLocationSearchViewModel>(body);
                    return View(data.results.ToList());
                }
            }
            else
            {
             
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
    {
        { "x-rapidapi-key", "key" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
              
                    var data = JsonConvert.DeserializeObject<List<BookingLocationByIdViewModel>>(body);
                    var datavalue = data.Take(1).Select(t => t.dest_id).FirstOrDefault();
                    var client2 = new HttpClient();
                    var request2 = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?children_number=2&locale=en-gb&children_ages=5%2C0&filter_by_currency=EUR&checkin_date=2024-06-20&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&dest_type=city&dest_id={datavalue}&adults_number=2&checkout_date=2024-06-25&order_by=popularity&include_adjacency=true&room_number=1&page_number=0&units=metric"),
                        Headers =
    {
        { "x-rapidapi-key", "key" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                    };
                    using (var response2 = await client.SendAsync(request2))
                    {
                        response2.EnsureSuccessStatusCode();
                        var body2 = await response2.Content.ReadAsStringAsync();
                        var data2 = JsonConvert.DeserializeObject<BookingLocationSearchViewModel>(body2);
                        return View(data2.results.ToList());
                    }
                }
            }
           
        }
        
    }


}
