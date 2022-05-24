using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset__Management_System
{
    internal class Hardware
    {
            public Hardware(int sno, string htype, double hprice, int hqty)
            {
                this.serial_no = sno;
                this.hardware_type = htype;
                this.hardware_price = hprice;
                this.hardware_qty = hqty;
            }
            public int serial_no { set; get; }
            public string hardware_type { set; get; }
            public double hardware_price { set; get; }
            public int hardware_qty { set; get; }
        }
    }


    

