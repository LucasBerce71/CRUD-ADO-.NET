using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcComAdo.Models
{
    public class Times
    {
        [Display(Name = "Id")]
        public int TimeId { get; set; }

        [Required(ErrorMessage = "Informe o nome do time")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Informe a qual estado o time pertence")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe as cores do time")]
        public string Cores { get; set; }
    }
}