using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: movies/random
        public ActionResult Random()
        {
            var Movie = new Movie() { Name = "Tatimu petitona" };
            return View(Movie);
        }

        //      movies/edit/(value for param id)
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //      movies
        //      movies?pageIndex=2      -->     we can also specify ourselves param values  
        //      movies?pageIndex=3&sortBy=ReleaseDate
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Default";
            return Content(String.Format("pageIndex={0} & sortBy={1}", pageIndex, sortBy));   
        }

        //      movies/released/(year value with 4 digits)/(month value with 2 digits and 1 to 12 range)
        //by using routes.MapMvcAttributeRoutes() in RouteConfig file, we can add the route like below:
        [Route("movies/released/{year:regex(\\d{4}):range(1500, 2100)}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}