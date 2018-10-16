using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TextParseService.Startup))]
namespace TextParseService
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      app.MapSignalR();
    }

  }
}