using System;
using System.Collections;
using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int  Age { get; set; }

        public virtual ICollection<Game> GameLibrary { get; set; }


    }
}
