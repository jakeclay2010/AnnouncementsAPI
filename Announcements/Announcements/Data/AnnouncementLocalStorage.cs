using Announcements.Models;

namespace Announcements.Data
{
    public class AnnouncementLocalStorage : IAnnouncementRepository
    {
        private static Dictionary<int, Announcement> announcements = null;
        public AnnouncementLocalStorage()
        {
            if (announcements == null)
            {
                announcements = new Dictionary<int, Announcement>();
            }
        }

        public void CreateAnnouncement(Announcement newAnnouncement)
        {
            if (!announcements.ContainsKey(newAnnouncement.id))
            {
                announcements.Add(newAnnouncement.id, newAnnouncement);
            }
        }

        public void DeleteAnnouncement(int id)
        {
            if (!announcements.ContainsKey(id))
            {
                announcements.Remove(id);
            }
        }

        public Announcement GetAnnouncementById(int id)
        {
            if (announcements.ContainsKey(id))
            {
                return announcements[id];
            }

            return null;
        }

        public List<Announcement> GetAnnouncements(int page, int pageSize)
        {
            return announcements.Values
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public void UpdateAnnouncement(int id, Announcement updatedAnnouncement)
        {
            if (announcements.ContainsKey(id))
            {
                announcements[id] = updatedAnnouncement;
            }
        }
    }
}
