using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

using DTO;

using log4net;

using Util;

namespace WebInterface.Controllers
{
    public class UserController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(UserController));

        // GET api/user
        public IEnumerable<User> Get()
        {
            if (!HasAction("User.List"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return DAO.Users;
        }

        // GET api/values/5
        public User Get(int id)
        {
            if (LoginSession == null)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            if (LoginSession.User.Id == id)
            {
                if (!HasAction("Self.Read"))
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            if (!HasAction("User.Read"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            var u = (from item in DAO.Users where item.Id == id select item).FirstOrDefault();
            if (u == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return u;
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]CreateUserParameters parameters)
        {
            if (!HasAction("User.Create"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            User user = new User()
            {
                Email = parameters.Email,
                Password = MD5Utility.CreateMD5(parameters.Password),
                FirstName = parameters.FirstName,
                LastName = parameters.LastName
            };
            if (parameters.Roles != null)
            {
                foreach (var role in parameters.Roles)
                {
                    var r = (from item in DAO.Roles where string.Compare(item.Name, role, true) == 0 select item).FirstOrDefault();
                    if (r != null)
                    {
                        user.Roles.Add(r);
                    }
                    else
                    {
                        user.Roles.Add(new Role()
                        {
                            Name = role
                        });
                    }
                }
            }
            DAO.Users.Add(user);
            DAO.SaveChanges();

            var u = (from item in DAO.Users where string.Compare(item.Email, parameters.Email, true) == 0 select item).First();
            _log.Debug(u);
            var location = new Uri(string.Format("{0}/User/{1}", ApiUrl, u.Id.ToString()));
            var response = Request.CreateResponse(HttpStatusCode.Created, u);
            response.Headers.Location = location;
            return response;
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]UpdateUserParameters parameters)
        {
            if (LoginSession == null)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            if (LoginSession.User.Id == id)
            {
                if (!HasAction("Self.Update"))
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            if (!HasAction("User.Update"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            var u = (from item in DAO.Users where item.Id == id select item).FirstOrDefault();
            if (u == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //Password = CreateMD5(parameters.Password),
            //dao.SaveChanges();
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
            if (!HasAction("User.Delete"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            var u = (from item in DAO.Users where item.Id == id select item).FirstOrDefault();
            if (u == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            DAO.Users.Remove(u);
            DAO.SaveChanges();
        }

        public class CreateUserParameters
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

            public string FirstName
            {
                get;
                set;
            }

            public string LastName
            {
                get;
                set;
            }

            public IEnumerable<string> Roles
            {
                get;
                set;
            }
        }

        public class UpdateUserParameters
        {
            public string Password
            {
                get;
                set;
            }

            public string FirstName
            {
                get;
                set;
            }

            public string LastName
            {
                get;
                set;
            }

            public IEnumerable<string> Roles
            {
                get;
                set;
            }
        }
    }
}