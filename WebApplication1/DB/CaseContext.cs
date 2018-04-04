using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using WebApplication1.Models;


namespace WebApplication1.DB
{
    public class CaseContext : DbContext
    {
        public CaseContext()
        { }

        public DbSet<Case> Cases { get; set; }
    }
}