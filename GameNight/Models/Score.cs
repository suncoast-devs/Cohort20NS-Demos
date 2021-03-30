using System;
using System.Text.Json.Serialization;

public class Score
{
    public int Id { get; set; }

    [JsonIgnore] 
    public int GameId { get; set; }

    [JsonIgnore] 
    public Game Game { get; set; }   // <- GameId that points to Id in the Games table.
    public string Player { get; set; }
    public int Points { get; set; }
}
