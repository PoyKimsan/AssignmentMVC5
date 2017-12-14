using MVC5App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5App.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}