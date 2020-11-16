using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public enum AchiLevel
    {
        bronze , silver , gold    
    }
    public class Achievement
    {
        public string AchiId { get; set; }
        public string Name { get; set; }
        public AchiLevel achiLevel { get; set; }

    }
}
