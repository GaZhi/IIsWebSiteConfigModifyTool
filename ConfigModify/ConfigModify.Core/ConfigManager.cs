namespace ConfigModify.Core
{
    public class ConfigManager
    {
        public static string ReleaseInfoPath
        {
            get { return System.Web.Configuration.WebConfigurationManager.AppSettings["ReleaseInfoPath"]; }
        }

        public static string ReleaseConfigPath
        {
            get { return System.Web.Configuration.WebConfigurationManager.AppSettings["ReleaseConfigPath"]; }
        }

        public static string AppPoolName
        {
            get { return System.Web.Configuration.WebConfigurationManager.AppSettings["AppPoolName"]; }
        }
    }
}
