using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
            DataAccessLayer.DBTools.DBConfig.ConnectionString = Configuration.GetSection("DBConfig").GetValue<string>("ConnectionString");
        }
    }
}
