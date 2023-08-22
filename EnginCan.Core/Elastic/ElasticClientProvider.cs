using EnginCan.Core.Elastic.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Core.Elastic
{
    public class ElasticClientProvider
    {
        public ElasticClient ElasticClient { get; }
        public string ElasticSearchHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ElasticClientProvider(Microsoft.Extensions.Options.IOptions<ElasticConnectionSettings> elasticConfig)
        {
            ElasticSearchHost = elasticConfig.Value.ElasticSearchHost;
            UserName = elasticConfig.Value.UserName;
            Password = elasticConfig.Value.Password;
            ElasticClient = CreateClient();
        }

        private ElasticClient CreateClient()
        {
            var connectionSettings = new ConnectionSettings(new Uri(ElasticSearchHost))
                .DisablePing()
                .DisableDirectStreaming(true)
                .SniffOnStartup(false)
                .SniffOnConnectionFault(false);

            return new ElasticClient(connectionSettings);
        }

        public ElasticClient CreateClientWithIndex(string defaultIndex)
        {
            var connectionSettings = new ConnectionSettings(new Uri(ElasticSearchHost))
                .DisablePing()
                .SniffOnStartup(false)
                .SniffOnConnectionFault(false)
                .DefaultIndex(defaultIndex);

            return new ElasticClient(connectionSettings);
        }
    }
}
