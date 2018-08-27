using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProject.LeprosyModel
{
    public class Book
    {
        public Book()
        {
        }
        [Key]
        public string Isbn { get; set; }

        public string Name { get; set; }

        public Author Author { get; set; }

        public Publisher Publisher { get; set; }  

    }
}
