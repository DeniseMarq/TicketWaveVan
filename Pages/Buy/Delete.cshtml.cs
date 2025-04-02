using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TWVancouver.Data;
using TicketWaveVan.Models;

namespace TicketWaveVan.Pages.Buy
{
    public class DeleteModel : PageModel
    {
        private readonly TWVancouver.Data.TicketWaveContext _context;

        public DeleteModel(TWVancouver.Data.TicketWaveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventTickets EventListing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventlisting = await _context.EventListing.FirstOrDefaultAsync(m => m.EventListingID == id);

            if (eventlisting is not null)
            {
                EventListing = eventlisting;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventlisting = await _context.EventListing.FindAsync(id);
            if (eventlisting != null)
            {
                EventListing = eventlisting;
                _context.EventListing.Remove(EventListing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
