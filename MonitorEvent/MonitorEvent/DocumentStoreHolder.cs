using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Documents;

namespace EventLog
{
    class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> LazyStore =//lazy keyword limits the amount of retrievals
          new Lazy<IDocumentStore>(() =>//creates a new document store object
          {
              var store = new DocumentStore
              {
                  Urls = new[] { "http://192.168.13.114:8080" },//stores the urls of the relevant database(s)
                  Database = "EventLog"
              };
              return store.Initialize();//initalizes the stored instance
          });
        public static IDocumentStore Store => LazyStore.Value;
    }


}
