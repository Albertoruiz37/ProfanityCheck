using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.ServiceLayer.Models
{
    /// <summary>
    /// Contains the result of the api response.
    /// </summary>
    public class Response
    {
        public bool Result { get; set; }
        public List<Word> Matches { get; set; }
    }
}
