using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProject.LeprosyModel
{
    public class Contact
    {
        public Contact()
        {
        }
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; }  
        public string SecurityNumber { get; set; }  
        public string Address { get; set; }  

    }
}
