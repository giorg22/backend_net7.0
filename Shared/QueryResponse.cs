using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class QueryResponse<T>
    {
        public bool Success { get; set; }
        public IEnumerable<Error> Errors { get; set; }
        public T Data { get; set; }
    }
}
