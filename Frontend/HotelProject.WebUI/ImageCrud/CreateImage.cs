using Microsoft.AspNetCore.Http;

namespace HotelProject.WebUI.ImageCrud
{
    public static class CreateImage
    {
       public static async void Create(IFormFile model,string path)
        {
            var location = Path.Combine(Directory.GetCurrentDirectory(), path);
            var stream = new FileStream(location, FileMode.Create);
            await model.CopyToAsync(stream);
            stream.Dispose();
            stream.Close();
        }
    }
}
