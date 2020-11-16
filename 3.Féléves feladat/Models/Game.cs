
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Game
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }

    }
}
