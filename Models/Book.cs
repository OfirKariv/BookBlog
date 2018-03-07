using System;

namespace songProject.Models
{
    public class Book{
        public string _id{get;set;}
        public string title{get;set;}
        public string author{get;set;}
        public string type{get;set;}//comedy,drama, fantasy,....
        public string summary{get;set;}
        public string publishedYear{get;set;}
        public string image {get;set;}
        public string price {get;set;}
        public int soldCount{get;set;}
        public string content{get;set;}// url ///the story!!
    }                                   



}