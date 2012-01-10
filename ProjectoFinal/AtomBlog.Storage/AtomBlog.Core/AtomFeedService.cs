using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AtomBlog.Core
{
    [ServiceContract]
    public class AtomFeedService
    {
        [WebGet(UriTemplate = "")]
        public string GetVersion()
        {
            return this.GetType().Assembly.GetName().Version.ToString();
        }
    }
}
