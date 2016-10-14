namespace ProjectPublisher2016
{
    partial class PublisherRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public PublisherRibbon() : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnPublish = this.Factory.CreateRibbonButton();
            this.btnUpdate = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.btnEditCosts = this.Factory.CreateRibbonButton();
            this.btnResPlan = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.menu1 = this.Factory.CreateRibbonMenu();
            this.btnRequestUpdates = this.Factory.CreateRibbonButton();
            this.btnEmailTeam = this.Factory.CreateRibbonButton();
            this.btnEmailTasks = this.Factory.CreateRibbonButton();
            this.menu2 = this.Factory.CreateRibbonMenu();
            this.btnSettings = this.Factory.CreateRibbonButton();
            this.btnResMapping = this.Factory.CreateRibbonButton();
            this.btnInformation = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.btnCustomFields = this.Factory.CreateRibbonButton();
            this.btnSynchronizeFields = this.Factory.CreateRibbonButton();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.btnDelete = this.Factory.CreateRibbonButton();
            this.btnWorkspace = this.Factory.CreateRibbonButton();
            this.mnuImportExport = this.Factory.CreateRibbonMenu();
            this.btnImportAll = this.Factory.CreateRibbonButton();
            this.separator5 = this.Factory.CreateRibbonSeparator();
            this.btnImportCap = this.Factory.CreateRibbonButton();
            this.btnImportCommitments = this.Factory.CreateRibbonButton();
            this.btnImportNonWork = this.Factory.CreateRibbonButton();
            this.separator4 = this.Factory.CreateRibbonSeparator();
            this.btnUpload = this.Factory.CreateRibbonButton();
            this.mnuHelp = this.Factory.CreateRibbonMenu();
            this.btnProxy = this.Factory.CreateRibbonButton();
            this.btnActivate = this.Factory.CreateRibbonButton();
            this.btnOnline = this.Factory.CreateRibbonButton();
            this.btnUpdates = this.Factory.CreateRibbonButton();
            this.btnEnablePPM = this.Factory.CreateRibbonToggleButton();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this.btnAbout = this.Factory.CreateRibbonButton();
            this.cbbDisablePS = this.Factory.CreateRibbonCheckBox();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group3.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Label = "Publisher";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnPublish);
            this.group1.Items.Add(this.btnUpdate);
            this.group1.Label = "Synch";
            this.group1.Name = "group1";
            // 
            // btnPublish
            // 
            this.btnPublish.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnPublish.Image = global::ProjectPublisher2016.Properties.Resources.synch;
            this.btnPublish.Label = "Publish";
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.ShowImage = true;
            this.btnPublish.Click += this.btnPublish_Click;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnUpdate.Image = global::ProjectPublisher2016.Properties.Resources.synch;
            this.btnUpdate.Label = "Update Progress";
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShowImage = true;
            this.btnUpdate.Click += this.btnUpdate_Click_1;
            // 
            // group3
            // 
            this.group3.Items.Add(this.btnEditCosts);
            this.group3.Items.Add(this.btnResPlan);
            this.group3.Label = "Manage";
            this.group3.Name = "group3";
            // 
            // btnEditCosts
            // 
            this.btnEditCosts.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnEditCosts.Label = "Cost Planner";
            this.btnEditCosts.Name = "btnEditCosts";
            this.btnEditCosts.OfficeImageId = "DataTypeCurrency";
            this.btnEditCosts.ShowImage = true;
            this.btnEditCosts.Click += this.btnEditCosts_Click;
            // 
            // btnResPlan
            // 
            this.btnResPlan.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnResPlan.Label = "Resource Planner";
            this.btnResPlan.Name = "btnResPlan";
            this.btnResPlan.OfficeImageId = "DatabasePermissionsMenu";
            this.btnResPlan.ShowImage = true;
            this.btnResPlan.Click += this.btnResPlan_Click;
            // 
            // group2
            // 
            this.group2.Items.Add(this.menu1);
            this.group2.Items.Add(this.menu2);
            this.group2.Items.Add(this.btnWorkspace);
            this.group2.Items.Add(this.mnuImportExport);
            this.group2.Items.Add(this.mnuHelp);
            this.group2.Items.Add(this.cbbDisablePS);
            this.group2.Label = "Options";
            this.group2.Name = "group2";
            // 
            // menu1
            // 
            this.menu1.Image = global::ProjectPublisher2016.Properties.Resources.email;
            this.menu1.Items.Add(this.btnRequestUpdates);
            this.menu1.Items.Add(this.btnEmailTeam);
            this.menu1.Items.Add(this.btnEmailTasks);
            this.menu1.Label = "Communicate";
            this.menu1.Name = "menu1";
            this.menu1.ShowImage = true;
            // 
            // btnRequestUpdates
            // 
            this.btnRequestUpdates.Label = "Request Updates";
            this.btnRequestUpdates.Name = "btnRequestUpdates";
            this.btnRequestUpdates.ShowImage = true;
            this.btnRequestUpdates.Click += this.btnRequestUpdates_Click;
            // 
            // btnEmailTeam
            // 
            this.btnEmailTeam.Label = "Email Team";
            this.btnEmailTeam.Name = "btnEmailTeam";
            this.btnEmailTeam.ShowImage = true;
            this.btnEmailTeam.Click += this.btnEmailTeam_Click;
            // 
            // btnEmailTasks
            // 
            this.btnEmailTasks.Label = "Email Selected Task(s) Resources";
            this.btnEmailTasks.Name = "btnEmailTasks";
            this.btnEmailTasks.ShowImage = true;
            this.btnEmailTasks.Click += this.btnEmailTasks_Click;
            // 
            // menu2
            // 
            this.menu2.Image = global::ProjectPublisher2016.Properties.Resources.settings;
            this.menu2.Items.Add(this.btnSettings);
            this.menu2.Items.Add(this.btnResMapping);
            this.menu2.Items.Add(this.btnInformation);
            this.menu2.Items.Add(this.separator1);
            this.menu2.Items.Add(this.btnCustomFields);
            this.menu2.Items.Add(this.btnSynchronizeFields);
            this.menu2.Items.Add(this.separator2);
            this.menu2.Items.Add(this.btnDelete);
            this.menu2.Label = "Project Options";
            this.menu2.Name = "menu2";
            this.menu2.ShowImage = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Label = "Settings";
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.ShowImage = true;
            this.btnSettings.Click += this.btnSettings_Click;
            // 
            // btnResMapping
            // 
            this.btnResMapping.Label = "Resource Mapping";
            this.btnResMapping.Name = "btnResMapping";
            this.btnResMapping.ShowImage = true;
            this.btnResMapping.Click += this.btnResMapping_Click;
            // 
            // btnInformation
            // 
            this.btnInformation.Label = "Project Information";
            this.btnInformation.Name = "btnInformation";
            this.btnInformation.ShowImage = true;
            this.btnInformation.Click += this.btnInformation_Click;
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // btnCustomFields
            // 
            this.btnCustomFields.Label = "Custom Fields";
            this.btnCustomFields.Name = "btnCustomFields";
            this.btnCustomFields.ShowImage = true;
            this.btnCustomFields.Click += this.btnCustomFields_Click;
            // 
            // btnSynchronizeFields
            // 
            this.btnSynchronizeFields.Label = "Synchronize Fields";
            this.btnSynchronizeFields.Name = "btnSynchronizeFields";
            this.btnSynchronizeFields.ShowImage = true;
            this.btnSynchronizeFields.Click += this.btnSynchronizeFields_Click;
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // btnDelete
            // 
            this.btnDelete.Label = "Delete Project";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShowImage = true;
            this.btnDelete.Click += this.btnDelete_Click;
            // 
            // btnWorkspace
            // 
            this.btnWorkspace.Image = global::ProjectPublisher2016.Properties.Resources.sharepoint;
            this.btnWorkspace.Label = "Go To Workspace";
            this.btnWorkspace.Name = "btnWorkspace";
            this.btnWorkspace.ShowImage = true;
            this.btnWorkspace.Click += this.btnWorkspace_Click;
            // 
            // mnuImportExport
            // 
            this.mnuImportExport.Items.Add(this.btnImportAll);
            this.mnuImportExport.Items.Add(this.separator5);
            this.mnuImportExport.Items.Add(this.btnImportCap);
            this.mnuImportExport.Items.Add(this.btnImportCommitments);
            this.mnuImportExport.Items.Add(this.btnImportNonWork);
            this.mnuImportExport.Items.Add(this.separator4);
            this.mnuImportExport.Items.Add(this.btnUpload);
            this.mnuImportExport.Label = "Import/Export";
            this.mnuImportExport.Name = "mnuImportExport";
            this.mnuImportExport.OfficeImageId = "DistributionListUpdateMembers";
            this.mnuImportExport.ShowImage = true;
            this.mnuImportExport.Visible = false;
            // 
            // btnImportAll
            // 
            this.btnImportAll.Label = "Import All";
            this.btnImportAll.Name = "btnImportAll";
            this.btnImportAll.ShowImage = true;
            this.btnImportAll.Click += this.btnImportAll_Click;
            // 
            // separator5
            // 
            this.separator5.Name = "separator5";
            // 
            // btnImportCap
            // 
            this.btnImportCap.Label = "Import Team";
            this.btnImportCap.Name = "btnImportCap";
            this.btnImportCap.ShowImage = true;
            this.btnImportCap.Click += this.btnImportCap_Click;
            // 
            // btnImportCommitments
            // 
            this.btnImportCommitments.Label = "Import Availability";
            this.btnImportCommitments.Name = "btnImportCommitments";
            this.btnImportCommitments.ShowImage = true;
            this.btnImportCommitments.Click += this.btnImportCommitments_Click;
            // 
            // btnImportNonWork
            // 
            this.btnImportNonWork.Label = "Import Non-Work";
            this.btnImportNonWork.Name = "btnImportNonWork";
            this.btnImportNonWork.ShowImage = true;
            this.btnImportNonWork.Click += this.btnImportNonWork_Click;
            // 
            // separator4
            // 
            this.separator4.Name = "separator4";
            // 
            // btnUpload
            // 
            this.btnUpload.Label = "Post Plan";
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.ShowImage = true;
            this.btnUpload.Click += this.btnUpload_Click;
            // 
            // mnuHelp
            // 
            this.mnuHelp.Image = global::ProjectPublisher2016.Properties.Resources.help;
            this.mnuHelp.Items.Add(this.btnProxy);
            this.mnuHelp.Items.Add(this.btnActivate);
            this.mnuHelp.Items.Add(this.btnOnline);
            this.mnuHelp.Items.Add(this.btnUpdates);
            this.mnuHelp.Items.Add(this.btnEnablePPM);
            this.mnuHelp.Items.Add(this.separator3);
            this.mnuHelp.Items.Add(this.btnAbout);
            this.mnuHelp.Label = "Help";
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.ShowImage = true;
            // 
            // btnProxy
            // 
            this.btnProxy.Label = "Proxy Settings";
            this.btnProxy.Name = "btnProxy";
            this.btnProxy.ShowImage = true;
            this.btnProxy.Click += this.btnProxy_Click;
            // 
            // btnActivate
            // 
            this.btnActivate.Label = "Activate";
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.ShowImage = true;
            this.btnActivate.Click += this.btnActivate_Click;
            // 
            // btnOnline
            // 
            this.btnOnline.Label = "Online Help Guide";
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.ShowImage = true;
            this.btnOnline.Click += this.btnOnline_Click;
            // 
            // btnUpdates
            // 
            this.btnUpdates.Label = "Check For Updates";
            this.btnUpdates.Name = "btnUpdates";
            this.btnUpdates.ShowImage = true;
            this.btnUpdates.Click += this.btnUpdates_Click;
            // 
            // btnEnablePPM
            // 
            this.btnEnablePPM.Label = "Enable PPM";
            this.btnEnablePPM.Name = "btnEnablePPM";
            this.btnEnablePPM.ShowImage = true;
            this.btnEnablePPM.Click += this.btnEnablePPM_Click;
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // btnAbout
            // 
            this.btnAbout.Label = "About";
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ShowImage = true;
            this.btnAbout.Click += this.btnAbout_Click;
            // 
            // cbbDisablePS
            // 
            this.cbbDisablePS.Label = "Disable Enterprise Publish";
            this.cbbDisablePS.Name = "cbbDisablePS";
            this.cbbDisablePS.Click += this.cbbDisablePS_Click;
            // 
            // PublisherRibbon
            // 
            this.Name = "PublisherRibbon";
            this.RibbonType = "Microsoft.Project.Project";
            this.Tabs.Add(this.tab1);
            this.Load += this.PublisherRibbon_Load;
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPublish;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUpdate;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRequestUpdates;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEmailTeam;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEmailTasks;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnResMapping;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInformation;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCustomFields;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSynchronizeFields;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDelete;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnWorkspace;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu mnuHelp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnProxy;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnActivate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOnline;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUpdates;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAbout;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox cbbDisablePS;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUpload;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEditCosts;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnResPlan;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportCap;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton btnEnablePPM;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu mnuImportExport;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportAll;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportCommitments;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportNonWork;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator4;
    }

    partial class ThisRibbonCollection : Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection
    {
        internal PublisherRibbon PublisherRibbon
        {
            get { return this.GetRibbon<PublisherRibbon>(); }
        }
    }
}
