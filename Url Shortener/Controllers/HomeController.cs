using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Url_Shortener.Models;
using Url_Shortener.Extensions;

namespace Url_Shortener.Controllers {
    public class HomeController : Controller {
        private UrlDbContext db = new UrlDbContext();

        public ActionResult Index() {
            return View();
        }
        // GET: Home
        public ActionResult AddUrl(string URL) {

            var shortURL = Helper.RandomString(5); //Generate random 5 char string 

            //add properties to database.
            db.Urls.Add(new Url {
                ShortURL = shortURL,
                LongURL = URL,
                Created = DateTime.Now,
            });

            db.SaveChanges();

            return View("Index");
        }

        public ActionResult RedirectFromUrl(string shortURL) {

            //Gets everything after the last "/" in the URL, which would be our ShortURL.
            var shortString = shortURL.Split('/').Last();
            //Find the LongURL in the Database from our shortString, using LINQ.
            var longUrl = db.Urls.Where(x => x.ShortURL == shortString).FirstOrDefault();
            //Gets the LongURL from the Db entry. Converts to string.
            var urlToRedirectTo = Helper.FormatUrl(longUrl.LongURL, true).ToString();

            return Redirect(urlToRedirectTo);


            //throw new HttpException(404, "Item Not Found");
        }
    }
}