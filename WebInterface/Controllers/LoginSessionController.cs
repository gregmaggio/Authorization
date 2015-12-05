using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using DTO;

using log4net;

using Util;

namespace WebInterface.Controllers
{
    public class LoginSessionController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(LoginSessionController));
        private static readonly int _sessionExpiresMinutes = Int32.Parse(ConfigurationManager.AppSettings["session.expires.minutes"]);

        // GET api/<controller>
        public IEnumerable<LoginSession> Get()
        {
            if (!HasAction("LoginSession.List"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return DAO.LoginSessions;
        }

        // GET api/<controller>/5
        public LoginSession Get(string id)
        {
            LoginSession loginSession = (from item in DAO.LoginSessions where string.Compare(item.SessionId, id, true) == 0 select item).FirstOrDefault();
            if (loginSession == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return loginSession;
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]CreateLoginSessionParameters value)
        {
            // Validate the user credentials
            value.Password = MD5Utility.CreateMD5(value.Password);
            User user = (from item in DAO.Users where (string.Compare(item.Email, value.Email, true) == 0) && (string.Compare(item.Password, value.Password, true) == 0) select item).FirstOrDefault();

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            LoginSession loginSession = new LoginSession()
            {
                SessionId = Guid.NewGuid().ToString().ToUpper(),
                UserId = user.Id,
                CreationTime = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(_sessionExpiresMinutes)
            };
            DAO.LoginSessions.Add(loginSession);
            DAO.SaveChanges();

            var location = new Uri(string.Format("{0}/LoginSession/{1}", ApiUrl, loginSession.SessionId));
            var response = Request.CreateResponse(HttpStatusCode.Created, loginSession);
            response.Headers.Location = location;
            return response;
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
        }

        public class CreateLoginSessionParameters
        {
            public string Email
            {
                get;
                set;
            }

            public string Password
            {
                get;
                set;
            }
        }
    }
}