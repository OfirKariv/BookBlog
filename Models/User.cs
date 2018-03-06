using System;

namespace songProject.Models
{
    public class User
    {
        public string _id {get; set;}
        public string password {get; set;}
        public string name{get; set;}
        public string age{get; set;}
        public string type{get; set;}//admin or normal/// ahtor or reader or store// only author can add books and writer can write a comment 
    }   
//cuntine here
//make VIEW
    public class Token {
        public string _id {get; set;}
        public int ttl {get ;set;}
        
        public DateTime create {get; set;}

        public Token(){}
    }
}