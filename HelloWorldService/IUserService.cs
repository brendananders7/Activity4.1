using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HelloWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        //This file defines URLs that will be used in the REST service.
        //1) Simple string response
        //2) URL that acepts a parameter number
        //3) a URL that will return a full object to the browser in JSON-formatted text.
        //4) Get all users
        //5) Get specific User Id

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SayHello/")]
        string SayHello();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetData/{value}/")]
        string GetData(string value);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetModelObject/{id}/")]
        HelloObject GetModelObject(string id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllUsers/")]
        DTO GetAllUsers();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUser/{id}/")]
        DTO GetUser(string id);

    }
}
