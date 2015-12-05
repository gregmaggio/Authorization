using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Http;

using DTO;
using Action = DTO.Action;

using log4net;

using WebInterface.Areas.HelpPage.ModelDescriptions;

namespace WebInterface.Controllers
{
    public class ActionController : ControllerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(ActionController));
        
        // GET api/action
        public IEnumerable<Action> Get()
        {
            if (!HasAction("Action.List"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return DAO.Actions;
        }

        // GET api/action/5
        public Action Get(int id)
        {
            if (!HasAction("Action.Read"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            var a = (from item in DAO.Actions where item.Id == id select item).FirstOrDefault();
            if (a == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return a;
        }

        // POST api/action
        public HttpResponseMessage Post([FromBody]CreateActionParameters parameters)
        {
            if (!HasAction("Action.Create"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            DAO.Actions.Add(new DTO.Action()
                {
                    Name = parameters.Name
                });
            DAO.SaveChanges();
            var a = (from item in DAO.Actions where string.Compare(item.Name, parameters.Name, true) == 0 select item).First();
            _log.Debug(a);
            var location = new Uri(string.Format("{0}/Action/{1}", ApiUrl, a.Id.ToString()));
            var response = Request.CreateResponse(HttpStatusCode.Created, a);
            response.Headers.Location = location;
            return response;
        }

        // PUT api/action/5
        public void Put(int id, [FromBody]UpdateActionParameters parameters)
        {
            if (!HasAction("Action.Update"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            var a = (from item in DAO.Actions where item.Id == id select item).First();
            if (a == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            a.Name = parameters.Name;
            DAO.SaveChanges();
        }

        // DELETE api/action/5
        public void Delete(int id)
        {
            if (!HasAction("Action.Delete"))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            var a = (from item in DAO.Actions where item.Id == id select item).FirstOrDefault();
            if (a == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            DAO.Actions.Remove(a);
            DAO.SaveChanges();
        }

        public class CreateActionParameters
        {
            public string Name
            {
                get;
                set;
            }
        }

        public class UpdateActionParameters
        {
            public string Name
            {
                get;
                set;
            }
        }
    }
}
