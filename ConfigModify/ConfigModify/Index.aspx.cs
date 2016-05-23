using System;
using System.Threading;
using ConfigModify.Core;

namespace ConfigModify
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SetCurrentEnv();
            }
        }

        protected void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNewEnvType.Text))
            {
                lblErrorMessage.Text = "无效的值";
                return;
            }
            lblErrorMessage.Text = "";
            ConfigHelper.ChangeEnvironment(tbNewEnvType.Text);
            //IISHelper.RestartWebSite(ConfigManager.WebSiteName);
            AppPoolHelper.RecycleAppPool(ConfigManager.AppPoolName);
            Thread.Sleep(500);

            SetCurrentEnv();
        }

        private void SetCurrentEnv()
        {
            lblInfoEnvType.Text = ConfigHelper.GetReleaseInfoEnv();
            lblIniEnvType.Text = ConfigHelper.GetReleaseConfigEnv();
        }
    }
}