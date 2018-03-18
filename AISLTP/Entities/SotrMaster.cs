using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class SotrMaster
    {
        [Key]
        public Guid Guid { get; set; }

        [Required]
        public string Cod_sotr { get; set; }

        [Required]
        public DateTime Dvi{ get; set; }

        [Required]
        public string Ima { get; set; }

        [Required]
        public string Fio { get; set; }

        [Required]
        public string Otc { get; set; }

        [Required]
        public DateTime Dr { get; set; }

        [Required]
        public string Sex { get; set; }


    }
}