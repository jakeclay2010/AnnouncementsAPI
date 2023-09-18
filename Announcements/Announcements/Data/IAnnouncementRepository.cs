using Announcements.Models;

namespace Announcements.Data
{
    public interface IAnnouncementRepository
    {
        List<Announcement> GetAnnouncements(int page, int pageSize);
        Announcement GetAnnouncementById(int id);
        void CreateAnnouncement(Announcement newAnnouncement);
        void UpdateAnnouncement(int id, Announcement updatedAnnouncement);
        void DeleteAnnouncement(int id);
    }
}
