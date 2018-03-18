using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AISLTP.Entities
{
    public class Court
    {
        [Key]
        public string ID { get; set; }         

        [Required]
        public string Txt { get; set; }

        public string Prim { get; set; }
        
    }
}
