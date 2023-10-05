using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuth.Models
{
    public class BasicAuthen:AuthorizationFilterAttribute
    {
        private const string Realm = "my Realm";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

                if (actionContext.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    actionContext.Response.Headers.Add("WWW-Authenticate",
                        string.Format("Basic realm=\"{0}\"",Realm));
                }
            }
            else
            {
                string authenToken=actionContext.Request.Headers.Authorization.Parameter;
                string decode = Encoding.UTF8.GetString(Convert.FromBase64String(authenToken));
                string[]  userpass=decode.Split(':');
                string username = userpass[0];
                string password = userpass[1];

                if (UserValidate.Login(username, password))
                {
                    var identity = new GenericIdentity(username);
                    IPrincipal principal = new GenericPrincipal(identity,null);
                    Thread.CurrentPrincipal = principal;

                    if(HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
           


            
        }
    }
}