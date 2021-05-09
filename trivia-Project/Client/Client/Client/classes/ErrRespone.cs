using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.classes
{
    class ErrRespone
    {
        public ErrRespone(string message)
        {
            this.message = message;
        }
        public string message;
        public override string ToString()
        {
            return message;
        }
    }
}
