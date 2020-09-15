using FirstCoreApp.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Models
{
    public class NewsContext : DbContext
    {

        public NewsContext(DbContextOptions<NewsContext> options) 
            : base (options)

        {

        }

    public DbSet<News> news { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TeamMember> teamMembers { get; set; }
    public DbSet<ContactUs> contacts { get; set; }

}
}
