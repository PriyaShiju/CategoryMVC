using CategoryMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly Home _home;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           

        }

        //public HomeController(Home home)
        //{
        //    //_logger = logger;
        //    _home = home;

        //}
        public string strText;
        public string strOutputMessage;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChkPalindrome(string strText)
        {
            if (strText != "")
            {
                
                char[] strChar = strText.ToCharArray();
                Array.Reverse(strChar);
                string strReverse = new(strChar);
                if (strText.ToLower() == strReverse.ToLower())
                    strOutputMessage = " is palindrome";  //strWord.Concat(" is palindrome").ToString();
                else
                    strOutputMessage = " is not palindrome"; //strWord.Concat(" is not palindrome").ToString();

            }
            return RedirectToAction("Index");
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
