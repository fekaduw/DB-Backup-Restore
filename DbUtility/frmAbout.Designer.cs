namespace DbUtility
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblVersion = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lblCopyright = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pictureEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(379, 237);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::DbUtility.Properties.Resources.SplashScreen_bg_02;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Size = new System.Drawing.Size(379, 180);
            this.pictureEdit1.StyleController = this.layoutControl1;
            this.pictureEdit1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblVersion,
            this.lblCopyright,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(379, 237);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AllowHotTrack = false;
            this.lblVersion.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.lblVersion.AppearanceItemCaption.BorderColor = System.Drawing.Color.White;
            this.lblVersion.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblVersion.AppearanceItemCaption.Options.UseBackColor = true;
            this.lblVersion.AppearanceItemCaption.Options.UseBorderColor = true;
            this.lblVersion.AppearanceItemCaption.Options.UseFont = true;
            this.lblVersion.CustomizationFormText = " ";
            this.lblVersion.Location = new System.Drawing.Point(0, 180);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 0, 0, 0);
            this.lblVersion.Size = new System.Drawing.Size(379, 22);
            this.lblVersion.Text = " ";
            this.lblVersion.TextSize = new System.Drawing.Size(0, 0);
            this.lblVersion.TextVisible = true;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AllowHotTrack = false;
            this.lblCopyright.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.lblCopyright.AppearanceItemCaption.BackColor2 = System.Drawing.Color.White;
            this.lblCopyright.AppearanceItemCaption.BorderColor = System.Drawing.Color.White;
            this.lblCopyright.AppearanceItemCaption.Options.UseBackColor = true;
            this.lblCopyright.AppearanceItemCaption.Options.UseBorderColor = true;
            this.lblCopyright.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lblCopyright.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCopyright.CustomizationFormText = " ";
            this.lblCopyright.Location = new System.Drawing.Point(0, 202);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 0, 0, 0);
            this.lblCopyright.Size = new System.Drawing.Size(379, 35);
            this.lblCopyright.Text = " ";
            this.lblCopyright.TextSize = new System.Drawing.Size(0, 0);
            this.lblCopyright.TextVisible = true;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pictureEdit1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(379, 180);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmAbout
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BorderColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 237);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Database Utility";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopyright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem lblVersion;
        private DevExpress.XtraLayout.EmptySpaceItem lblCopyright;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}