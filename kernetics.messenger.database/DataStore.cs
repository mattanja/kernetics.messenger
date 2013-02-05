using kernetics.messenger.model.Services;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.database
{
    public class DataStore : IDataStore
    {
        public DataStore()
        {
            var documentStore = new EmbeddableDocumentStore
            {
                DataDirectory = "Data",
                UseEmbeddedHttpServer = true,
            };

            try
            {
                documentStore.Configuration.Port = 8881;
                Raven.Database.Server.NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(documentStore.Configuration.Port);
                documentStore.Initialize();
            }
            catch (Exception ex)
            {
                // TODO error handling
                Console.Error.WriteLine(ex.ToString());
            }

            this.DocumentStore = documentStore;
        }

        public Raven.Client.IDocumentStore DocumentStore { get; private set; }
    }
}
