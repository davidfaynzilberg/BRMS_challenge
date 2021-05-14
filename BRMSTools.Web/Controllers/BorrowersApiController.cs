using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebAppMVC.Data;

namespace SimpleWebAppMVC.Controllers
{
    [Produces("application/json")]
    [Route("api/Borrowers")]
    public class BorrowersApiController : Controller
    {
        private readonly AppDbContext dbContext;

        /**
         * BorrowersApiController constructor.
         * @param dbCtx Application database context
         */
        public BorrowersApiController(AppDbContext dbCtx)
        {
            this.dbContext = dbCtx;
        }

        // GET api/Borrowers
        [HttpGet]
        public JsonResult Get()
        {
            return Json(from task in this.dbContext.Borrowers select task);
        }

        // GET api/Borrowers/<id>
        [HttpGet("{id}", Name = "GetTask")]
        public IActionResult Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var task = this.dbContext.Borrowers.SingleOrDefault(t => t.Id == id);

            if (task == null)
                return NotFound();

            return Json(task);
        }

        // POST api/Borrowers
        [HttpPost]
        public IActionResult Post([FromBody] Models.Borrower taskModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            this.dbContext.Add(taskModel);
            this.dbContext.SaveChanges();

            return CreatedAtRoute("GetTask", new { id = taskModel.Id }, taskModel);
        }

        // PUT api/Borrowers/<id>
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Models.Borrower taskModel)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var task = this.dbContext.Borrowers.SingleOrDefault(t => t.Id == id);

            if (task == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            task.Update(taskModel);
            this.dbContext.Update(task);
            this.dbContext.SaveChanges();

            return Ok();
        }

        // DELETE api/Borrowers/<id>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var task = this.dbContext.Borrowers.SingleOrDefault(t => t.Id == id);

            if (task == null)
                return NotFound();

            this.dbContext.Borrowers.Remove(task);
            this.dbContext.SaveChanges();

            return Ok();
        }
    }
}
