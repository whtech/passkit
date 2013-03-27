using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;

namespace RestSharp.Authenticators
{
    /// <summary>
    /// Custom implementation of the IAuthenticator class to support HTTP Digest Auth
    /// </summary>
    public class DigestAuthenticator : IAuthenticator
    {
        private readonly string _user;
        private readonly string _pass;

        public DigestAuthenticator(string user, string pass)
        {
            _user = user;
            _pass = pass;
        }

        public void Authenticate(
            IRestClient client, IRestRequest request)
        {
            request.Credentials = new NetworkCredential(_user, _pass);
        }
    }
}
