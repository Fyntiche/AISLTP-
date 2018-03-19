using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AISLTP.Entities
{
    public class Lico
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Fam { get; set; }

        [Required]
        public string Ima { get; set; }

        [Required]
        public string Otc { get; set; }

        [Required]
        public string Dr { get; set; }

        public string Pasport { get; set; }

        [Required]
        public string Nac { get; set; }

        [Required]
        public string Obl { get; set; }

        [Required]
        public string Rn { get; set; }

        [Required]
        public string Np { get; set; }

        [Required]
        public string Prim { get; set; }

        [Required]
        public string Vneshnost { get; set; }
    }
}