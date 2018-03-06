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
        public IActionResult Index(string userName)// welcome display user
        {
            //get the user drom DB
            User u=getUserFromDB(userName).Result;
            Console.WriteLine("in index user controller:"+u._id);
            
            ViewData["1"]=u._id;
           
            return View();
        }

        public IActionResult UserLogin(string userName, string password){
          var res=PostLogin(userName, password).Result;
           if (res==false){
               return RedirectToAction("Error");
           }else{
               return RedirectToAction("Index","User",new {userName=userName});
           }
            
        }

        public IActionResult addUser(User user){
             Console.WriteLine("in add user");

            var res=CreateUser(user);
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
        
        //==========================================================
        //=========User CRUD======================================== 
        //==========================================================


public async Task<Boolean> ValidateSession(string tokenId) {
            var hc = Helpers.CouchDBConnect.GetClient("users");
            var response = await hc.GetAsync("/users/"+tokenId);
            if (!response.IsSuccessStatusCode)
                return false;
            
            var token = (Token) JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(),typeof(Token));

            //if (token.create + token.ttl > now)

            if (token.create.AddSeconds(token.ttl).CompareTo(DateTime.Now) > 0) {
                return true;
            }

            return false;
        }

        // POST api/values
        [HttpPost]
        public async Task<Boolean> PostLogin(string userName, string password)
        {
            
            var hc = Helpers.CouchDBConnect.GetClient("users");
            var response = await hc.GetAsync("users/"+userName);
            if (response.IsSuccessStatusCode) {
                User user = (User) JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(),typeof(User));
                if (user.password.Equals(password)) {
                    Console.WriteLine("in postlogin pass is:"+user.password);
                    return true;
                }
            };

            return false;

        }
         public async Task<User> getUserFromDB(string userName){
              var hc = Helpers.CouchDBConnect.GetClient("users");
            var response = await hc.GetAsync("users/"+userName);
            if (response.IsSuccessStatusCode) {
                User user = (User) JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(),typeof(User));
                return user;
            }
            return null;
         }



        async  Task<Boolean> DoesUserExist(User u) {
            var hc = Helpers.CouchDBConnect.GetClient("users");
            var response = await hc.GetAsync("users/"+u._id);
            if (response.IsSuccessStatusCode) {
                return true;
            }

            return false;
        }

        [HttpPost]
       // [Route("CreateUser")]
        public async Task<int> CreateUser( User u) {
            var doesExist = await DoesUserExist(u);
            if (doesExist) {
                return -1;
            }

            var hc = Helpers.CouchDBConnect.GetClient("users");
            string json = JsonConvert.SerializeObject(u);
            HttpContent htc = new StringContent(json,System.Text.Encoding.UTF8,"application/json");
            var response = await hc.PostAsync("",htc);
            Console.WriteLine("***************************************************************");
            Console.WriteLine(u._id);
            Console.WriteLine("***************************************************************");

            return 1;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [Route("DeleteUser")]
      //  [HttpDelete("{id}")]
        public async Task<Boolean> Delete(int id)
        {
            id=1;
            String st="{1}?rev=1-cf021703c6535c07f3fd9a6c0b8ac1b1";
            Console.WriteLine("im in delete");
            /*var doesExist = await DoesUserExist(u);
                if (!doesExist) {
                    Console.WriteLine("user doesn't exist");  
                    return false;              
                }*/
                var hc = Helpers.CouchDBConnect.GetClient("users");
            //    string json = JsonConvert.SerializeObject(u);
                var response= await hc.DeleteAsync(hc.BaseAddress+"/"+st);
                Console.WriteLine(response);
                Console.WriteLine(hc.BaseAddress+"/"+st);
            return true;
        }










    }
}