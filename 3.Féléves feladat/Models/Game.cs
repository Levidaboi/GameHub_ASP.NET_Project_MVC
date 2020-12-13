
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Game
    {
        [Key]
        public string GameId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int GameTime { get; set; }

        public string PlayerName { get; set; }


        [Range(0.0,10.0)]
        public int Rating { get; set; }

        public string  UserId { get; set; }

        [NotMapped]
        public virtual User User { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }

    }
}
