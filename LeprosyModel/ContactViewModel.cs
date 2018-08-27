using System;
namespace AspNetCoreProject.LeprosyModel
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
        }

        public string Name { get; set; }  
        public string SecurityNumber { get; set; }  
        public string City { get; set; }  
        public string State { get; set; } 

    }
}
