using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace ConfigModify.Core
{
    public class ConfigHelper
    {
        public static void ChangeEnvironment(string env)
        {
            ModifyReleaseInfo(env);
            ModifyReleaseInfoConfig(env);
        }

        public static string GetReleaseInfoEnv()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigManager.ReleaseInfoPath);
            var node = xmlDoc.SelectSingleNode("ReleaseInfo/Target/EnvType");
            if (node == null || node.FirstChild == null)
                return string.Empty;

            return node.FirstChild.Value;
        }

        public static string GetReleaseConfigEnv()
        {
            var newLines = new List<string>();

            var lines = File.ReadAllLines(ConfigManager.ReleaseConfigPath);
            var line = lines.SingleOrDefault(o => o.StartsWith("ReleaseInfo.Target.EnvType="));
            if (line == null)
            {
                return string.Empty;
            }
            return line.Replace("ReleaseInfo.Target.EnvType=", "");
        }

        private static void ModifyReleaseInfo(string env)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigManager.ReleaseInfoPath);
            var node = xmlDoc.SelectSingleNode("ReleaseInfo/Target/EnvType");
            if (node == null)
                return;

            if (node.FirstChild == null)
                node.InnerText = env;
            else
                node.FirstChild.Value = env;

            xmlDoc.Save(ConfigManager.ReleaseInfoPath);
        }

        private static void ModifyReleaseInfoConfig(string env)
        {
            var newLines = new List<string>();

            var lines = File.ReadAllLines(ConfigManager.ReleaseConfigPath);
            lines.ToList().ForEach(o =>
            {
                newLines.Add(o.StartsWith("ReleaseInfo.Target.EnvType=")
                    ? string.Format("ReleaseInfo.Target.EnvType={0}", env)
                    : o);
            });

            File.WriteAllLines(ConfigManager.ReleaseConfigPath, newLines);
        }
    }
}
