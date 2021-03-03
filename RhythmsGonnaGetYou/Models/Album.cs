using System;
using System.Collections.Generic;

namespace RhythmsGonnaGetYou.Models
{
  class Album
  {
    public int Id { get; set; }
    public Band Band { get; set; }
    public string Title { get; set; }
    public bool IsExplicit { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<Song> Songs { get; set; }
  }
}
  