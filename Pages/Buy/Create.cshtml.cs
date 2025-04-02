using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketWave.Data;
using TicketWave.Models;

namespace TicketWave.Pages.Buy
{
    public class CreateModel : PageModel
    {
        private readonly TicketWave.Data.TicketWaveContext _context;

        public CreateModel(TicketWave.Data.TicketWaveContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EventTickets EventListing { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EventListings.Add(EventListing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
