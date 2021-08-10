using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly03.Models;

namespace Vidly03.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipTypes> MembershipTypes { get; set; }
        public Customers Customers { get; set; }

    }
}