using Microsoft.AspNetCore.Mvc;
using RantBuddyBusinessDataLogic;

namespace RantBuddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RantEntryController : ControllerBase
    {
        private static RantBuddyService.RantBuddyService _service = new();


        [HttpGet]
        public IActionResult GetEntries()
        {
            var entries = _service.GetEntries();
            return Ok(entries);
        }

        [HttpPost]
        public IActionResult AddEntry([FromBody] string entry)
        {
            _service.AddEntry(entry);
            return Ok("Entry added.");
        }

        [HttpPatch("{index}")]
        public IActionResult UpdateEntry(int index, [FromBody] string newEntry)
        {
            var result = _service.UpdateEntry(index, newEntry);
            return result ? Ok("Entry updated.") : NotFound("Invalid index.");
        }

        [HttpDelete("{index}")]
        public IActionResult DeleteEntry(int index)
        {
            var result = _service.DeleteEntry(index);
            return result ? Ok("Entry deleted.") : NotFound("Invalid index.");
        }
    }
}
