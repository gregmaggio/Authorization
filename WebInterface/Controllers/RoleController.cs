using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Net.Http;
using System.Web.Http;

using DTO;
using Action = DTO.Action;

using log4net;

using WebInterface.Areas.HelpPage.ModelDescriptions;

namespace WebInterface.Controllers
{
    public class RoleController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(RoleController));

        // GET api/role
        public IEnumerable<Role> Get()
        {
            if (!HasAction("Role.List"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return DAO.Roles.AsEnumerable<Role>();
        }

        // GET api/role/5
        public Role Get(int id)
        {
            if (!HasAction("Role.Read"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            var r = (from item in DAO.Roles where item.Id == id select item).FirstOrDefault();
            if (r == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return r;
        }

        // POST api/role
        public HttpResponseMessage Post([FromBody]CreateRoleParameters parameters)
        {
            if (!HasAction("Role.Create"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            var role = new Role()
            {
                Name = parameters.Name
            };
            if (parameters.Actions != null)
            {
                foreach (string action in parameters.Actions)
                {
                    var a = (from item in DAO.Actions where string.Compare(item.Name, action, true) == 0 select item).FirstOrDefault();
                    if (a != null)
                    {
                        role.Actions.Add(a);
                    }
                    else
                    {
                        role.Actions.Add(new Action()
                        {
                            Name = action
                        });
                    }
                }
            }
            DAO.Roles.Add(role);
            DAO.SaveChanges();

            var r = (from item in DAO.Roles where string.Compare(item.Name, parameters.Name, true) == 0 select item).First();
            _log.Debug(r);
            var location = new Uri(string.Format("{0}/Role/{1}", ApiUrl, r.Id.ToString()));
            var response = Request.CreateResponse(HttpStatusCode.Created, r);
            response.Headers.Location = location;
            return response;
        }

        // PUT api/role/5
        public void Put(int id, [FromBody]UpdateRoleParameters parameters)
        {
            if (!HasAction("Role.Update"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            var r = (from item in DAO.Roles where item.Id == id select item).FirstOrDefault();
            if (r == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            if (parameters.Actions != null)
            {
                foreach (string action in parameters.Actions)
                {
                    var a = (from item in DAO.Actions where string.Compare(item.Name, action, true) == 0 select item).First();
                    if (a != null)
                    {
                        r.Actions.Add(a);
                    }
                }
            }
            DAO.SaveChanges();
        }

        // DELETE api/role/5
        public void Delete(int id)
        {
            if (!HasAction("Role.Delete"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            var r = (from item in DAO.Roles where item.Id == id select item).FirstOrDefault();
            if (r == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            DAO.Roles.Remove(r);
            DAO.SaveChanges();
        }

        public class CreateRoleParameters
        {
            public string Name
            {
                get;
                set;
            }

            public IEnumerable<string> Actions
            {
                get;
                set;
            }
        }

        public class UpdateRoleParameters
        {
            public IEnumerable<string> Actions
            {
                get;
                set;
            }
        }
    }
}
