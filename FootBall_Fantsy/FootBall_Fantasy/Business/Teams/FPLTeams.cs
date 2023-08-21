using System.ComponentModel.DataAnnotations;

namespace FootBall_Fantasy.Business.Teams
{
    public class FPLTeams
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int strength { get; set; }
        public string short_name { get; set; }
    }
}
