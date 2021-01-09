using RestSharp;
using System.IO;
using System.Collections.Generic;
using System.Text;



namespace ApiRestSharp
{
    //This class does not have a good design pattern. It's just for testing purpose
    public class RestApiHelper<T>
    {
        public RestClient _restClient;
        public RestRequest _restRequest;
        public string _baseUrl = "https://reqres.in/";

        public RestClient SetUrl(string resourceUrl)
        {
            var url = System.IO.Path.Combine(_baseUrl, resourceUrl);
            var _restClient = new RestClient(url);
            return _restClient;
        }

        // Post Method
        public RestRequest CreatePostRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        // Get Method
        public RestRequest CreateGettRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        //PUT Method
        public RestRequest CreatePutRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.PUT);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        //Delete Method
        public RestRequest CreateDeleteRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.DELETE);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public IRestResponse GetResponse(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO deserializeObj = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO>(content);
            return deserializeObj;
        }

    }
}
