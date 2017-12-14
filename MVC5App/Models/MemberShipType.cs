using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5App.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SingUpFee { get; set; }
        public byte DuratiionInMonth { get; set; }
        public byte DiscountRate { get; set; }
    }
}