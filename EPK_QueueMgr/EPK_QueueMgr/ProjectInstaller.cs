using System;
using System.Collections.Generic;
using System.Text;
//using System.Configuration.Text;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;


namespace WE_QueueMgr
{
    [RunInstaller(true)]
    public class ProjectInstaller : System.Configuration.Install.Installer
    {  
        //private System.ComponentModel.Container components;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;

        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.Description = "PortfolioEngine Queue Service runs queued server requests asynchronously";
            this.serviceInstaller1.DisplayName = "PortfolioEngine Queue Service";
            this.serviceInstaller1.ServiceName = "PortfolioEngineQueueService";
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.serviceInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Password = "Pass@word1";
            this.serviceProcessInstaller1.Username = "CONTOSO\\WSS";
            this.serviceProcessInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller1_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.serviceInstaller1});

        }

        private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}


