using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Threading;

namespace ProjectPublisher2016
{
    public partial class PublisherRibbon
    {
        private void PublisherRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnPublish_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.PublishButton();
        }

        private void btnUpdate_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.UpdateButton();
        }

        private void btnRequestUpdates_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.RequestUpdates();
        }

        private void btnEmailTeam_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.EmailTeam();
        }

        private void btnEmailTasks_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.EmailTask();
        }

        private void btnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.OptionsButton();
        }

        private void btnResMapping_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ResourceMapping();
        }

        private void btnCustomFields_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.CustomField();
        }

        private void btnInformation_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ProjectInformation();
        }

        private void btnSynchronizeFields_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ButtonSynchFields();
        }

        private void btnDelete_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ButtonDeleteProject();
        }

        private void btnWorkspace_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.GoToWorkspace();
        }

        private void btnProxy_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ProxySettings();
        }

        private void btnActivate_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.Activate();
        }

        private void btnOnline_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.Help();
        }

        private void btnUpdates_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.Updates();
        }

        private void btnAbout_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.About();
        }

        private void btnUpdate_Click_1(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.UpdateButton();
        }

        private void cbbDisablePS_Click(object sender, RibbonControlEventArgs e)
        {
            if (cbbDisablePS.Checked)
            {
                Connect.worker.Suspend();
                Connect.NAR(Connect.worker);
                Connect.isProjServer = false;
                RegistryClass.SaveSetting("Tr", "DisableProjectServer", "True");
                btnPublish.Visible = true;
                btnResMapping.Visible = true;
            }
            else
            {
                ThreadStart ts = new ThreadStart(Connect.pubWindowClose);
                Connect.worker = new Thread(ts);
                Connect.worker.IsBackground = true;
                Connect.worker.Start();
                Connect.isProjServer = true;
                RegistryClass.SaveSetting("Tr", "DisableProjectServer", "False");
                btnPublish.Visible = false;
                btnResMapping.Visible = false;
            }
        }

        private void btnUpload_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ButtonPublishWork();
        }

        private void btnEnablePPM_Click(object sender, RibbonControlEventArgs e)
        {
            if (btnEnablePPM.Checked)
            {
                //mnuImportExport.Visible = true;
                group3.Visible = true;
                RegistryClass.SaveSetting("Tr", "EnablePPM", "True");
            }
            else
            {
                //mnuImportExport.Visible = false;
                group3.Visible = false;
                RegistryClass.SaveSetting("Tr", "EnablePPM", "False");
            }
        }

        private void btnEditCosts_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ButtonEditCosts("costs");
        }

        private void btnResPlan_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ButtonEditCosts("rpeditor");
        }

        private void btnImportCap_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ButtonUtilTeam("team");
        }

        private void btnImportCommitments_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ButtonUtilTeam("teamcomm");
        }

        private void btnImportNonWork_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ButtonUtilTeam("nonwork");
        }

        private void btnImportAll_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.c.ButtonUtilTeam("all");
        }
    }
}
