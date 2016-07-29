using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace PRDGSTest.Security
{
    public class PRDGSAuthorize : AuthorizeAttribute
    {
        private const string BasicAuthResponseHeader = "WWW-Authenticate";
        private const string BasicAuthResponseHeaderValue = "Basic";

        public override void OnAuthorization(HttpActionContext actionContext )
        {
            try
            {

                AuthenticationHeaderValue authValue = actionContext.Request.Headers.Authorization;
                if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter) && authValue.Scheme == BasicAuthResponseHeaderValue)
                {
                    Credential parseUserInfo = ParseAuthorizationHeader(authValue.Parameter);
                    var customPrincipal = new PRDGSPrincipal(parseUserInfo.UserName);
                    if (!customPrincipal.IsInRole(Roles))
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                        actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
                        return;
                    }
                    else {
                        //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK);
                        //actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
                        //return;
                    }

                }
            }
            catch (Exception)
            {

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
            }
        }

        private Credential ParseAuthorizationHeader(string authHeader)
        {
            string[] credentials = Encoding.ASCII.GetString(Convert.FromBase64String(authHeader)).Split(new[] { ':' });
            if(credentials.Length != 2 || string.IsNullOrEmpty(credentials[0]) || string.IsNullOrEmpty(credentials[1]))
            {
                return null;
            }
            return new Credential() { UserName = credentials[0], Password = credentials[1] };

        }


    }
}