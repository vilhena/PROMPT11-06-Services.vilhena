using AtomBlog.Core.MediaFormatters;
using Microsoft.ApplicationServer.Http;

namespace AtomBlog.Core
{
    public class AtomFeedHttpConfiguration : HttpConfiguration
    {
        public AtomFeedHttpConfiguration()
        {
            Formatters.Clear();
            Formatters.Add(new AtomFeedServiceDocumentFormatter());
            Formatters.Add(new AtomPostFeedFormatter());
            Formatters.Add(new AtomPostListFeedFormatter());
            Formatters.Add(new AtomFeedBlogFormatter());
            Formatters.Add(new AtomFeedBlogListFormatter());
        }
    }
}