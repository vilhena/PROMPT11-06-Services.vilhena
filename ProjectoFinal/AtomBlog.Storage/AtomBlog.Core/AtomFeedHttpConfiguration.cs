using Microsoft.ApplicationServer.Http;

namespace AtomBlog.Core
{
    public class AtomFeedHttpConfiguration : HttpConfiguration
    {
        public AtomFeedHttpConfiguration()
        {
            Formatters.Clear();
            Formatters.Add(new AtomFeedServiceDocumentFormatter());
            Formatters.Add(new AtomFeedFormatter());
        }
    }
}