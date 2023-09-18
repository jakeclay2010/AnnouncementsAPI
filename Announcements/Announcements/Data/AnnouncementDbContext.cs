using Announcements.Models;
using Microsoft.EntityFrameworkCore;

namespace Announcements.Data
{
    public class AnnouncementDbContext : DbContext
    {
        public AnnouncementDbContext(DbContextOptions<AnnouncementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Announcement> Announcements { get; set; }
    }
}
