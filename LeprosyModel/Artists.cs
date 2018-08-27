using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProject.LeprosyModel
{
    public class Artists
    {
      
        [Key]
        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        public int  Age { get; set; }

      

    }
}

