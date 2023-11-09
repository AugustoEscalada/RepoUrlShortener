using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ProyectoAcortadorURL.Data;
using ProyectoAcortadorURL.Data.Models;
using ProyectoAcortadorURL.Entities;
using ProyectoAcortadorURL.Helpers;
using System.Xml;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace ProyectoAcortadorURL.Controllers
{
    [ApiController]
    [Route(template: "api/UrlShort")]
    [Authorize]
    public class URLShortController : Controller
    {

        private readonly UrlShortenerContext _Urlcontext;
        public URLShortController(UrlShortenerContext context)
        {
            _Urlcontext = context;
        }

        [HttpPost("Post")]
        public IActionResult GetUrlShortened(string longUrl, UrlCategoriesEnum cat)
        {
            var helperUrl = new HelperUrl();

            String shortUrl = helperUrl.GenerateShortUrl();

            ShortenedURL shortened = new ShortenedURL
            {
                LongURL = longUrl,
                ShortURL = shortUrl,
                category = cat
            };

            _Urlcontext.ShortenedUrls.Add(shortened);
            _Urlcontext.SaveChanges();

            return Ok(shortened.ShortURL) ;
        }

        [HttpGet("get")]

        public IActionResult GetUrl(string url)
        {
            var urlToGet = _Urlcontext.ShortenedUrls.FirstOrDefault(x => x.ShortURL == url);

            if (urlToGet == null)
            {
                return NotFound("La URL no existe");
            }

            int cat = (int)urlToGet.category;
            
            string category;

            if((cat) == 0)
            {
                category = "entretenimiento";
            }
            else if(cat == 1)
            {
                category = "trabajo";
            }
            else
            {
                category = "compras";
            }


            urlToGet.views += 1;
            _Urlcontext.SaveChanges();
            return Ok($" url: {urlToGet.LongURL}, category: {category}");
            //return Redirect(urlToGet.LongURL);
         
        }

    }
}
