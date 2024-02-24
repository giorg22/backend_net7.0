using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class CommandResponse
    {
        public bool Success { get; set; }
        public IEnumerable<Error> Errors { get; set; }
        public string? ResultId { get; set; }
    }
}
