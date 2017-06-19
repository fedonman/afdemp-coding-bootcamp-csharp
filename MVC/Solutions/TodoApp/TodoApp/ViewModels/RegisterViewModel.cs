using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.ViewModels
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}