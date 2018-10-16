using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Threading;

namespace TextParseService
{
  [DataContract]
  public class ParseService : IParseService
  {
    static Dictionary<string, ParseStatusInfo> Results = new Dictionary<string, ParseStatusInfo>();
    [DataMember]
    static List<MyFile> files;
    public ResultParseFiles giveStatusInfoParse(string ID)
    {
      ResultParseFiles result = new ResultParseFiles();
      try
      {
        result.isSuccessful = true;
        result.Info = Results[ID];
        return result;
      }
      catch (Exception ex)
      {
        result.isSuccessful = false;
        result.ExceptionMessage = ex.Message;
        return result;
      }

    }

    public void StartParseFiles(string ID)
    {
      string[] pathes;
      using (var sr = new StreamReader(@"C:\Program Files (x86)\IIS Express\Pathes.txt"))
      {
        string json = sr.ReadToEnd();
        pathes = JsonConvert.DeserializeObject<string[]>(json);
      }
      files = new List<MyFile>();
      foreach (var path in pathes)
      {
        files.Add(new MyFile(path));
      }
      Thread ParseThread = new Thread(() => parseFiles(ID));
      ParseThread.Start();
    }


    void parseFiles(string IDClient)
    {
      int fileCount = files.Count();
      if (!Results.ContainsKey(IDClient))
      {
        Results.Add(IDClient, new ParseStatusInfo(1, fileCount, "", 0));
      }
      else
      {
        Results[IDClient] = new ParseStatusInfo(1, fileCount, "", 0);
      }
      var parse = files
                  .AsParallel()
                  .AsOrdered()
                  .Select(x=>searchBingoInFile(x));
      string json;      
      int currentFile = 0;
      int matchCount = 0;
      foreach (var file in parse)
      {
        currentFile++;
        matchCount += file.countMatches;
        Results[IDClient] = new ParseStatusInfo(currentFile, fileCount, file.fileName, matchCount);
        Thread.Sleep(0);
      }
      try
      {
        using (StreamWriter sw = new StreamWriter("JsonInfo.txt"))
        {
          json = JsonConvert.SerializeObject(Results[IDClient]);
          sw.Write(json);
        }
      }
      catch (Exception)
      {

      }
    }

    static MyFile searchBingoInFile(MyFile File)
    {
      Regex reg = new Regex(@"(\bbingo\b)", RegexOptions.IgnoreCase);
      using (StreamReader sr = new StreamReader(File.path))
      {
        string text = sr.ReadToEnd();
       // string[] bla = text.Split(' ');

        MatchCollection matches = reg.Matches(text);
        File.countMatches = matches.Count;
        //File.countMatches = (bla.Where(x => x.Contains("bingo"))).Count();
      }
      return File;
    }
  }
}
