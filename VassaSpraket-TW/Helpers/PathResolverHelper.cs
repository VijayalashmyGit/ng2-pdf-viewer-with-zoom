using VassaSpraket_TW.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VassaSpraket_TW.Helpers
{
    public class PathResolverHelper
    {
        private static IConfigurationRoot config = null;


        public static string ResolveUrl(PathResolverEnum type)
        {
            return GetAppSettingsSection("Path:TeacherBaseUrl") + @"/" + type.ToString() + @"/";
        }


        public static string ResolveUrl(string section)
        {
            if (string.IsNullOrEmpty(section))
            { 
                return ""; 
            }
            else
            {
                return GetAppSettingsSection(section);
            }
        }

        private static string GetAppSettingsSection(string sectionname)
        {
            if (config == null)
            {
                config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            }
            return config.GetSection(sectionname).Value;
        }
    }
}
