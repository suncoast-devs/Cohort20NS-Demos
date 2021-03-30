using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BasicApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DiceController : ControllerBase
  {

    [HttpGet("{sides}")]
    public List<int> Roll(int sides, int count = 1)
    {
      var rolls = new List<int>();
      var randomNumberGenerator = new Random();
      
      for (int i = 0; i < count; i++)
      {
          var roll = randomNumberGenerator.Next(sides) + 1;
          rolls.Add(roll);
      }

      return rolls;
    }
  }
}