using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache_Cleaner
{
    internal class firefoxProfile
    {
        public static string get()
        {
            string aux, profile;
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Mozilla\\Firefox\\profiles.ini");
            foreach (var value in data.Sections)
            {
                if (value.SectionName.Contains("Install"))
                    foreach (KeyData key in value.Keys)
                    {
                        if (key.KeyName == "Default")
                        {
                            aux = key.Value;
                            return profile = aux.Replace("/", "\\");
                        }
                    }
            }
            return null;
        }
    }
}
