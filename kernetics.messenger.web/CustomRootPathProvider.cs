using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kernetics.messenger.web
{
    public class CustomRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            // TODO make dynamic path (dependent on Debug/Release or config)
            return @"C:\projects\kernetics.messenger\kernetics.messenger.web";
        }
    }
}
