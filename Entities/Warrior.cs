


using System.ComponentModel.DataAnnotations;

namespace Foreveryone.Entities{
    public class Warrior {
        public int Id { get; set; }
        public string _class {get; set;}
       
        public int PlayerId {get; set;}
        public Player? Player {get; set;} 
    }
}