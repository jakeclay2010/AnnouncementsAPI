namespace Announcements.Data
{
    public class Announcement
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string author { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}
