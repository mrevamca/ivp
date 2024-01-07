using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using APItest.Support;
using Newtonsoft.Json;
using Xunit;
using System.Text;

namespace APItest.StepDefinitions
{
    [Binding]
    public class PostStepDefinitions
    {
        HttpClient httpClient;
        HttpRequestMessage request;
        HttpResponseMessage response;
        string responsebody;
        private readonly SpecFlowOutputHelper _specFlowOutputHelper;
        public PostStepDefinitions(SpecFlowOutputHelper _specFlowOutputHelper)
        {
            httpClient = new HttpClient();
            this._specFlowOutputHelper = _specFlowOutputHelper;
        }
        [Given(@"hit the post uri ""([^""]*)""")]
        public async Task GivenHitThePostUri(string uri)
        {
            httpClient = new HttpClient();
            postdata pd=new postdata()
            {
                name = "morpheus",
               job = "leader"
            };
            string data=JsonConvert.SerializeObject(pd);
            var contentdata=new StringContent(data,Encoding.UTF8,"application/json");
            response=await httpClient.PostAsync(uri, contentdata);
            responsebody= await response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine("specflow output: "+responsebody);

        }

        [Then(@"success message is received for post request")]
        public void ThenSuccessMessageIsReceivedForPostRequest()
        {
            Assert.True(response.IsSuccessStatusCode);
            _specFlowOutputHelper.WriteLine("specflow project success");
        }
    }
}
