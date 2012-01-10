using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace AtomBlog.Storage
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var store = new DocumentStore(){Url = "http://localhost:8080"})
            {
                IndexCreation.CreateIndexes(typeof(Program).Assembly,store);
                using (var session = store.OpenSession())
                {
                    session.Store(new object());
                    session.SaveChanges();
                    session.Load<object>();
                    session.Query<object>();
                }
            }
        }
    }

    internal class TagsIndex: AbstractIndexCreationTask<object , TagsIndex.ReduceResult>
    {
        internal class ReduceResult
        {
            public string Tag { get; set; }
            public int Count { get; set; }
        }
        public TagsIndex()
        {
            //Map = ....(query)
        }   
    }
}
