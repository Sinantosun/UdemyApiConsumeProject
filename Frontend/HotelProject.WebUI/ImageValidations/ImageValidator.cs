

namespace HotelProject.HotelProject.WebUI.ImageValidations
{
    public static class ImageValidator
    {
        public static bool CheckImageExtention(string ex)
        {
            if (ex == ".jpg" || ex == ".jpeg" || ex == ".png")
            {
                return true;
            }
            return false;
        }
    }
}
