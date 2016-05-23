using System;
using System.Threading;

namespace ConfigModify.Core
{
    public class IISHelper
    {
        public static void RestartWebSite(string websiteName)
        {
            var webManager = new Microsoft.Web.Administration.ServerManager();
            var startSite = webManager.Sites[websiteName];
            if (startSite == null)
            {
                throw new Exception(string.Format("Can't not find site:{0}", websiteName));
            }

            startSite.Stop();
            Thread.Sleep(500);
            startSite.Start();
        }
    }
}
