using APItest.Support;
using Newtonsoft.Json;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Xunit;
using System.Net.Http.Headers;
using System.Text;

namespace APItest.StepDefinitions
{
    [Binding]
    public class RegisterpostStepDefinitions
    {
        HttpClient httpClient;
        HttpRequestMessage request;
        HttpResponseMessage response;
        string responsebody;
        private readonly SpecFlowOutputHelper _specFlowOutputHelper;

        public RegisterpostStepDefinitions(SpecFlowOutputHelper _specFlowOutputHelper)
        {
            httpClient = new HttpClient();
            this._specFlowOutputHelper = _specFlowOutputHelper;

        }
        [Given(@"hit the register post uri ""([^""]*)""")]
        public async Task GivenHitTheRegisterPostUri(string uri)
        {
            httpClient = new HttpClient();
            
            registerdata rd = new registerdata()
            {
                email = "tracey.ramos@reqres.in",
                password = "pistol"
            };
            request = new HttpRequestMessage(HttpMethod.Post, uri);
            var data = JsonConvert.SerializeObject(rd);
            var contentdata = new StringContent(data,Encoding.UTF8,"application/JSON");
            //_specFlowOutputHelper.WriteLine("content: "+data+"contentdata: "+contentdata+"\r\n");
            request.Content = contentdata;
            //_specFlowOutputHelper.WriteLine("request content: "+request.Content.ToString());

            List<NameValueHeaderValue> headers = new List<NameValueHeaderValue>();

            //headers.Add(new NameValueHeaderValue("Content-Type","json"));
            headers.Add(new NameValueHeaderValue("Accept-Encoding","gzip, deflate, br"));
            headers.Add(new NameValueHeaderValue("User-Agent","x-machine"));

            foreach (var item in headers)
            {
                request.Headers.Add(item.Name, item.Value);
                //_specFlowOutputHelper.WriteLine("name: "+item.Name+"Value: "+item.Value+"\r\n");
            }
            response= await httpClient.SendAsync(request);
            responsebody=await response.Content.ReadAsStringAsync();

            _specFlowOutputHelper.WriteLine(responsebody);


        }

        [Then(@"created success message received")]
        public void ThenCreatedSuccessMessageReceived()
        {
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
