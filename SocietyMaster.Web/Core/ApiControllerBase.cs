using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web;
using System.Web.Http;

namespace SocietyMaster.Web.Core
{
    public class ApiControllerBase : ApiController
    {
        protected void ValidateAuthorizedUser(string userRequested)
        {
            string userLoggedIn = User.Identity.Name;
            if (userLoggedIn != userRequested)
                throw new SecurityException("Attempting to access data for another user.");
        }

        protected HttpResponseMessage GetHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> codeToExecute)
        {
            HttpResponseMessage response = null;

            try
            {
                response = codeToExecute.Invoke();
            }
            catch (SecurityException ex)
            {
                response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
            //Todo: If needed catch other type of exceptions.
            catch (Exception ex)
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}