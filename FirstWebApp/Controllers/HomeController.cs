using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstWebApp.Models;
using Common.Models;
using Business;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            //TblCategory subc = new TblCategory()
            //{
            //    Description = "Category 3",
            //    Name = "Cat 3"
            //};
            //CategoryBl.Add(subc);
            //var item = CategoryBl.SingleOrDefault(x => x.Id == 1);
            //item.Name = "updated";
            //var listitems = CategoryBl.Where(x => !string.IsNullOrEmpty(x.Name));
            //CategoryBl.Update(item, x => x.Id == item.Id);
            //CategoryBl.Delete(x => x.Id == 2);
            return View();

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            var cat = CategoryBl.SingleOrDefault(x => x.Id == 1);
            var catwithSUb = CategoryBl.SingleOrDefault(x => x.Id == 1, x => x.TblSubCategory);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
