using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Sunken.Server;

namespace Sunken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : Controller
    {
        [HttpGet("servers")]
        public string Get()
        {
            return ServerManager.DumpInfo().Result;
        }

        // GET api/<controller>
        [HttpGet("{command}/{context}")]
        public string Get(string command, string context)
        {
            switch (command)
            { 
                // Get the current state of a game
                case "state":
                    try
                    {
                        return ServerManager.GetServerStatus(context).Result;
                    }
                    catch (Exception exc)
                    {
                        return exc.ToString();
                    }

                default:
                    return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]string value)
        {
            return "oops";
        }

        [HttpPost("{command}/{context}")]
        public string Post(string command, string context, [FromBody]string username = null)
        {
            switch (command)
            {
                // Create a new game with a specified amount of Mortal players and 1 Sunken player
                case "newgame":
                    try
                    {
                        int numMortals = int.Parse(context);
                        if (numMortals <= 0) throw new ArgumentOutOfRangeException();
                        return ServerManager.CreateNewGame(numMortals).Result;
                    }
                    catch (Exception exc)
                    {
                        return exc.ToString();
                    }

                // Register a mortal player for a game
                case "register":
                    try
                    {
                        if (username == null) throw new ArgumentNullException();
                        return ServerManager.RegisterUser(context, username).Result;
                    }
                    catch (Exception exc)
                    {
                        return exc.ToString();
                    }
                default:
                    return null;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}