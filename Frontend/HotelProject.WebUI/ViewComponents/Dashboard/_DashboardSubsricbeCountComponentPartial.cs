using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubsricbeCountComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/burayakullaniciadigelecek"),
                Headers =
    {
        { "x-rapidapi-key", "rapid api key" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.InstagramFollowers = result.followers;
                ViewBag.InstagramFollowing = result.following;
             
            }

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=burayakullaniciadigelecek"),
                Headers =
    {
        { "x-rapidapi-key", "rapid api key" },
        { "x-rapidapi-host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                //ResultTwitterFollowersDto
                var result = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
                ViewBag.TwitterFollowers = result.data.user_info.friends_count;
                ViewBag.TwitterFollowing = result.data.user_info.followers_count;

            }

            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=burayalinkledinurlgelecek%2F&include_skills=false&include_certifications=false&include_publications=false&include_honors=false&include_volunteers=false&include_projects=false&include_patents=false&include_courses=false&include_organizations=false"),
                Headers =
    {
        { "x-rapidapi-key", "rapid api key" },
        { "x-rapidapi-host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(body3);
                ViewBag.LinkedinFollowers = result.data.follower_count;
                ViewBag.LinkedinFollowing = result.data.connection_count;
            }

            return View();


        }

    }
}
