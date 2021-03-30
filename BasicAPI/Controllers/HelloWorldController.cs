using System;
using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public string SayHello(string who)
        {
            if (who == null)
            {
              who = "World";
            }

            return $"Hello, {who}. It is currently {DateTime.Now}";
        }
    }
}