using Microsoft.AspNetCore.Mvc;
using ProyectoAcortadorURL.Data;
using System.Text;

namespace ProyectoAcortadorURL.Helpers
{
    public class HelperUrl
    {

        public string GenerateShortUrl()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            string shortUrl = string.Empty;

            string index = "https://UrlShortener/";

            for (int i = 0; i < 6; i++)
            {
                shortUrl = index + chars[random.Next(chars.Length)];
                index = shortUrl;
                //shortUrl.Append(chars[random.Next(chars.Length)]);
            }

            return shortUrl;
        }
    }
}
