using System.DirectoryServices;

namespace ConfigModify.Core
{
    public class AppPoolHelper
    {
        public static void RecycleAppPool(string appPoolName)
        {
            using (Microsoft.Web.Administration.ServerManager serverManager = new Microsoft.Web.Administration.ServerManager())
            {

                var pool = serverManager.ApplicationPools[appPoolName];

                pool.Recycle();
            }
        }
    }
}
