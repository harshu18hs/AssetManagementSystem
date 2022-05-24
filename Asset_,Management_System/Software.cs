using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Asset__Management_System
{
    internal class Software
    {
            public Software(int sno, string sname, string lno, string ldesc)
            {
                this.serial_no = sno;
                this.software_name = sname;
                this.license_no = lno;
                this.license_desc = ldesc;

            }
            public int serial_no { set; get; }
            public string software_name { set; get; }
            public string license_no { set; get; }
            public string license_desc { set; get; }
        }
    }

