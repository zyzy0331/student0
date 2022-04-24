#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using student0.Models;

namespace student0.Data
{
    public class student0Context : DbContext
    {
        public student0Context (DbContextOptions<student0Context> options)
            : base(options)
        {
        }

        public DbSet<student0.Models.student1> student1 { get; set; }
    }
}
