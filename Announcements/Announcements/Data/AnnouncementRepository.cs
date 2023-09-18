using Announcements.Models;

namespace Announcements.Data
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly AnnouncementDbContext _context;

        public AnnouncementRepository(AnnouncementDbContext context)
        {
            _context = context;
        }

        public List<Announcement> GetAnnouncements(int page, int pageSize)
        {
            return _context.Announcements
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Announcement GetAnnouncementById(int id)
        {
            return _context.Announcements.Find(id);
        }

        public void CreateAnnouncement(Announcement announcement)
        {
            _context.Announcements.Add(announcement);
            _context.SaveChanges();
        }

        public void UpdateAnnouncement(int id, Announcement announcement)
        {
            var existingAnnouncement = _context.Announcements.Find(id);
            if (existingAnnouncement != null)
            {
                existingAnnouncement.author = announcement.author;
                existingAnnouncement.date = announcement.date;
                existingAnnouncement.subject = announcement.subject;
                existingAnnouncement.body = announcement.body;

                _context.SaveChanges();
            }
        }

        public void DeleteAnnouncement(int id)
        {
            var announcement = _context.Announcements.Find(id);
            if (announcement != null)
            {
                _context.Announcements.Remove(announcement);
                _context.SaveChanges();
            }
        }
    }
}
