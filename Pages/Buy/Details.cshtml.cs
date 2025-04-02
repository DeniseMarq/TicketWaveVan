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
    public class DetailsModel : PageModel
    {
        private readonly TWVancouver.Data.TicketWaveContext _context;

        public DetailsModel(TWVancouver.Data.TicketWaveContext context)
        {
            _context = context;
        }

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
    }
}
