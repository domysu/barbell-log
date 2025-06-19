using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using razorJqueryProject.Models;
namespace razorJqueryProject.Data
{



    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<razorJqueryProject.Models.Exercise> Exercise { get; set; } = default!;
        public DbSet<razorJqueryProject.Models.User> Users { get; set; } = default!;
    }
}