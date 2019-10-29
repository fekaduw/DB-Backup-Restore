namespace DbUtility
{
    partial class frmDbUtility
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDbUtility));
            this.layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnSync = new DevExpress.XtraEditors.SimpleButton();
            this.lkeServer = new DevExpress.XtraEditors.LookUpEdit();
            this.cboOption = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnBackupLocation = new DevExpress.XtraEditors.SimpleButton();
            this.txtBackupLocation = new DevExpress.XtraEditors.MemoEdit();
            this.btnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.prgBarDbUtility = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.txtDBBackupFile = new DevExpress.XtraEditors.MemoEdit();
            this.btnSelectBackupFile = new DevExpress.XtraEditors.SimpleButton();
            this.lkeDatabases = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.chkWindowsAuthentication = new DevExpress.XtraEditors.CheckEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layAuthenticationControl = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblCopyright = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layBackupDatabase = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.tmrDbUtility = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar = new DevExpress.XtraBars.Bar();
            this.barSetting = new DevExpress.XtraBars.BarSubItem();
            this.barSettingEmail = new DevExpress.XtraBars.BarButtonItem();
            this.barSettingBackup = new DevExpress.XtraBars.BarButtonItem();
            this.barSettingServer = new DevExpress.XtraBars.BarButtonItem();
            this.barSettingChangeSkin = new DevExpress.XtraBars.BarSubItem();
            this.barDevExpressStyle = new DevExpress.XtraBars.BarCheckItem();
            this.barOffice2010Blue = new DevExpress.XtraBars.BarCheckItem();
            this.barOffice2013 = new DevExpress.XtraBars.BarCheckItem();
            this.barVS2010 = new DevExpress.XtraBars.BarCheckItem();
            this.barHelp = new DevExpress.XtraBars.BarSubItem();
            this.barHelpViewHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barHelpAbout = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.txtDatabase = new DevExpress.XtraEditors.TextEdit();
            this.layRestoreDatabase = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackupLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarDbUtility.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBBackupFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDatabases.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWindowsAuthentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAuthenticationControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBackupDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layRestoreDatabase)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlMain
            // 
            this.layoutControlMain.Controls.Add(this.txtDatabase);
            this.layoutControlMain.Controls.Add(this.btnSync);
            this.layoutControlMain.Controls.Add(this.lkeServer);
            this.layoutControlMain.Controls.Add(this.cboOption);
            this.layoutControlMain.Controls.Add(this.btnBackupLocation);
            this.layoutControlMain.Controls.Add(this.txtBackupLocation);
            this.layoutControlMain.Controls.Add(this.btnBackup);
            this.layoutControlMain.Controls.Add(this.prgBarDbUtility);
            this.layoutControlMain.Controls.Add(this.btnRestore);
            this.layoutControlMain.Controls.Add(this.txtDBBackupFile);
            this.layoutControlMain.Controls.Add(this.btnSelectBackupFile);
            this.layoutControlMain.Controls.Add(this.lkeDatabases);
            this.layoutControlMain.Controls.Add(this.txtPassword);
            this.layoutControlMain.Controls.Add(this.chkWindowsAuthentication);
            this.layoutControlMain.Controls.Add(this.txtUserName);
            this.layoutControlMain.Controls.Add(this.pictureEdit2);
            this.layoutControlMain.Controls.Add(this.pictureEdit1);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.Location = new System.Drawing.Point(0, 29);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.Root = this.layoutControlGroup1;
            this.layoutControlMain.Size = new System.Drawing.Size(457, 388);
            this.layoutControlMain.TabIndex = 0;
            this.layoutControlMain.Text = "layoutControl1";
            // 
            // btnSync
            // 
            this.btnSync.Image = ((System.Drawing.Image)(resources.GetObject("btnSync.Image")));
            this.btnSync.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSync.Location = new System.Drawing.Point(408, 112);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(35, 22);
            this.btnSync.StyleController = this.layoutControlMain;
            this.btnSync.TabIndex = 29;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // lkeServer
            // 
            this.lkeServer.Location = new System.Drawing.Point(69, 112);
            this.lkeServer.Name = "lkeServer";
            this.lkeServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeServer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Select Server")});
            this.lkeServer.Properties.DisplayMember = "Name";
            this.lkeServer.Properties.NullText = "";
            this.lkeServer.Properties.ValueMember = "Name";
            this.lkeServer.Size = new System.Drawing.Size(335, 20);
            this.lkeServer.StyleController = this.layoutControlMain;
            this.lkeServer.TabIndex = 28;
            this.lkeServer.EditValueChanged += new System.EventHandler(this.lkeServer_EditValueChanged);
            // 
            // cboOption
            // 
            this.cboOption.EditValue = "Backup";
            this.cboOption.Location = new System.Drawing.Point(18, 204);
            this.cboOption.Name = "cboOption";
            this.cboOption.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOption.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboOption.Size = new System.Drawing.Size(119, 20);
            this.cboOption.StyleController = this.layoutControlMain;
            this.cboOption.TabIndex = 4;
            this.cboOption.SelectedIndexChanged += new System.EventHandler(this.cboOption_SelectedIndexChanged);
            // 
            // btnBackupLocation
            // 
            this.btnBackupLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnBackupLocation.Image")));
            this.btnBackupLocation.Location = new System.Drawing.Point(18, 270);
            this.btnBackupLocation.Name = "btnBackupLocation";
            this.btnBackupLocation.Size = new System.Drawing.Size(119, 22);
            this.btnBackupLocation.StyleController = this.layoutControlMain;
            this.btnBackupLocation.TabIndex = 7;
            this.btnBackupLocation.Text = "&Backup Location";
            this.btnBackupLocation.Click += new System.EventHandler(this.btnBackupLocation_Click);
            // 
            // txtBackupLocation
            // 
            this.txtBackupLocation.Location = new System.Drawing.Point(141, 270);
            this.txtBackupLocation.Name = "txtBackupLocation";
            this.txtBackupLocation.Properties.ReadOnly = true;
            this.txtBackupLocation.Size = new System.Drawing.Size(300, 22);
            this.txtBackupLocation.StyleController = this.layoutControlMain;
            this.txtBackupLocation.TabIndex = 26;
            // 
            // btnBackup
            // 
            this.btnBackup.Image = global::DbUtility.Properties.Resources.database_down;
            this.btnBackup.Location = new System.Drawing.Point(219, 334);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(106, 38);
            this.btnBackup.StyleController = this.layoutControlMain;
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "&Backup";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // prgBarDbUtility
            // 
            this.prgBarDbUtility.Location = new System.Drawing.Point(12, 312);
            this.prgBarDbUtility.Name = "prgBarDbUtility";
            this.prgBarDbUtility.Properties.ShowTitle = true;
            this.prgBarDbUtility.Size = new System.Drawing.Size(433, 18);
            this.prgBarDbUtility.StyleController = this.layoutControlMain;
            this.prgBarDbUtility.TabIndex = 17;
            // 
            // btnRestore
            // 
            this.btnRestore.Image = global::DbUtility.Properties.Resources.database_up;
            this.btnRestore.Location = new System.Drawing.Point(339, 334);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(106, 38);
            this.btnRestore.StyleController = this.layoutControlMain;
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Text = "&Restore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // txtDBBackupFile
            // 
            this.txtDBBackupFile.Location = new System.Drawing.Point(141, 228);
            this.txtDBBackupFile.Name = "txtDBBackupFile";
            this.txtDBBackupFile.Properties.AllowFocused = false;
            this.txtDBBackupFile.Properties.ReadOnly = true;
            this.txtDBBackupFile.Size = new System.Drawing.Size(300, 38);
            this.txtDBBackupFile.StyleController = this.layoutControlMain;
            this.txtDBBackupFile.TabIndex = 14;
            // 
            // btnSelectBackupFile
            // 
            this.btnSelectBackupFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectBackupFile.Image")));
            this.btnSelectBackupFile.Location = new System.Drawing.Point(18, 228);
            this.btnSelectBackupFile.Name = "btnSelectBackupFile";
            this.btnSelectBackupFile.Size = new System.Drawing.Size(119, 38);
            this.btnSelectBackupFile.StyleController = this.layoutControlMain;
            this.btnSelectBackupFile.TabIndex = 6;
            this.btnSelectBackupFile.Text = "&Backup File";
            this.btnSelectBackupFile.Click += new System.EventHandler(this.btnSelectDBFile_Click);
            // 
            // lkeDatabases
            // 
            this.lkeDatabases.Location = new System.Drawing.Point(196, 204);
            this.lkeDatabases.Name = "lkeDatabases";
            this.lkeDatabases.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDatabases.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Database", "Select a database")});
            this.lkeDatabases.Properties.DisplayMember = "Database";
            this.lkeDatabases.Properties.NullText = "";
            this.lkeDatabases.Properties.ValueMember = "Database";
            this.lkeDatabases.Size = new System.Drawing.Size(89, 20);
            this.lkeDatabases.StyleController = this.layoutControlMain;
            this.lkeDatabases.TabIndex = 5;
            this.lkeDatabases.EditValueChanged += new System.EventHandler(this.lkeDatabases_EditValueChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(69, 162);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(374, 20);
            this.txtPassword.StyleController = this.layoutControlMain;
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Tag = "authentication";
            // 
            // chkWindowsAuthentication
            // 
            this.chkWindowsAuthentication.Location = new System.Drawing.Point(14, 89);
            this.chkWindowsAuthentication.Name = "chkWindowsAuthentication";
            this.chkWindowsAuthentication.Properties.Caption = "Use Windows Authentication";
            this.chkWindowsAuthentication.Size = new System.Drawing.Size(429, 19);
            this.chkWindowsAuthentication.StyleController = this.layoutControlMain;
            this.chkWindowsAuthentication.TabIndex = 0;
            this.chkWindowsAuthentication.CheckedChanged += new System.EventHandler(this.chkWindowsAuthentication_CheckedChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(69, 138);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(374, 20);
            this.txtUserName.StyleController = this.layoutControlMain;
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Tag = "authentication";
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = global::DbUtility.Properties.Resources.JSI;
            this.pictureEdit2.Location = new System.Drawing.Point(394, 0);
            this.pictureEdit2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.AllowFocused = false;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit2.Size = new System.Drawing.Size(63, 57);
            this.pictureEdit2.StyleController = this.layoutControlMain;
            this.pictureEdit2.TabIndex = 15;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::DbUtility.Properties.Resources.USAID;
            this.pictureEdit1.Location = new System.Drawing.Point(231, 0);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit1.Size = new System.Drawing.Size(163, 57);
            this.pictureEdit1.StyleController = this.layoutControlMain;
            this.pictureEdit1.TabIndex = 14;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layAuthenticationControl,
            this.lblCopyright,
            this.layoutControlItem9,
            this.emptySpaceItem5,
            this.layoutControlGroup2,
            this.layoutControlItem7,
            this.layoutControlItem10,
            this.emptySpaceItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 10);
            this.layoutControlGroup1.Size = new System.Drawing.Size(457, 388);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.emptySpaceItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.emptySpaceItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.DimGray;
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseBackColor = true;
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseFont = true;
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.emptySpaceItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.emptySpaceItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.emptySpaceItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 57);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 57);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Size = new System.Drawing.Size(231, 57);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "Database Utility";
            this.emptySpaceItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(51, 20);
            this.emptySpaceItem1.TextVisible = true;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnRestore;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(337, 332);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(120, 42);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(120, 42);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 12, 2, 2);
            this.layoutControlItem6.Size = new System.Drawing.Size(120, 46);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnBackup;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(217, 332);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(120, 42);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(120, 42);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 12, 2, 2);
            this.layoutControlItem5.Size = new System.Drawing.Size(120, 46);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layAuthenticationControl
            // 
            this.layAuthenticationControl.CustomizationFormText = "Connect to Server";
            this.layAuthenticationControl.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem13,
            this.layoutControlItem3,
            this.layoutControlItem11});
            this.layAuthenticationControl.Location = new System.Drawing.Point(0, 57);
            this.layAuthenticationControl.Name = "layAuthenticationControl";
            this.layAuthenticationControl.Size = new System.Drawing.Size(457, 139);
            this.layAuthenticationControl.Text = "Connect to Server";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkWindowsAuthentication;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(433, 23);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtUserName;
            this.layoutControlItem4.CustomizationFormText = "User Name";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 49);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(433, 24);
            this.layoutControlItem4.Text = "User Name";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtPassword;
            this.layoutControlItem13.CustomizationFormText = "Password";
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 73);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(433, 24);
            this.layoutControlItem13.Text = "Password";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lkeServer;
            this.layoutControlItem3.CustomizationFormText = "Server";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(394, 26);
            this.layoutControlItem3.Text = "Server";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnSync;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
            this.layoutControlItem11.Location = new System.Drawing.Point(394, 23);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(39, 26);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AllowHotTrack = false;
            this.lblCopyright.CustomizationFormText = "emptySpaceItem2";
            this.lblCopyright.Location = new System.Drawing.Point(0, 332);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Padding = new DevExpress.XtraLayout.Utils.Padding(15, 2, 2, 2);
            this.lblCopyright.Size = new System.Drawing.Size(217, 46);
            this.lblCopyright.Text = " ";
            this.lblCopyright.TextSize = new System.Drawing.Size(52, 0);
            this.lblCopyright.TextVisible = true;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.prgBarDbUtility;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 310);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 12, 2, 2);
            this.layoutControlItem9.Size = new System.Drawing.Size(457, 22);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 300);
            this.emptySpaceItem5.MaxSize = new System.Drawing.Size(0, 10);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(457, 10);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem16,
            this.layBackupDatabase,
            this.layoutControlItem15,
            this.layoutControlItem8,
            this.layoutControlItem1,
            this.layoutControlItem12,
            this.layRestoreDatabase});
            this.layoutControlGroup2.Location = new System.Drawing.Point(10, 196);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup2.Size = new System.Drawing.Size(447, 104);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.cboOption;
            this.layoutControlItem16.CustomizationFormText = "layoutControlItem16";
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(123, 24);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layBackupDatabase
            // 
            this.layBackupDatabase.Control = this.lkeDatabases;
            this.layBackupDatabase.CustomizationFormText = "Database";
            this.layBackupDatabase.Location = new System.Drawing.Point(123, 0);
            this.layBackupDatabase.Name = "layBackupDatabase";
            this.layBackupDatabase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2);
            this.layBackupDatabase.Size = new System.Drawing.Size(156, 24);
            this.layBackupDatabase.Text = "Database";
            this.layBackupDatabase.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.btnBackupLocation;
            this.layoutControlItem15.CustomizationFormText = "Select";
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 66);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(123, 26);
            this.layoutControlItem15.Text = "Select";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnSelectBackupFile;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(123, 42);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDBBackupFile;
            this.layoutControlItem1.CustomizationFormText = "Backup File";
            this.layoutControlItem1.Location = new System.Drawing.Point(123, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(312, 42);
            this.layoutControlItem1.Text = "Backup File";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtBackupLocation;
            this.layoutControlItem12.CustomizationFormText = "Backup Location";
            this.layoutControlItem12.Location = new System.Drawing.Point(123, 66);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2);
            this.layoutControlItem12.Size = new System.Drawing.Size(312, 26);
            this.layoutControlItem12.Text = "Backup Location";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.layoutControlItem7.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem7.Control = this.pictureEdit2;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(394, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem7.Size = new System.Drawing.Size(63, 57);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.layoutControlItem10.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem10.Control = this.pictureEdit1;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(231, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem10.Size = new System.Drawing.Size(163, 57);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem8";
            this.emptySpaceItem8.Location = new System.Drawing.Point(0, 196);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(10, 104);
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // tmrDbUtility
            // 
            this.tmrDbUtility.Interval = 500;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar,
            this.bar3});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imageCollection;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barHelp,
            this.barHelpAbout,
            this.barHelpViewHelp,
            this.barSetting,
            this.barSettingEmail,
            this.barSettingChangeSkin,
            this.barOffice2010Blue,
            this.barOffice2013,
            this.barVS2010,
            this.barDevExpressStyle,
            this.barSettingBackup,
            this.barSettingServer,
            this.barStatus});
            this.barManager.MaxItemId = 30;
            this.barManager.StatusBar = this.bar3;
            // 
            // bar
            // 
            this.bar.BarName = "Tools";
            this.bar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSetting),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barHelp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar.OptionsBar.AllowQuickCustomization = false;
            this.bar.OptionsBar.MultiLine = true;
            this.bar.OptionsBar.UseWholeRow = true;
            this.bar.Text = "Tools";
            // 
            // barSetting
            // 
            this.barSetting.Caption = "&Setting";
            this.barSetting.Id = 14;
            this.barSetting.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.barSettingEmail, "&Email Setting"),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSettingBackup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSettingServer, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSettingChangeSkin, true)});
            this.barSetting.Name = "barSetting";
            // 
            // barSettingEmail
            // 
            this.barSettingEmail.Caption = "&Manage Setting";
            this.barSettingEmail.Id = 15;
            this.barSettingEmail.ImageIndex = 6;
            this.barSettingEmail.Name = "barSettingEmail";
            this.barSettingEmail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSettingEmail_ItemClick);
            // 
            // barSettingBackup
            // 
            this.barSettingBackup.Caption = "&Backup Setting";
            this.barSettingBackup.Id = 27;
            this.barSettingBackup.ImageIndex = 5;
            this.barSettingBackup.Name = "barSettingBackup";
            this.barSettingBackup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSettingBackup_ItemClick);
            // 
            // barSettingServer
            // 
            this.barSettingServer.Caption = "Server Setting";
            this.barSettingServer.Id = 28;
            this.barSettingServer.ImageIndex = 7;
            this.barSettingServer.Name = "barSettingServer";
            this.barSettingServer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSettingServer_ItemClick);
            // 
            // barSettingChangeSkin
            // 
            this.barSettingChangeSkin.Caption = "&Change Skin";
            this.barSettingChangeSkin.Id = 16;
            this.barSettingChangeSkin.ImageIndex = 4;
            this.barSettingChangeSkin.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barDevExpressStyle),
            new DevExpress.XtraBars.LinkPersistInfo(this.barOffice2010Blue),
            new DevExpress.XtraBars.LinkPersistInfo(this.barOffice2013),
            new DevExpress.XtraBars.LinkPersistInfo(this.barVS2010)});
            this.barSettingChangeSkin.Name = "barSettingChangeSkin";
            // 
            // barDevExpressStyle
            // 
            this.barDevExpressStyle.Caption = "DevExpress Style";
            this.barDevExpressStyle.GroupIndex = 1;
            this.barDevExpressStyle.Id = 25;
            this.barDevExpressStyle.Name = "barDevExpressStyle";
            this.barDevExpressStyle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSkin_ItemClick);
            // 
            // barOffice2010Blue
            // 
            this.barOffice2010Blue.Caption = "Office 2010 Blue";
            this.barOffice2010Blue.GroupIndex = 1;
            this.barOffice2010Blue.Id = 21;
            this.barOffice2010Blue.Name = "barOffice2010Blue";
            this.barOffice2010Blue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSkin_ItemClick);
            // 
            // barOffice2013
            // 
            this.barOffice2013.Caption = "Office 2013";
            this.barOffice2013.GroupIndex = 1;
            this.barOffice2013.Id = 22;
            this.barOffice2013.Name = "barOffice2013";
            this.barOffice2013.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSkin_ItemClick);
            // 
            // barVS2010
            // 
            this.barVS2010.Caption = "VS2010";
            this.barVS2010.GroupIndex = 1;
            this.barVS2010.Id = 24;
            this.barVS2010.Name = "barVS2010";
            this.barVS2010.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSkin_ItemClick);
            // 
            // barHelp
            // 
            this.barHelp.Caption = "&Help";
            this.barHelp.Id = 4;
            this.barHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barHelpViewHelp),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barHelpAbout, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barHelp.Name = "barHelp";
            // 
            // barHelpViewHelp
            // 
            this.barHelpViewHelp.Caption = "&View Help";
            this.barHelpViewHelp.Id = 13;
            this.barHelpViewHelp.ImageIndex = 2;
            this.barHelpViewHelp.Name = "barHelpViewHelp";
            // 
            // barHelpAbout
            // 
            this.barHelpAbout.Caption = "&About";
            this.barHelpAbout.Id = 12;
            this.barHelpAbout.ImageIndex = 3;
            this.barHelpAbout.Name = "barHelpAbout";
            this.barHelpAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barHelpAbout_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStatus)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStatus
            // 
            this.barStatus.Id = 29;
            this.barStatus.Name = "barStatus";
            this.barStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(457, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 417);
            this.barDockControlBottom.Size = new System.Drawing.Size(457, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 388);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(457, 29);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 388);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "service.jpg");
            this.imageCollection.InsertGalleryImage("properties_16x16.png", "images/setup/properties_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/setup/properties_16x16.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "properties_16x16.png");
            this.imageCollection.InsertGalleryImage("index_16x16.png", "images/support/index_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/index_16x16.png"), 2);
            this.imageCollection.Images.SetKeyName(2, "index_16x16.png");
            this.imageCollection.InsertGalleryImage("info_16x16.png", "images/support/info_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/info_16x16.png"), 3);
            this.imageCollection.Images.SetKeyName(3, "info_16x16.png");
            this.imageCollection.InsertGalleryImage("palette_32x32.png", "images/miscellaneous/palette_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/miscellaneous/palette_32x32.png"), 4);
            this.imageCollection.Images.SetKeyName(4, "palette_32x32.png");
            this.imageCollection.InsertGalleryImage("managedatasource_16x16.png", "images/data/managedatasource_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/managedatasource_16x16.png"), 5);
            this.imageCollection.Images.SetKeyName(5, "managedatasource_16x16.png");
            this.imageCollection.InsertGalleryImage("mail_16x16.png", "images/mail/mail_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/mail/mail_16x16.png"), 6);
            this.imageCollection.Images.SetKeyName(6, "mail_16x16.png");
            this.imageCollection.InsertGalleryImage("servermode_16x16.png", "images/data/servermode_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/servermode_16x16.png"), 7);
            this.imageCollection.Images.SetKeyName(7, "servermode_16x16.png");
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(352, 204);
            this.txtDatabase.MenuManager = this.barManager;
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(97, 20);
            this.txtDatabase.StyleController = this.layoutControlMain;
            this.txtDatabase.TabIndex = 30;
            // 
            // layRestoreDatabase
            // 
            this.layRestoreDatabase.Control = this.txtDatabase;
            this.layRestoreDatabase.Location = new System.Drawing.Point(279, 0);
            this.layRestoreDatabase.Name = "layRestoreDatabase";
            this.layRestoreDatabase.Size = new System.Drawing.Size(156, 24);
            this.layRestoreDatabase.Text = "Database";
            this.layRestoreDatabase.TextSize = new System.Drawing.Size(52, 13);
            this.layRestoreDatabase.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // frmDbUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 442);
            this.Controls.Add(this.layoutControlMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDbUtility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Utility";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDbUtility_FormClosing);
            this.Load += new System.EventHandler(this.frmDbUtility_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackupLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgBarDbUtility.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBBackupFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDatabases.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWindowsAuthentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layAuthenticationControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBackupDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layRestoreDatabase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private System.Windows.Forms.Timer tmrDbUtility;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private DevExpress.XtraEditors.SimpleButton btnBackup;
        private DevExpress.XtraEditors.ProgressBarControl prgBarDbUtility;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.MemoEdit txtDBBackupFile;
        private DevExpress.XtraEditors.SimpleButton btnSelectBackupFile;
        private DevExpress.XtraEditors.LookUpEdit lkeDatabases;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.CheckEdit chkWindowsAuthentication;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraLayout.LayoutControlItem layBackupDatabase;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layAuthenticationControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraEditors.SimpleButton btnBackupLocation;
        private DevExpress.XtraEditors.MemoEdit txtBackupLocation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.EmptySpaceItem lblCopyright;
        private DevExpress.XtraEditors.ComboBoxEdit cboOption;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraEditors.LookUpEdit lkeServer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnSync;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarSubItem barHelp;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraBars.BarButtonItem barHelpAbout;
        private DevExpress.XtraBars.BarButtonItem barHelpViewHelp;
        private DevExpress.XtraBars.BarSubItem barSetting;
        private DevExpress.XtraBars.BarButtonItem barSettingEmail;
        private DevExpress.XtraBars.BarSubItem barSettingChangeSkin;
        private DevExpress.XtraBars.BarCheckItem barOffice2010Blue;
        private DevExpress.XtraBars.BarCheckItem barOffice2013;
        private DevExpress.XtraBars.BarCheckItem barVS2010;
        private DevExpress.XtraBars.BarCheckItem barDevExpressStyle;
        private DevExpress.XtraBars.BarButtonItem barSettingBackup;
        private DevExpress.XtraBars.BarButtonItem barSettingServer;
        private DevExpress.XtraBars.BarStaticItem barStatus;
        private DevExpress.XtraEditors.TextEdit txtDatabase;
        private DevExpress.XtraLayout.LayoutControlItem layRestoreDatabase;
    }
}