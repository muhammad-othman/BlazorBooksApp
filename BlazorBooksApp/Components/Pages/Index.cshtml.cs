using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlazorBooksApp;
using BlazorBooksApp.Data;

namespace BlazorBooksApp.Components.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BlazorBooksApp.Data.BlazorBooksAppContext _context;

        public IndexModel(BlazorBooksApp.Data.BlazorBooksAppContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
