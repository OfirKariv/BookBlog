using System;
using System.Collections.Generic;

namespace songProject.Models
{
    public class Store{
        public string _id{get;set;}//store name
        public List<Book> allBooks {get;set;}
        public HashSet<User> payingUsers{get;set;} 
        public long revenew{get;set;}
    }



}