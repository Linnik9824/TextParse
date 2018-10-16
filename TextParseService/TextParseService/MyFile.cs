using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace TextParseService
{
  public class MyFile
  {
    public string path;
    public string fileName;
    public int countMatches {get; set;}
    public MyFile(string path)
    {
      this.path = path;
      Regex rg = new Regex(@"(\w*\.txt)");
      this.fileName = rg.Match(path).Value;
    }
  }
}