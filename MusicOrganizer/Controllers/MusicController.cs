using MusicOrganizer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MusicOrganizer.Controllers
{
  public class MusicController : Controller
  {
    [HttpGet("/")]
    public ActionResult MethodName()
    {
      return View();
    }
  }
}