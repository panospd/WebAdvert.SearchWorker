using System;
using System.IO;
using System.Threading.Tasks;
using AdvertApi.Models.Messages;
using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using Nest;
using Newtonsoft.Json;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace WebAdvert.SearchWorker
{
    public class SearchWorker
    {
        private readonly IElasticClient _client;

        public SearchWorker()
            :this(ElasticSearchHelper.GetInstance(ConfigurationHelper.Instance))
        {
        }

        public SearchWorker(IElasticClient client)
        {
            _client = client;
        }

        public async Task Function(SNSEvent snsEvent, ILambdaContext context)
        {
            foreach (var record in snsEvent.Records)
            {
                context.Logger.LogLine(record.Sns.Message);
                context.Logger.LogLine(Directory.GetCurrentDirectory());

                var message = JsonConvert.DeserializeObject<AdvertConfirmedMessage>(record.Sns.Message);
                var advertDocument = MappingHelper.Map(message);

                await _client.IndexDocumentAsync(advertDocument);
            }
        }
    }
}
