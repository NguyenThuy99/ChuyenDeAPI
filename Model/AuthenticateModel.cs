using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class AuthenticateModel
    {
        [Required]
        public string Usename { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
