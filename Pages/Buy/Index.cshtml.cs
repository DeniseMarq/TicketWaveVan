using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketWave.Data;
using TicketWave.Models;

namespace TicketWave.Pages.Buy
{
    public class IndexModel : PageModel
    {
        private readonly TicketWave.Data.TicketWaveContext _context;

        public IndexModel(TicketWave.Data.TicketWaveContext context)
        {
            _context = context;
        }

        public IList<EventTickets> EventListing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            EventListing = await _context.EventListing.ToListAsync();
        }
    }
}
