using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ProyectoAcortadorURL.Data;
using ProyectoAcortadorURL.Entities;
using ProyectoAcortadorURL.Helpers;
using System.Xml;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace ProyectoAcortadorURL.Controllers
{
    [ApiController]
    [Route(template: "api/UrlShort")]
    public class URLShortController : Controller
    {

        private readonly UrlShortenerContext _Urlcontext;
        public URLShortController(UrlShortenerContext context)
        {
            _Urlcontext = context;
        }

        [HttpPost("Post")]
        public IActionResult GetUrlShortened(string longUrl)
        {
            var helperUrl = new HelperUrl();

            String shortUrl = helperUrl.GenerateShortUrl();

            ShortenedURL shortened = new ShortenedURL
            {
                LongURL = longUrl,
                ShortURL = shortUrl
            };

            _Urlcontext.ShortenedURLs.Add(shortened);
            _Urlcontext.SaveChanges();

            return Ok(shortened.ShortURL) ;
        }

        [HttpGet("get")]

        public IActionResult GetUrl(string ClientUrl)
        {
            var urlToGet = _Urlcontext.ShortenedURLs.FirstOrDefault(x => x.ShortURL == ClientUrl);

            if (urlToGet == null)
            {
                return NotFound("La URL no existe");
            }
            urlToGet.views += 1;
            _Urlcontext.SaveChanges();
            return Ok(urlToGet.LongURL);
         
        }


        //[HttpGet("Get")]
        //public IActionResult GetUrl(string shortenedurl)
        //{
        //    var urlToGet = _Urlcontext.ShortenedURLs.FirstOrDefault(x => x.ShortURL == shortenedurl);

        //    if (urlToGet == null)
        //    {
        //        return NotFound("The Url cannot be found");
        //    }
        //    urlToGet.views += 1;
        //    _Urlcontext.SaveChanges();
        //    return Ok(urlToGet.LongURL);

        //}
    }
}
