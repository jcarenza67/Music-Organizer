using MusicOrganizer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    [HttpGet("/records/{recordId}/artists/new")]
    public ActionResult New(int recordId)
    {
      Record record = Record.Find(recordId);
      return View(record);
    }

    [HttpGet("/records/{recordId}/artists/{artistId}")]
    public ActionResult Show(int recordId, int artistId)
    {
      Artist artist = Artist.Find(artistId);
      Record record = Record.Find(recordId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("artist", artist);
      model.Add("record", record);
      return View(model);
    }
  }
}