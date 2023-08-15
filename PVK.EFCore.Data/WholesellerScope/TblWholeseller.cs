using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.WholesellerScope
{
    public class TblWholeseller :BaseEntity
    {
        public string Guid_Wholesellerid { get; set; }
        public string Name { get; set; }
        public string Companyname { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
       
    }
}
