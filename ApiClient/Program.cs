using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using ConsoleTables;

namespace ApiClient
{
  // "id": "2baf70d1-42bb-4437-b551-e5fed5a87abe",
  // "title": "Castle in the Sky",
  // "original_title": "天空の城ラピュタ",
  // "original_title_romanised": "Tenkū no shiro Rapyuta",
  // "description": "The orphan Sheeta inherited a mysterious crystal that links her to the mythical sky-kingdom of Laputa. With the help of resourceful Pazu and a rollicking band of sky pirates, she makes her way to the ruins of the once-great civilization. Sheeta and Pazu must outwit the evil Muska, who plans to use Laputa's science to make himself ruler of the world.",
  // "director": "Hayao Miyazaki",
  // "producer": "Isao Takahata",
  // "release_date": "1986",
  // "running_time": "124",
  // "rt_score": "95",
  // "people": [],
  // "species": [],
  // "locations": [],
  // "vehicles": [],
  // "url": "https://ghibliapi.herokuapp.com/films/2baf70d1-42bb-4437-b551-e5fed5a87abe"
  class Film 
  {
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]        
    public string Title {get; set; }
    
    [JsonPropertyName("original_title")]
    public string OriginalTitle { get; set; }

    [JsonPropertyName ("original_title_romanised")]
    public string OriginalTitleRomanised { get; set; }

    [JsonPropertyName ("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("director")]
    public string Director { get; set; }
    
    [JsonPropertyName("producer")]
    public string Producer { get; set; }
    
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }
    
    [JsonPropertyName("running_time")]
    public string RunningTime { get; set; }
    
    [JsonPropertyName("rt_score")]
    public string RottenTomatoScore { get; set; }

    public string TomatoScore {
      get {
        return int.Parse(RottenTomatoScore) > 50 ? "🍅" : "🦠";
      }
    }
  }

  class Program
  {
    static async Task ShowAllFilms()
    {
      var client = new HttpClient();
      var responseAsStream = await client.GetStreamAsync("https://ghibliapi.herokuapp.com/films");
      var films = await JsonSerializer.DeserializeAsync<List<Film>>(responseAsStream);
      var table = new ConsoleTable("#", "Title", "Year", "🍅");
      var index = 0;
      films.ForEach(film =>
      {
        table.AddRow(++index, film.Title, film.ReleaseDate, film.TomatoScore);
      });

      table.Write();

      Console.Write("Which Film would you like to know more about? ");
      var answer = int.Parse(Console.ReadLine());

      //  ShowFilmDetails( ... );
      //                    ^--- Pass ain the movie that the user picked, i.e. at position (answer-1) 

      ShowFilmDetails(films[answer - 1]);
      // Make menu work good.
    }

    static void ShowFilmDetails(Film film)
    {
      Console.Clear();
      Console.WriteLine(film.Title);
      Console.WriteLine(film.OriginalTitle);
      Console.WriteLine();
      Console.WriteLine(film.Description);

      Console.WriteLine();
      Console.WriteLine("Press ENTER to continue");
      Console.ReadLine();

      // This movie is about...
      //
      // Director:   Miyazaki
      // Producer:   sdf;lksdjfsd
      // Year:       1965
      // Characters: Totoro
      //             Satsuki
      //             Mei
      //             Catbus
    }

    static string Colorize(string input)
    {
      var color = "\u001b[32m";
      var reset = "\u001b[0m";

      var output = $"{color}{input}{reset}";
      return output;
    }

    static async Task Main(string[] args)
    {
      var keepGoing = true;
      while (keepGoing)
      {
          Console.Clear();
          Console.Write($"Get {Colorize("A")}ll films, or {Colorize("Q")}uit: ");
          var choice = Console.ReadLine().ToUpper();
          switch (choice)
          {
              case "Q":
                  keepGoing = false;
                  break;
              case "A":
                  await ShowAllFilms();
                  Console.WriteLine("Press ENTER to continue");
                  Console.ReadLine();
                  break;
              default:
                  break;
          }
      }
    }
  }
}
