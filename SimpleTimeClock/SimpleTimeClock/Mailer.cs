using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;

namespace SimpleTimeClock
{
    public class Mailer
    {

        string content;
        string fromAddress;
        string toAddress;

        public Mailer(string content, string fromAddress, string toAddress)
        {
            this.content = content;
            this.fromAddress = fromAddress;
            this.toAddress = toAddress;
        }

        public void Send()
        {
            
        }

    }
}
