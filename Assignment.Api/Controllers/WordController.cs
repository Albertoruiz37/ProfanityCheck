using Assignment.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Api.Controllers
{
    /// <summary>
    /// Handles all Word entity related transactions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        /// <summary>
        /// Adds a word.
        /// </summary>
        /// <param name="word">Word to be added</param>
        /// <returns>OK if everything worked fine.</returns>
        [HttpPost]
        public ActionResult AddWord(Word word)
        {
            var repository = new Repository();
            var result = repository.AddWord(word);
            if (result == -1) { return BadRequest(); }
            return Ok();
        }

        /// <summary>
        /// Updates a word.
        /// </summary>
        /// <param name="id">Id to update</param>
        /// <param name="value">new value for the word</param>
        /// <returns>OK if everything worked fine.</returns>
        [HttpPut("{id}")]
        public ActionResult UpdateWord(int id, string value)
        {
            var repository = new Repository();
            var word = new Word { Id = id, Value = value };
            var result = repository.UpdateWord(word);
            if (result == -1) { return BadRequest(); }
            return Ok();
        }

        /// <summary>
        /// Deletes a word.
        /// </summary>
        /// <param name="id">Id to delete</param>
        /// <returns>OK if everything worked fine.</returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteWords(int id)
        {
            var repository = new Repository();
            var word = new Word { Id = id};
            var result = repository.DeleteWord(word);
            if (result == -1) { return BadRequest(); }
            return Ok();
        }

        /// <summary>
        /// Gets a word by id.
        /// </summary>
        /// <param name="id">Id to be retrieved</param>
        /// <returns>Returns a word object</returns>
        [HttpGet]
        public ActionResult<Word> GetWordbyId(int id)
        {
            var repository = new Repository();
            var result = repository.GetWordbyId(id);
            return result;
        }
    }
}
