using Announcements.Data;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AnnouncementsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Implement CRUD operations (GET, POST, PUT, DELETE) here
}