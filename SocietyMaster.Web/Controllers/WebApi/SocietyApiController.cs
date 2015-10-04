using SocietyMaster.Web.Core;
using SocietyMaster.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocietyMaster.Web.Controllers.WebApi
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/society")]
    public class SocietyApiController : ApiControllerBase
    {


        [HttpPost]
        [Route("register/validate1")]
        public HttpResponseMessage ValidateRegistrationStep1(HttpRequestMessage request,
            [FromBody]SocietyRegisterModel societyModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;


                //TODo:Should actually  validate all fields here as well...
                response = request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
        }

        [HttpPost]
        [Route("register/validate2")]
        public HttpResponseMessage ValidateRegistrationStep2(HttpRequestMessage request,
            [FromBody]SocietyRegisterModel societyModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                //TODO:Should actually  validate all fields here as well...
                response = request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
        }

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage CreateSociety(HttpRequestMessage request, [FromBody]SocietyRegisterModel societyModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                //TODO:Should actually  validate all fields here as well...
                response = request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
        }
    }    
        
}
