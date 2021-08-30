using Assignment.ServiceLayer;
using Assignment.ServiceLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Api.Controllers
{
    /// <summary>
    /// Profanity check controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CheckProfanityController : ControllerBase
    {
        /// <summary>
        /// Checks for a text if contains a determined set of banned words.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Response> Checkfile(IFormFile file)
        {
            var profanityCheck = new ProfanityCheck();
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }
            var response = profanityCheck.CheckForProfanity(result.ToString());
            return response;
        }
    }
}
