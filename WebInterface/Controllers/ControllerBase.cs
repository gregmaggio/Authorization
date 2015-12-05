using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;

using DTO;

namespace WebInterface.Controllers
{
    public abstract class ControllerBase : ApiController
    {
        #region Member Variables

        private static readonly string _sessionParameter = ConfigurationManager.AppSettings["session.parameter"];
        private static readonly string _sessionCookie = ConfigurationManager.AppSettings["session.cookie"];
        private AuthorizationEntities _dao = null;
        private string _rootUrl = string.Empty;
        private string _apiUrl = string.Empty;
        private NameValueCollection _queryParameters = null;
        private string _sessionId = string.Empty;
        private LoginSession _loginSession = null;

        #endregion

        #region Properties

        public AuthorizationEntities DAO
        {
            get
            {
                if (_dao == null)
                {
                    _dao = new AuthorizationEntities();
                }
                return _dao;
            }
        }

        public string RootUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_rootUrl))
                {
                    StringBuilder rootUrl = new StringBuilder();
                    rootUrl.Append(Request.RequestUri.Scheme);
                    rootUrl.Append("://");
                    rootUrl.Append(Request.RequestUri.Host);
                    if (Request.RequestUri.Port != 80)
                    {
                        rootUrl.Append(":");
                        rootUrl.Append(Request.RequestUri.Port);
                    }
                    _rootUrl = rootUrl.ToString();
                }
                return _rootUrl;
            }
        }

        public string ApiUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_apiUrl))
                {
                    _apiUrl = string.Format("{0}/api", RootUrl);
                }
                return _apiUrl;
            }
        }

        public NameValueCollection QueryParameters
        {
            get
            {
                if (_queryParameters == null)
                {
                    _queryParameters = HttpUtility.ParseQueryString(Request.RequestUri.Query);
                }
                return _queryParameters;
            }
        }

        public string SessionId
        {
            get
            {
                if (string.IsNullOrEmpty(_sessionId))
                {
                    _sessionId = QueryParameters[_sessionParameter];
                }
                if (string.IsNullOrEmpty(_sessionId))
                {
                    // TODO: Find out how to check the headers for the session cookie
                    //CookieHeaderValue cookie = Request.Headers.GetCookies(_sessionCookie).FirstOrDefault();
                }
                return _sessionId;
            }
        }

        public LoginSession LoginSession
        {
            get
            {
                if (_loginSession == null)
                {
                    if (!string.IsNullOrEmpty(SessionId))
                    {
                        _loginSession = (from item in DAO.LoginSessions where (string.Compare(SessionId, item.SessionId, true) == 0) && (item.Expires > DateTime.UtcNow) select item).FirstOrDefault();
                    }
                }
                return _loginSession;
            }
        }

        #endregion

        #region Protected Methods

        protected bool HasAction(string action)
        {
            if (LoginSession != null)
            {
                foreach (var r in LoginSession.User.Roles)
                {
                    foreach (var a in r.Actions)
                    {
                        if (string.Compare(a.Name, action, true) == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion
    }
}