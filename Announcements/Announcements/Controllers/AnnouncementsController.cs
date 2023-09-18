using Announcements.Data;
using Announcements.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController : ControllerBase
{
    private readonly IAnnouncementRepository _repository = null;

    public AnnouncementsController(IAnnouncementRepository repository)
    {
        if (_repository == null)
        {
            _repository = repository;
        }
    }

    [HttpGet]
    public IActionResult GetAnnouncements(int page = 1, int pageSize = 10)
    {
        var announcements = _repository.GetAnnouncements(page, pageSize);
        return Ok(announcements);
    }

    [HttpGet("{id}")]
    public IActionResult GetAnnouncement(int id)
    {
        var announcement = _repository.GetAnnouncementById(id);
        if (announcement == null)
            return NotFound();

        return Ok(announcement);
    }

    [HttpPost]
    public IActionResult CreateAnnouncement([FromBody] Announcement announcement)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _repository.CreateAnnouncement(announcement);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnnouncement(int id, [FromBody] Announcement announcement)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingAnnouncement = _repository.GetAnnouncementById(id);
        if (existingAnnouncement == null)
            return NotFound();

        _repository.UpdateAnnouncement(id, announcement);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnnouncement(int id)
    {
        var existingAnnouncement = _repository.GetAnnouncementById(id);
        if (existingAnnouncement == null)
            return NotFound();

        _repository.DeleteAnnouncement(id);
        return Ok();
    }
}