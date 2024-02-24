using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class SendMailRequest
    {
        public string userMail { get; set; }
        public string subject { get; set; }
        public string? body { get; set; } = null;
        public AlternateView? AlternateView { get; set; }
    }
}
