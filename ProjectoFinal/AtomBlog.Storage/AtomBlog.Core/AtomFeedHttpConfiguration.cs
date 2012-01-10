using Microsoft.ApplicationServer.Http;

namespace AtomBlog.Core
{
    public class AtomFeedHttpConfiguration : HttpConfiguration
    {
        public AtomFeedHttpConfiguration()
        {
            Formatters.Clear();
            Formatters.Add(new AtomFeedVersionFormatter());
            Formatters.Add(new AtomFeedFormatter());
        }
    }
}