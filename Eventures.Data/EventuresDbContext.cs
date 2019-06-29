using Eventures.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Data
{
    
    public class EventuresDbContext : IdentityDbContext<EventuresUser, IdentityRole, string>
    {
        public DbSet<EventuresUser> EventuresUsers { get; set; }

        public DbSet<Event> Events { get; set; }
        public EventuresDbContext(DbContextOptions<EventuresDbContext> options) : base(options)
        {

        }
    }
}
