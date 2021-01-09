using ApiRestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestPostApi
{
    [TestClass]
    public class UnitTestPost
    {
        [TestMethod]
        public void CreateUsers()
        {
            // to Use PUT/DELETE/GET, change the URL based on the website https://reqres.in/
            string jsonString = @"{
                                        ""name"": ""morpheus"",
                                        ""job"": ""leader""
                                    }";
            RestApiHelper<CreateUser> restApi = new RestApiHelper<CreateUser>();
            var restUrl = restApi.SetUrl("api/users");
            var restRequest = restApi.CreatePostRequest(jsonString);
            var response = restApi.GetResponse(restUrl, restRequest);
            CreateUser content = restApi.GetContent<CreateUser>(response);

            Assert.AreEqual(content.name, "morpheus");
            Assert.AreEqual(content.job, "leader");
        }
    }
}

