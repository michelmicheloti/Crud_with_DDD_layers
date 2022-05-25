using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; } = String.Empty;
        public string Audience { get; set; }  = String.Empty;
        public string Issuer { get; set; }  = String.Empty;
        public int ExpireMinutes { get; set; }
    }
}