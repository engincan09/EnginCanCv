using EnginCan.Core.Elastic.Abstract;
using EnginCan.Core.Elastic.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Core.Elastic.Concrete
{
    public class ElasticSearchService<T> : IElasticSearchService<T> where T : class
    {
        ElasticClientProvider _provider;
        ElasticClient _client;
        public ElasticSearchService(ElasticClientProvider provider)
        {
            _provider = provider;
            _client = _provider.ElasticClient;
        }

        public void CheckExistsAndInsertLog(T logModel, string indexName)
        {

            if (!_client.Indices.Exists(indexName).Exists)
            {
                var newIndexName = indexName + System.DateTime.Now.Ticks;

                var indexSettings = new IndexSettings();
                indexSettings.NumberOfReplicas = 1;
                indexSettings.NumberOfShards = 3;

                var response = _client.Indices.Create(newIndexName, index =>
                   index.Map<T>(m => m.AutoMap()
                          )
                  .InitializeUsing(new IndexState() { Settings = indexSettings })
                  .Aliases(a => a.Alias(indexName)));

            }
            IndexResponse responseIndex = _client.Index<T>(logModel, idx => idx.Index(indexName));
            int a = 0;
        }

        public IReadOnlyCollection<AuditLogModel> SearchAuditLog(int? userID, DateTime? BeginDate, DateTime? EndDate, string className = "", string operation = "Update", int page = 0, int rowCount = 10, string indexName = "audit_log")
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<ErrorLogModel> SearchErrorLog(int? userID, int? errorCode, DateTime? BeginDate, DateTime? EndDate, string controller = "", string action = "", string method = "", string services = "", int page = 0, int rowCount = 10, string indexName = "error_log")
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<LoginLogModel> SearchLoginLog(string userID, DateTime? BeginDate, DateTime? EndDate, string controller = "", string action = "", int? page = 0, int? rowCount = 10, string indexName = "login_log")
        {
            throw new NotImplementedException();
        }
    }
}
