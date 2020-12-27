using Ionic.Zip;
using System.Collections.Generic;
using System.IO;

namespace AutoBackupAssistant
{
    class Program
    {
        public static Dictionary<string, string> LoadConfig(string settingfile)
        {
            var dic = new Dictionary<string, string>();

            if (File.Exists(settingfile))
            {
                var settingdata = File.ReadAllLines(settingfile);
                for (var i = 0; i < settingdata.Length; i++)
                {
                    var setting = settingdata[i];
                    var sidx = setting.IndexOf("=");
                    if (sidx >= 0)
                    {
                        var skey = setting.Substring(0, sidx);
                        var svalue = setting.Substring(sidx + 1);
                        if (!dic.ContainsKey(skey))
                        {
                            dic.Add(skey, svalue);
                        }
                    }
                }
            }

            return dic;
        }

        static void Main(string[] args)
        {
            ConfigKeys configKeys = new ConfigKeys();
            var config = LoadConfig(@"./aba.cfg");

            string sourceFolder;
            string targetZipFile;

            if (!config.TryGetValue(configKeys.sourceFolder, out sourceFolder) || !config.TryGetValue(configKeys.targetZipFile, out targetZipFile))
            {
                System.Console.WriteLine("ERR: Config not found");
                return;
            };

            ZipFile zip = new ZipFile();
            zip.AddDirectory(sourceFolder);
            zip.Save(targetZipFile);
        }
    }
}
