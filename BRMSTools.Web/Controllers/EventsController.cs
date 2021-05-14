using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebAppMVC.Data;

namespace SimpleWebAppMVC.Controllers
{
    /**
     * Borrower Controller
     */
    public class EventsController : Controller
    {
        private readonly AppDbContext dbContext;

        /**
         * BorrowerController constructor.
         * @param dbCtx Application database context
         */
        public EventsController(AppDbContext dbCtx)
        {
            this.dbContext = dbCtx;
        }

        /**
         * GET: [ /Events/, /Events/Index ]
         * @param sort Sort column and order
         */
        [HttpGet]
        public async Task<IActionResult> Index(string sort)
        {
            ViewBag.SourceSortParm = (sort == "Source" ? "Source_desc" : "Source");
            ViewBag.EventSortParm = (sort == "Event" ? "Event_desc" : "Event");
            ViewBag.DateSortParm = (sort == "Date" ? "Date_desc" : "Date");

            ViewData["sortJSON"] = sort;

            return View(await this.GetSorted(sort).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var taskModel = await this.dbContext.Events.SingleOrDefaultAsync(task => task.Id == id);

            if (taskModel == null)
                return NotFound();

            return View(taskModel);
        }

        /**
        * POST: /Events/Delete/<id>
        * @param id Task Id
        */
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var taskModel = await this.dbContext.Events.SingleOrDefaultAsync(task => task.Id == id);

            this.dbContext.Events.Remove(taskModel);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        /**
         * GET: /Events/GetJSON/<sort>
         * @param sort Sort column and order
         */
        [HttpGet]
        public async Task<IActionResult> GetJSON(string sort)
        {
            return Json(await this.GetSorted(sort).ToListAsync());
        }

        /**
         * Returns a list of Events sorted by the specified sort column and order.
         * @param sort Sort column and order
         */
        private IQueryable<Models.Events> GetSorted(string sort)
        {
            IQueryable<Models.Events> events = from task in this.dbContext.Events select task;

            events = sort switch
            {
                "Source"        => events.OrderBy(s => s.Source),
                "Source_desc"   => events.OrderByDescending(s => s.Source),
                "Event"         => events.OrderBy(s => s.Event),
                "Event_desc"    => events.OrderByDescending(s => s.Event),
                "Date"          => events.OrderBy(s => s.Date),
                "Date_desc"     => events.OrderByDescending(s => s.Date),
                _ => events.OrderBy(s => s.Source),
            };

            return events;
        }
    }
}
