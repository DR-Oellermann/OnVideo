using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnVideo.Models;

namespace OnVideo.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}