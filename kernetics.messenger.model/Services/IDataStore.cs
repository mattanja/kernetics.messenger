using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.model.Services
{
    public interface IDataStore
    {
        /// <summary>
        /// The "dirty" way to access the document store for now.
        /// </summary>
        Raven.Client.IDocumentStore DocumentStore { get; }
    }
}
