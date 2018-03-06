using System;

namespace songProject.Models
{
    public class User
    {
        public string _id {get; set;} //username
        public string password {get; set;}
        public string firstname{get; set;}
        public string lastname{get; set;}
        public string age{get; set;}
        public string type{get; set;}//admin or normal/// ahtor or reader or store// only author can add books and writer can write a comment 
        //add list of favorite books
    }   


    public class Token {
        public string _id {get; set;}
        public int ttl {get ;set;}
        
        public DateTime create {get; set;}

        public Token(){}
    }
}