using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocietyMaster.Web.Models
{
    public class SocietyRegisterModel
    {
        //ToDO: Add Properties Later
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        //Add Remianig Properties reagrding buildings and House collection
    }
}