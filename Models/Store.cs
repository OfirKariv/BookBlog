using System;
using System.Collections.Generic;

namespace songProject.Models
{
    public class Store{
        public string _id{get;set;}//store name
        public List<Book> allBooks {get;set;}
        public List<User> payingUsers{get;set;} 
        public long revenew{get;set;}


        public void addToList(User u)
        {
            if(payingUsers == null)
            {
                payingUsers = new List<User>();
            }
            payingUsers.Add(u);
        }
    }

    //functions nedded
    //
    

}