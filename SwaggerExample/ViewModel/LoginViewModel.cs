using System;
using System.ComponentModel.DataAnnotations;

namespace SwaggerExample.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LoginDate { get; set; }
    }
}