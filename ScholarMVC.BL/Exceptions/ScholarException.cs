using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarMVC.BL.Exceptions
{
    public class ScholarException:Exception
    {
        public ScholarException():base("Default mesajdir")
        {
            
        }
        public ScholarException(string errormessage):base(errormessage)
        {
            
        }

    }
}
