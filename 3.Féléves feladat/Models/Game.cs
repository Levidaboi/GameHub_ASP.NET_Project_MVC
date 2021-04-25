
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Achievement> Achievements { get; set; }



        public override bool Equals(object obj)
        {
            if (obj is Game)
            {
                Game u = obj as Game;
                return this.UserId == u.UserId && this.Name == u.Name &&
                    this.Genre == u.Genre && this.Achievements == u.Achievements
                    && this.GameTime == u.GameTime && this.GameId == u.GameId &&
                    this.Rating == u.Rating;

            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return 0;
        }


    }

    
}
