using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextParseService
{
  public class ParseStatusInfo
  {
    public int currentFile { get; set; }
    public int fileCount { get;  set; }
    public string currentFileName{ get; set; }
    public int matchCount { get ; set; }
    public ParseStatusInfo() { }
    public ParseStatusInfo(int currentFile, int fileCount, string fileName,int matchCount)
    {
      this.currentFile = currentFile;
      this.fileCount = fileCount;
      this.currentFileName = fileName;
      this.matchCount = matchCount;
    }
  }
}