using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace HotelProject.WebUI.ViewComponents.Mailbox
{
    public class _MailboxSideboxComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MailboxSideboxComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessageForContactCount = await client.GetAsync("http://localhost:5269/api/Contact/GetContactCount");
            if (responseMessageForContactCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageForContactCount.Content.ReadAsStringAsync();
                ViewBag.ContactCount = jsonData;
            }

            var responseMessageForSendCount = await client.GetAsync("http://localhost:5269/api/SendMessage/GetSendMessageCount");
            if (responseMessageForSendCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageForSendCount.Content.ReadAsStringAsync();
                ViewBag.SendCount = jsonData;
            }
            return View();
        }
    }
}
