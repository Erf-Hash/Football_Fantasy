using System.ComponentModel.DataAnnotations;

namespace FootBall_Fantasy.Business.Players;

public class Player
{
    [Key]
    public int Id { get; set; }
    public string first_name { get; set; }
    public string second_name { get; set; }
    public string web_name { get; set; }
    public int now_cost { get; set; }
    public int total_points { get; set; }
    public int event_points { get; set; }
    public int team { get; set; }
    public int element_type { get; set; }
    public string photo { get; set; }

}
