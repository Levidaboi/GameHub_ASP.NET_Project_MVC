using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string UserId { get; set; }
        public string Name { get; set; }
        public int  Age { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Game> GameLibrary { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                User u = obj as User;
                return this.UserId == u.UserId && this.Name == u.Name &&
                    this.Age == u.Age && this.GameLibrary == u.GameLibrary ;
                
            }
            else
            {
                return false;
            }
            
            
        }

        public override int GetHashCode()
        {
            return  0;
        }

    }
}
