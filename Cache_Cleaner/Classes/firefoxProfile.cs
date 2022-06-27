using IniParser;
using IniParser.Model;
using System;
using System.IO;

namespace Cache_Cleaner
{
    internal class firefoxProfile
    {
        public static string get()
        {
            string aux, profile;
            var parser = new FileIniDataParser();
            if (File.Exists("C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Mozilla\\Firefox\\profiles.ini"))
            {
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
            }
            return null;
        }
    }
}
