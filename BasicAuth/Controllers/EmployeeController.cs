using BasicAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BasicAuth.Controllers
{
    public class EmployeeController : ApiController
    {
        [BasicAuthen]
        public HttpResponseMessage GetEmployees()
        {
            string username=Thread.CurrentPrincipal.Identity.Name;
            var empList=new EmployeeBL().GetEmployees();
            switch (username.ToLower())
            {
                case "Manjurul":
                    return Request.CreateResponse(HttpStatusCode.OK, empList.Where(e=>e.Gender.ToLower()=="male").ToList());

                case "Syed":
                    return Request.CreateResponse(HttpStatusCode.OK, empList.Where(e => e.Gender.ToLower() == "female").ToList());
                default:     return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
