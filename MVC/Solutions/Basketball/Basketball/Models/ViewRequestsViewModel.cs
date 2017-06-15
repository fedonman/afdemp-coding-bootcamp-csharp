using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basketball.Models
{
    public class ViewRequestsViewModel : BaseViewModel
    {
        public List<JoinRequest> Requests { get; set; }
    }
}