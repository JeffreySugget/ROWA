using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rowa.Models
{
    public class CreateRouteModel
    {
        [DisplayName("Start Point"), Required]
        public string StartPoint { get; set; }

        [DisplayName("End Point"), Required]
        public string EndPoint { get; set; }

        [DisplayName("Way Points"), Required]
        public string WayPoints { get; set; }

        public string ErrorMessage { get; set; }
    }
}