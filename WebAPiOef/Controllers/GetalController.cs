using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using IO = System.IO;

namespace WebAPiOef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetalController : ControllerBase
    {
        string textlocation = @"getal.txt";
            
        public GetalController()
        {
            
            
        }

        [HttpGet]
        public ActionResult<int> GetGetal()
        {
            if (IO.File.Exists(textlocation))
            {
                var line = IO.File.ReadAllText(textlocation);
                return Ok(line);
            }
            return NotFound();
        }
        
        [HttpPost("Number")]
        public void AddNumberToTxt(int number)
        {
            List<string> outputstring = new List<string>();
            string textnumber = Convert.ToString(number);
            outputstring.Add(textnumber);
            IO.File.WriteAllLines(textlocation, outputstring);
        }
        [HttpPost("RandomNumber")]
        public void AddRandomToTxt()
        {
            List<string> outputstring = new List<string>();
            Random randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(100,200);
            string randomNumberTxt = Convert.ToString(randomNumber);
            outputstring.Add(randomNumberTxt);
            IO.File.WriteAllLines(textlocation, outputstring);
        }



    }
}

