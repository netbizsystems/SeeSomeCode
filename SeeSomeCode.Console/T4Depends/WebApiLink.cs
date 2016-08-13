using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSomeCode.T4Depends
{
    public class WebApiLink
    {
        public WebApiLink(int id, string href)
        {
            LinkHref = $"/api/{href}/{id}";
            LinkRel = "self";
        }
        public string LinkRel { get; set; }
        public string LinkHref { get; private set; }
    }
}
