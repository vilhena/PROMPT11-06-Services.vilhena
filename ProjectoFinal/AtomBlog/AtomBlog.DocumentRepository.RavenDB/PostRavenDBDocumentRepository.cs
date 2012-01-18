using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtomBlog.Domain.AtomDomainModel;
using AtomBlog.Domain.Repositories;
using Raven.Client.Document;

namespace AtomBlog.DocumentRepository.RavenDB
{
    public class PostRavenDBDocumentRepository : GenericRavenDBDocumentRepository<Post>
    {
        
    }
}
