using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace GitHubSoap.Broker.GitHub
{
    public class GitHubIdentity:IIdentity
    {
        public GitHubIdentity(string name, string password)
        {
            _name = name;
            _password = password;
        }

        private readonly string _name;
        public string Name
        {
            get { return _name; }
        }

        private readonly string _password;
        public string Password
        {
            get { return _password; }
        }

        public string AutenticationToken
        {
            get
            {
                return
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _name, _password)));
            }
        }

        public string AuthenticationType
        {
            get { return "Basic"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }
    }
}
