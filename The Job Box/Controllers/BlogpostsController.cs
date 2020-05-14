using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Job_Box.Models;

namespace The_Job_Box.Controllers
{
    public class BlogpostsController : Controller
    {
        private readonly IdentityAppContext _context;

        public BlogpostsController(IdentityAppContext context)
        {
            _context = context;
        }

        // GET: Blogposts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blogposts.ToListAsync());
        }

        // GET: Blogposts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogposts = await _context.Blogposts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (blogposts == null)
            {
                return NotFound();
            }

            return View(blogposts);
        }

        // GET: Blogposts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogposts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Content,CreateTime,ImageUrl")] Blogposts blogposts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogposts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogposts);
        }

        // GET: Blogposts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogposts = await _context.Blogposts.FindAsync(id);
            if (blogposts == null)
            {
                return NotFound();
            }
            return View(blogposts);
        }

        // POST: Blogposts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Content,CreateTime,ImageUrl")] Blogposts blogposts)
        {
            if (id != blogposts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogposts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogpostsExists(blogposts.ID))
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
            return View(blogposts);
        }

        // GET: Blogposts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogposts = await _context.Blogposts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (blogposts == null)
            {
                return NotFound();
            }

            return View(blogposts);
        }

        // POST: Blogposts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogposts = await _context.Blogposts.FindAsync(id);
            _context.Blogposts.Remove(blogposts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogpostsExists(int id)
        {
            return _context.Blogposts.Any(e => e.ID == id);
        }
    }
}
