using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCodeCamp.Data;
using CoreCodeCamp.Data.Entities;
using Microsoft.AspNetCore.Mvc.Razor;

namespace CoreCodeCamp.Extensions
{
  public static class RazorPageExtensions
  {
    public static EventInfo GetEventInfo(this RazorPage page)
    {
      return (EventInfo)page.Context.Items["EventInfo"];
    }
  }
}