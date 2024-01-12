using Microsoft.Azure.Cosmos;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Microsoft.Azure.Cosmos.Linq;
using Azure.Core;
using connecttocosmosdb.Support;
using Azure;


namespace connecttocosmosdb.StepDefinitions
{
    [Binding]
    public class ConnectdbStepDefinitions 
    {
        internal static CosmosClient cosmosClient;
        internal static Container legcontainer;
        internal static string databaseid = "InlandRVP";
        internal static string containerid = "leg";
        internal static string connectionstring = "AccountEndpoint=https://cosmosrgeastus04ba6b57-c09a-4ca2-8f84db.documents.azure.com:443/;AccountKey=K0L1BhMXXNXMclhyRHdW2JL65jWTNgdnneLaxJMEPIVIlat7J20yC71arcxohqL6QLpGxvZgxwtqACDbgVAQRw==;";
        public readonly ISpecFlowOutputHelper outputHelper;
        public ConnectdbStepDefinitions(ISpecFlowOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        [Given(@"connect to cosmodb")]
        public async Task GivenConnectToCosmodb()
        {
           
            cosmosClient = new CosmosClient(connectionstring);
            var container=cosmosClient.GetContainer(databaseid, containerid);

            leg litem = new(
                id: "7ui82789r",
                bookingNo: "897654328",
                containerNo: "FRED5197654",
                vendor: "BASADRE",
                direction: "import"
                );

            leg createdItem = await container.CreateItemAsync<leg>(item: litem,partitionKey: new PartitionKey(litem.id));

            /*String sqlQueryText = "SELECT * FROM c WHERE c.id=  \"2f2822876\"";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<leg> queryResultSetIterator = container.GetItemQueryIterator<leg>(queryDefinition, requestOptions: new QueryRequestOptions
            {
                MaxConcurrency = 1
            });
            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<leg> response = await queryResultSetIterator.ReadNextAsync();
                foreach (var item in response)
                {
                    Console.WriteLine("Result "+item.containerNo);
                   // await container.DeleteItemAsync<leg>(item.id, new PartitionKey(item.id));
                }
            }
            //checkid("MNJU5199567", container);*/
            
        }    
        public static async Task checkid(string containerNo, Container container)
        {
            var queryable = container.GetItemLinqQueryable<leg>();
            
            var query=queryable.Where(s=>s.containerNo == containerNo);
            var legitem = query.ToFeedIterator();            
            while (legitem.HasMoreResults)
            {
                 var response = await legitem.ReadNextAsync();
                foreach (var item in response)
                {
                    Console.WriteLine("Result " + item.vendor);
                    
                }               
           
            }
          
        }

        [Then(@"success message received")]
        public void ThenSuccessMessageReceived()
        {
            Console.WriteLine("success");
        }
    }
}
