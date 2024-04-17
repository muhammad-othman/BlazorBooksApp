using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorBooksApp;

namespace BlazorBooksApp.Data
{
    public class BlazorBooksAppContext : DbContext
    {
        public BlazorBooksAppContext (DbContextOptions<BlazorBooksAppContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorBooksApp.Book> Book { get; set; } = default!;
    }
}
