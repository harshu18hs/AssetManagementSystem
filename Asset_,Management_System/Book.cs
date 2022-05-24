using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Asset__Management_System
{
    internal class Book
    {
        public Book(int sn, string bn, string ba, string bd)
        {
            this.serial_no = sn;
            this.book_name = bn;
            this.book_author = ba;
            this.book_dop = bd;
        }
        public int serial_no { set; get; }
        public string book_name { set; get; }
        public string book_author { set; get; }
        public string book_dop { set; get; }

    }
}
    

