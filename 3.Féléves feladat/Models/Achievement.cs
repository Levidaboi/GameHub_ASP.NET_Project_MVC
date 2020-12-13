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

    }
}
