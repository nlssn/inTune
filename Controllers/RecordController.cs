using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using inTune.Data;
using inTune.Models;
using inTune.ViewModels;

namespace inTune.Controllers
{
    public class RecordController : Controller
    {
        private readonly inTuneContext _context;

        public RecordController(inTuneContext context)
        {
            _context = context;
        }

        // GET: Record
        [Route("Records")]
        public async Task<IActionResult> Index(string searchString)
        {
            var records = from r in _context.Records select r;

            if (!String.IsNullOrEmpty(searchString)){
                records = records.Where(s => s.Title.Contains(searchString));
            }

            return View(await records.Include(r => r.Artist).ToListAsync());
        }

        // GET: Record/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Records.Include(r => r.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // GET: Record/Create
        public IActionResult Create()
        {
            List<Artist> artists = _context.Artists.ToList();
            AddRecordViewModel addRecordViewModel = new AddRecordViewModel(artists);

            return View(addRecordViewModel);
        }

        // POST: Record/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("RecordId,Artist,Title,Year,NumOfTracks")] Record record
        public async Task<IActionResult> Create(AddRecordViewModel addRecordViewModel)
        {
            if (ModelState.IsValid)
            {
                Artist theArtist = _context.Artists.Find(addRecordViewModel.ArtistId);

                Record newRecord = new Record
                {
                    Title = addRecordViewModel.Title,
                    Year = addRecordViewModel.Year,
                    NumOfTracks = addRecordViewModel.NumOfTracks,
                    Artist = theArtist
                };

                _context.Records.Add(newRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addRecordViewModel);
        }

        // GET: Record/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        // POST: Record/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordId,Artist,Title,Year,NumOfTracks")] Record record)
        {
            if (id != record.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(record);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordExists(record.Id))
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
            return View(record);
        }

        // GET: Record/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Records
                .FirstOrDefaultAsync(m => m.Id == id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // POST: Record/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var record = await _context.Records.FindAsync(id);
            _context.Records.Remove(record);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _context.Records.Any(e => e.Id == id);
        }
    }
}
