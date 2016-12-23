using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestShopApp.Models
{
    public class _dbContext : DbContext
    {
        public _dbContext() : base("_dbContext") { }
        public DbSet<Item> ItemsContext { get; set; }
        public DbSet<Member> MembersContext { get; set; }
    }
}