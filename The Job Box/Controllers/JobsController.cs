using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Job_Box.Models;
using The_Job_Box.Models.JobsViewModel;

namespace The_Job_Box.Controllers
{
    public class JobsController : Controller
    {
        private readonly IdentityAppContext _context;
       
        private readonly IHostingEnvironment _hostingEnvironment;

        [BindProperty]
        public JobsViewModel JobsVM { get; set; }

        public JobsController(IdentityAppContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;

            JobsVM = new JobsViewModel()
            {
                Category = _context.Category.ToList(),
                Jobs = new Models.Jobs()
            };
        }



        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var identityAppContext = _context.Jobs.Include(j => j.Category).Include(j => j.Location).Include(j => j.SubCategory);
            return View(await identityAppContext.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobs = await _context.Jobs
                .Include(j => j.Category)
                .Include(j => j.Location)
                .Include(j => j.SubCategory)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jobs == null)
            {
                return NotFound();
            }

            return View(jobs);
        }


    

        // GET: Jobs/Create
        public IActionResult Create()
        {

            return View(JobsVM);
            //ViewData["JobCategoryId"] = new SelectList(_context.Category, "Id", "Name");
            //ViewData["JobLocation"] = new SelectList(_context.Set<JobLocation>(), "Id", "CityName");
            //ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Name");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CompanyName,Telephone,JobName,JobCategoryId,SubCategoryId,JobLocation,Salary,Description,Summary")] Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobCategoryId"] = new SelectList(_context.Category, "Id", "Name", jobs.JobCategoryId);
            ViewData["JobLocation"] = new SelectList(_context.Set<JobLocation>(), "Id", "CityName", jobs.JobLocation);
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Name", jobs.SubCategoryId);
            return View(jobs);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobs = await _context.Jobs.FindAsync(id);
            if (jobs == null)
            {
                return NotFound();
            }
            ViewData["JobCategoryId"] = new SelectList(_context.Category, "Id", "Name", jobs.JobCategoryId);
            ViewData["JobLocation"] = new SelectList(_context.Set<JobLocation>(), "Id", "CityName", jobs.JobLocation);
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Name", jobs.SubCategoryId);
            return View(jobs);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CompanyName,Telephone,JobName,JobCategoryId,SubCategoryId,JobLocation,Salary,Description,Summary")] Jobs jobs)
        {
            if (id != jobs.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobsExists(jobs.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobCategoryId"] = new SelectList(_context.Category, "Id", "Name", jobs.JobCategoryId);
            ViewData["JobLocation"] = new SelectList(_context.Set<JobLocation>(), "Id", "CityName", jobs.JobLocation);
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Name", jobs.SubCategoryId);
            return View(jobs);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobs = await _context.Jobs
                .Include(j => j.Category)
                .Include(j => j.Location)
                .Include(j => j.SubCategory)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jobs == null)
            {
                return NotFound();
            }

            return View(jobs);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobs = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(jobs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobsExists(int id)
        {
            return _context.Jobs.Any(e => e.ID == id);
        }
    }
}
