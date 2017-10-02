using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MicroServices.BlogService.Web
{
    /// <summary>
    /// This class is used to find root path of the web project in;
    /// unit tests (to find views) and entity framework core command line commands (to find conn string).
    /// 
    /// TODO Documentation: Add documentation why this class had to be customized
    /// </summary>
    public static class WebContentDirectoryFinder
    {
        public static string CalculateContentRootFolder()
        {
            var startupAssembly = Assembly.GetEntryAssembly();

            // Check if it is running from Package Manager Console (Add-Migration, Update-Database, etc)
            if (startupAssembly.GetName().Name == "ef")
            {
                string path = Path.GetDirectoryName(typeof(BlogServiceCoreModule).GetAssembly().Location);
                Console.WriteLine("Core Location: " + path);
                return path;
            }

            var startupAssemblyDirectoryPath = Path.GetDirectoryName(startupAssembly.Location);

            if (startupAssemblyDirectoryPath == null)
            {
                throw new Exception("Could not find location of startup (entry) assembly!");
            }

            return startupAssemblyDirectoryPath;
        }
    }
}
