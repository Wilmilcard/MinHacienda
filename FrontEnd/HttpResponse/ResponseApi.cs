using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.HttpResponse
{
    public class ResponseApi
    {
        public bool succcess { get; set; }
        public List<Students> data { get; set; }
    }
}
