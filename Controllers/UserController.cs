using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using songProject.Models;
using Newtonsoft.Json;
using System.Net.Http;


namespace songProject.Controllers
{
   //[Route("api/[controller]")]

    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

/* 
        public IActionResult addBook(Book book)
        {
            Console.WriteLine("in add Book");
            book._id=book.title;
            Console.WriteLine(book._id);
            //ViewData["Message"] = "Your application description page.";
            //add to DB
           var res=  addBookToDB(book);
            
            ///redairect to index
            return View(book);
        }

        public IActionResult bookData(string name){
            //viebag

            Book book= getBookFromDB(name).Result;
            //if (book._id!=null){
                ViewData["Book"]=book._id;
              //  return View(book);
          //  }
            //else
              //  ViewData["Book"]="this book has not found";

            return View();
        }
*/
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        //===========================================================
        //=========User CRUD======================================== 
        //===========================================================












    }
}