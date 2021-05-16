using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebAppMVC.Data;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hubs;

namespace SimpleWebAppMVC.Controllers
{
    /**
     * Borrower Controller
     */
    public class BorrowersController : Controller
    {
        private readonly AppDbContext dbContext;

        /**
         * BorrowerController constructor.
         * @param dbCtx Application database context
         */
        public BorrowersController(AppDbContext dbCtx, IHubContext<NotificationHub> notificationHubContext)
        {
            this.dbContext = dbCtx;
        }

        /**
         * GET: /Borrower/Create
         */
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Models.Borrower());
        }

        /**
         * POST: /Borrower/Create
         * http://go.microsoft.com/fwlink/?LinkId=317598
         * @param taskModel Task model
         */
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SSN,Date,Status,Crimeid,Score,Dob,Address")] Models.Borrower taskModel)
        {
            if (ModelState.IsValid)
            {
                this.dbContext.Add(taskModel);
                await this.dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(taskModel);
        }

        /**
         * GET: /Borrower/Details/<id>
         * @param id Borrower Id
         */
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var taskModel = await this.dbContext.Borrowers.SingleOrDefaultAsync(task => task.Id == id);

            if (taskModel == null)
                return NotFound();

            return View(taskModel);
        }

        /**
         * GET: /Borrower/Delete/<id>
         * @param id Task Id
         */
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var taskModel = await this.dbContext.Borrowers.SingleOrDefaultAsync(task => task.Id == id);

            if (taskModel == null)
                return NotFound();

            return View(taskModel);
        }

        /**
         * POST: /Borrower/Delete/<id>
         * @param id Task Id
         */
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var taskModel = await this.dbContext.Borrowers.SingleOrDefaultAsync(task => task.Id == id);

            this.dbContext.Borrowers.Remove(taskModel);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        /**
         * GET: /Borrower/Edit/<id>
         * @param id Borrower Id
         */
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var taskModel = await this.dbContext.Borrowers.SingleOrDefaultAsync(task => task.Id == id);

            if (taskModel == null)
                return NotFound();

            return View(taskModel);
        }

        /**
         * POST: /Borrower/Edit/<id>
         * http://go.microsoft.com/fwlink/?LinkId=317598
         * @param id        Task Id
         * @param taskModel Task model
         */
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,SSN,Date,Status,Crimeid,Score,Dob,Address")] Models.Borrower taskModel)
        {
            if (id != taskModel.Id)
                return NotFound();

            if (!this.dbContext.Borrowers.Any(t => t.Id == id))
                return NotFound();

            if (ModelState.IsValid)
            {
                this.dbContext.Update(taskModel);
                await this.dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(taskModel);
        }
        
        /**
         * GET: [ /Borrowers/, /Borrowers/Index ]
         * @param sort Sort column and order
         */
        [HttpGet]
        public async Task<IActionResult> Index(string sort)
        {
            ViewBag.NameSortParm = (sort == "Name" ? "Name_desc" : "Name");
            ViewBag.SSNSortParm = (sort == "SSN" ? "SSN_desc" : "SSN");
            ViewBag.DateSortParm = (sort == "Date" ? "Date_desc" : "Date");
            ViewBag.StatusSortParm = (sort == "Status" ? "Status_desc" : "Status");
            ViewBag.StatusSortParm = (sort == "Dob" ? "Dob_desc" : "Dob");

            ViewData["sortJSON"] = sort;

            return View(await this.GetSorted(sort).ToListAsync());
        }

        /**
         * GET: /Borrowers/GetJSON/<sort>
         * @param sort Sort column and order
         */
        [HttpGet]
        public async Task<IActionResult> GetJSON(string sort)
        {
            return Json(await this.GetSorted(sort).ToListAsync());
        }

        /**
         * Returns a list of Borrowers sorted by the specified sort column and order.
         * @param sort Sort column and order
         */
        private IQueryable<Models.Borrower> GetSorted(string sort)
        {
            IQueryable<Models.Borrower> borrowers = from task in this.dbContext.Borrowers select task;

            borrowers = sort switch
            {
                "Name"          => borrowers.OrderBy(s => s.Name),
                "Name_desc"     => borrowers.OrderByDescending(s => s.Name),
                "SSN"           => borrowers.OrderBy(s => s.SSN),
                "SSN_desc"      => borrowers.OrderByDescending(s => s.SSN),
                "Dob"           => borrowers.OrderBy(s => s.Dob),
                "Dob_desc"      => borrowers.OrderByDescending(s => s.Dob),
                "Address"       => borrowers.OrderBy(s => s.Address),
                "Address_desc"  => borrowers.OrderByDescending(s => s.Address),
                "Status"        => borrowers.OrderBy(s => s.Status),
                "Status_desc"   => borrowers.OrderByDescending(s => s.Status),
                "Date"          => borrowers.OrderBy(s => s.Date),
                "Date_desc"     => borrowers.OrderByDescending(s => s.Date),
                _               => borrowers.OrderBy(s => s.Name),
            };

            return borrowers;
        }
    }
}
