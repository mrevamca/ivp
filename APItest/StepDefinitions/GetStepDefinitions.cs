using Newtonsoft.Json;
using System;
using System.Net.NetworkInformation;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Xunit;

namespace APItest.StepDefinitions
{
    [Binding]
    public class GetStepDefinitions
    {
        HttpClient httpClient;
        HttpResponseMessage response;
        string responsebody;
        private SpecFlowOutputHelper _specFlowOutputHelper;

        public GetStepDefinitions(SpecFlowOutputHelper _specFlowOutputHelper)
        {
            httpClient = new HttpClient();
            this._specFlowOutputHelper = _specFlowOutputHelper;
        }

        [Given(@"hit the uri ""([^""]*)""")]
        public async Task GivenHitTheUri(string uri)
        {
            httpClient=new HttpClient();
            response = await httpClient.GetAsync(uri);
            responsebody= await response.Content.ReadAsStringAsync();
           _specFlowOutputHelper.WriteLine(responsebody);
        }
        [Then(@"success message is received")]
        public void ThenSuccessMessageIsReceived()
        {
            Assert.True(response.IsSuccessStatusCode);
            
        }

    }
}
