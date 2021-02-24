using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using IO = System.IO;
using System.Text;
using System.IO;

namespace WebAPiOef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetallenController : ControllerBase
    {
        string textlocation = @"getal.txt";

        public GetallenController()
        {


        }

        [HttpGet]
        public ActionResult<List<int>> GetGetallen()
        {
            if (IO.File.Exists(textlocation))
            {
                var lines = IO.File.ReadAllText(textlocation);
                return Ok(lines);
            }
            return NotFound();
        }

        [HttpPost("ExtraNumber")]
        public void AddExtraNumberToTxt(int number)
        {
            StreamWriter sw = new StreamWriter(textlocation, true, Encoding.ASCII);
            List<string> outputstring = new List<string>();
            string textnumber = Convert.ToString(number);
            outputstring.Add(textnumber);
            foreach (var item in outputstring)
            {
                sw.WriteLine();
                sw.Write(item);
            }
            sw.Close();
        }
        [HttpPost("DeleteFirstLine")]
        public void DeleteFirstLineFromTxt()
        {

            List<string> lines = IO.File.ReadAllLines(textlocation).ToList();
            string lineToRemove = lines[0];
            lines.Remove(lineToRemove);
            IO.File.WriteAllLines(textlocation, lines);
        }
        [HttpPut("UpdateSpecificLine")]
        public void UpdateSpecificLineFromTxt(int index, int newNumber)
        {
            List<string> lines = IO.File.ReadAllLines(textlocation).ToList();
            lines.RemoveAt(index);
            lines.Insert(index, Convert.ToString(newNumber));
            IO.File.WriteAllLines(textlocation, lines);

        }
        [HttpDelete]
        public ActionResult<int> DeleteSpecificLine(int index)
        {
            List<string> lines = IO.File.ReadAllLines(textlocation).ToList();
            if (lines.Count > index)
            {
                lines.RemoveAt(index);
                return Ok();
            }
            return BadRequest();
        }



    }
}


