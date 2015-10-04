using SocietyMaster.Web.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocietyMaster.Web.Controllers.MVC
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("society")]
    public class SocietyController : ViewControllerBase
    {
        //ToDO: Remove the below action - NOt Used 
       [HttpGet]
        public ActionResult CreateSociety()
        {
            return View();
        }


        [HttpGet]
        //this route will be defined in the RouteConfig..
        
        public ActionResult Register()
       {
           return View();
       }
    }
}