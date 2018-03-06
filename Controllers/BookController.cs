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

    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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
                ViewData["Book"]=book.summary;
              //  return View(book);
          //  }
            //else
              //  ViewData["Book"]="this book has not found";

            return View();
        }

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
        //=========Books CRUD======================================== 
        //===========================================================

        [HttpPost]
     //   [Route("createBook")]
        public async Task<int> addBookToDB([FromBody] Book b) {
        
            var hc = Helpers.CouchDBConnect.GetClient("books");
            string json = JsonConvert.SerializeObject(b);
            HttpContent htc = new StringContent(json,System.Text.Encoding.UTF8,"application/json");
            var response = await hc.PostAsync("",htc);
            //check if the post sucsess
            Console.WriteLine("***************************************************************");
            Console.WriteLine(b._id);
            Console.WriteLine("***************************************************************");
            Console.WriteLine(response);
            Console.WriteLine("***************************************************************");

            return 1;
        }

        //get

        public async  Task<Book> getBookFromDB(string name) {
            Console.WriteLine("in get book from db: the book name:"+name);
            var hc = Helpers.CouchDBConnect.GetClient("books/"+name);
            var response = await hc.GetAsync(hc.BaseAddress);
           
            var jsonobject=await response.Content.ReadAsStringAsync();
            var book= JsonConvert.DeserializeObject<Book>(jsonobject);
         //   Console.WriteLine(jsonobject);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(book.title);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            return book;
            }

    //Update


    //Delete



    }
}
