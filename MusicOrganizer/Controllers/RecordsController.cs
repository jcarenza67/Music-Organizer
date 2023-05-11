using MusicOrganizer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MusicOrganizer.Controllers
{
  public class RecordsController : Controller
  {

    [HttpGet("/records")]
    public ActionResult Index()
    {
      List<Record> allRecords = Record.GetAll();
      return View(allRecords);
    }
    [HttpGet("/records/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/records")]
    public ActionResult Create(string recordTitle)
    {
      Record myRecord = new Record(recordTitle);
      return RedirectToAction("Index");
    }

    {
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

      [HttpPost("/records/{recordId}/artists")]
      public ActionResult Create(int recordId, string artistName)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Record foundRecord = Record.Find(recordId);
        Artist newArtist = new Artist(artistName);
        foundRecord.AddArtist(newArtist);
        List<Artist> recordArtists = foundRecord.Artists;
        model.Add("artists", recordArtists);
        model.Add("record", foundRecord);
        return View("Show", model);
      }      
    }
  }
}