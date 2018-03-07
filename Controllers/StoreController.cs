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

    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult getBooks(){
            Console.WriteLine("in get books");
             List<Book> list=getAllBookFromDB().Result;
                 
             //foreach (Book b in list){
               //     Console.WriteLine(b._id);
             //}
             
            return View();
        }

        //===========================================================
        //=========Store CRUD======================================== 
        //===========================================================

    //to get all books
     public async  Task<List<Book>> getAllBookFromDB() {
            
            var hc = Helpers.CouchDBConnect.GetClient("store");
            var response = await hc.GetAsync(hc.BaseAddress);
            var jsonobject=await response.Content.ReadAsStringAsync();
            var books= JsonConvert.DeserializeObject<List<Book>>(jsonobject);
         //   Console.WriteLine(jsonobject);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(books);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            return books;
            }


    public async  Task<List<User>> getUsersListFromDB() {
            
            var hc = Helpers.CouchDBConnect.GetClient("store");
            var response = await hc.GetAsync(hc.BaseAddress);
            var jsonobject=await response.Content.ReadAsStringAsync();
            var users= JsonConvert.DeserializeObject<List<User>>(jsonobject);
         //   Console.WriteLine(jsonobject);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(users);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            return users;
            }
    public IActionResult updateUsersList(string username)
    {
        var users =getUsersListFromDB().Result;
        if(users == null)
        //Error
        foreach (User u in users)
        {
         if(u._id.Equals(username))
         return View();       
        }
       // UpdateStore();
        {}

        return View();

    }

        //===========================================================
        //=========Store CRUD======================================== 
        //===========================================================


        /*
        public async Task<Boolean> UpdateStore([FromBody] Store s)
        {
            
            var hc = Helpers.CouchDBConnect.GetClient("store");
            string json = JsonConvert.SerializeObject(s);


            return false;
        }
        */
    }
}
