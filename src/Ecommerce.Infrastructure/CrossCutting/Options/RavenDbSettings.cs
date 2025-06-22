using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.CrossCutting.Options
{
    public class RavenDbSettings
    {
        public string Url { get; set; }
        public string DatabaseName { get; set; }
    }
}
