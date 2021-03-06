using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Data.Entities;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreCodeCamp.Controllers.Web
{
  [Authorize]
  [Route("{moniker}/CallForSpeakers")]
  public class CallForSpeakersController : MonikerControllerBase
  {
    private UserManager<CodeCampUser> _userMgr;

    public CallForSpeakersController(ICodeCampRepository repo,
      UserManager<CodeCampUser> userMgr,
      ILogger<CallForSpeakersController> logger) : base(repo, logger)
    {
      _userMgr = userMgr;
    }

    [AllowAnonymous]
    [HttpGet("")]
    public IActionResult Index(string moniker)
    {
      return View();
    }

    [HttpGet("Manage", Name = "MySpeakerPage")]
    public IActionResult Manage(string moniker)
    {
      var speaker = _repo.GetSpeakerForCurrentUser(moniker, User.Identity.Name);
      if (speaker == null) return RedirectToAction("Speaker");
      return View(speaker);
    }

    [HttpGet("Speaker")]
    public IActionResult Speaker(string moniker)
    {
      return View();
    }

  }
}
