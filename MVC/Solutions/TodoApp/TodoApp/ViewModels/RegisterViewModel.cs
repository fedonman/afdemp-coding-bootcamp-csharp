using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace TodoApp.ViewModels
{
    public class RegisterViewModel
    {
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}