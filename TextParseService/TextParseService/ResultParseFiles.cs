using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextParseService
{
  public class ResultParseFiles
  {
    public bool isSuccessful { get; set; }
    public ParseStatusInfo Info { get; set; }

    public string ExceptionMessage { get; set; }
    public ResultParseFiles() { }
  }
}