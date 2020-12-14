using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public enum AchiLevel
    {
        bronze = 10 , silver  = 20 , gold = 30    
    }
    public class Achievement
    {
        [Key]
        public string AchiId { get; set; }
        public string Name { get; set; }
        public AchiLevel achiLevel { get; set; }

        public string  GameId { get; set; }

        [NotMapped]
        public virtual Game Game { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is Achievement)
            {
                Achievement u = obj as Achievement;
                return this.AchiId == u.AchiId && this.Name == u.Name &&
                    this.achiLevel == u.achiLevel && this.GameId == u.GameId
                    && this.Game == u.Game;

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
