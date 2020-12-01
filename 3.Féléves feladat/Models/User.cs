using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string Name { get; set; }
        public int  Age { get; set; }


        
        public virtual ICollection<Game> GameLibrary { get; set; }


    }
}
