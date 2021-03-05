using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace OnVideo.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string MembershipName { get; set; }
    }
}