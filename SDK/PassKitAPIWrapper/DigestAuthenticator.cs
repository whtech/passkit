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
        /// <summary>
        /// User string
        /// </summary>
        private readonly string _user;

        /// <summary>
        /// Password string
        /// </summary>
        private readonly string _pass;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user">User string</param>
        /// <param name="pass">Password string</param>
        public DigestAuthenticator(string user, string pass)
        {
            this._user = user;
            this._pass = pass;
        }

        /// <summary>
        /// Authenticate function
        /// </summary>
        /// <param name="client">IRestClient client</param>
        /// <param name="request">IRestRequest request</param>
        public void Authenticate(
            IRestClient client, IRestRequest request)
        {
            request.Credentials = new NetworkCredential(_user, _pass);
        }
    }
}
