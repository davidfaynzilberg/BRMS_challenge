using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace BRMSTools.API.Helpers
{
    public static class ContextHelper
    {
        public static String Verb(this HttpMethod vb)
        {
            return vb.ToString().ToLower();
        }
    }
}
