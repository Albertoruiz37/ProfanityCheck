using Assignment.ServiceLayer.DataStore;
using Assignment.ServiceLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Assignment.ServiceLayer
{
    /// <summary>
    /// Profanity check main class.
    /// </summary>
    public class ProfanityCheck
    {
        /// <summary>
        /// Checks for the presence of a banned word from the black list in a determined text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Response CheckForProfanity(string text)
        {
            var response = new Response();
            response.Matches = new List<Word>();
            var data = new Repository();
            var patterns = data.GetAllWords();
            foreach (var pattern in patterns)
            {
                RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace;
                Regex reg = new Regex(@"\b(" + pattern.Value + @")\b", options);
                if (reg.IsMatch(text))
                {
                    response.Matches.Add(pattern);
                }
            }
            response.Result = response.Matches.Count > 0;
            return response;
        }
    }
}
