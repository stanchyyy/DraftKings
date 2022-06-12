using System.Collections.Generic;
using Book_lib.Models;
using Microsoft.EntityFrameworkCore;

namespace Test_Book_lib.Drivers
{
    public class DatabaseDriver : DbContext
    {
        public DbSet<BookModel> BookModel { get; set; }

    }
}