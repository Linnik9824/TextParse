using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TextParseService;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace GenerateFiles
{
  class Program
  {
    static int searchBingoInFile(string path)
    {
      Regex reg = new Regex(@"(\bbingo\b)");
      using (StreamReader sr = new StreamReader(path))
      {
        string text = sr.ReadToEnd().ToLower();
        MatchCollection matches = reg.Matches(text);
        return matches.Count;
      }

    }
    static void Main(string[] args)
    {
      using (var sw = new StreamWriter(@"C:\Program Files (x86)\IIS Express\Pathes.txt"))
      {
        string path = "C:\\Users\\Administrator\\Desktop\\tasks\\bingoFile";
        string[] pathes = new string[10000];
        List<string> text = new List<string>() ;
        ParseStatusInfo info = new ParseStatusInfo();
        for (int i = 0; i < 10000; i++)
        {
          pathes[i] = $"{path}{i}.txt";
          using (var sw2 = new StreamWriter($"{path}{i}.txt"))
          {
            sw2.Write("asjkdcbjkasbhdc asjdbhcjas asjkdcqweybingo BINGO bingoses");
            text.Add("asjkdcbjkasbhdc asjdbhcjas asjkdcqweybingo BINGO bingoses");
          }
        }       
        Console.WriteLine("the END!");
        string json = JsonConvert.SerializeObject(pathes, Formatting.Indented);
        sw.Write(json);
        var count = (text.Where(x => x.Contains("bingo"))).Count();
        Console.WriteLine(count);
      }
      Console.WriteLine("i`m done");
      Console.ReadKey();
      //string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=ParseInfoDataBase;Integrated Security=True;Pooling=False;Connect Timeout=30";
      //using (var connection = new SqlConnection(connectionString))
      //using (var command = new SqlCommand("UpdateParseInfo", connection))
      //{
      //  ParseStatusInfo info = new ParseStatusInfo();
      //  command.CommandType = CommandType.StoredProcedure;
      //  command.Parameters.Add("@CurrentFile", info.CurrentFile);
      //  command.Parameters.Add("@CurrentFileName", info.CurrentFileName);
      //  command.Parameters.Add("@CountMatches", info.CountMatches);
      //  using (SqlDataReader sdr = command.ExecuteReader())
      //    while (sdr.Read())
      //    {
      //      Console.WriteLine("Product: {0,-35} Total: {1,2}", sdr["CurrentFile"], sdr["CurrentFileName"]);
      //    }
      //}
      //Console.ReadKey();
    }
  }
}
