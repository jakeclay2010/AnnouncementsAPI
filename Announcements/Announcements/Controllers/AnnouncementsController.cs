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

    // Implement CRUD operations (GET, POST, PUT, DELETE) here
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
        return CreatedAtAction(nameof(GetAnnouncement), new { id = announcement.id }, announcement);
    }

}