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
            var shortUrl = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                shortUrl.Append(chars[random.Next(chars.Length)]);
            }

            return shortUrl.ToString();
        }
    }
}
