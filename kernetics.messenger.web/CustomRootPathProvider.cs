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
        private string rootPath;

        public string GetRootPath()
        {
            return this.RootPath;
        }

        public string RootPath
        {
            get
            {
                if (this.rootPath == null)
                {
                    var assemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    if (assemblyPath.EndsWith("Debug") || assemblyPath.EndsWith("Release"))
                    {
                        this.rootPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(assemblyPath, "../.."));
                    }
                    else if (assemblyPath.EndsWith("bin"))
                    {
                        this.rootPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(assemblyPath, ".."));
                    }
                    else
                    {
                        this.rootPath = assemblyPath;
                    }
                    Console.WriteLine("Determined root path: " + this.rootPath);
                }
                return this.rootPath;
            }
        }
    }
}
