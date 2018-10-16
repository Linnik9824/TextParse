using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TextParseService
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IParseService" in both code and config file together.
  //[ServiceContract(SessionMode = SessionMode.Required)]
  [ServiceContract]
  public interface IParseService
  {


    [WebGet(UriTemplate = "/giveStatusInfoParse?ID={ID}",RequestFormat = WebMessageFormat.Json)]
    [OperationContract]
    //[WebInvoke(UriTemplate = "/giveStatusInfoParse/", Method = "GET", RequestFormat = WebMessageFormat.Json
    //      )]
    ResultParseFiles giveStatusInfoParse(string ID);

    [WebGet(UriTemplate = "/StartParseFiles?ID={ID}", RequestFormat = WebMessageFormat.Json)]
    [OperationContract]
    void StartParseFiles(string ID);
  }
}
