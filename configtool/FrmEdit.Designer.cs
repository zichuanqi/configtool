namespace configtool
{
    partial class FrmEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdit));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.combCondition = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.office2007StartButton2 = new DevComponents.DotNetBar.Office2007StartButton();
            this.itemContainer5 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer6 = new DevComponents.DotNetBar.ItemContainer();
            this.itemContainer7 = new DevComponents.DotNetBar.ItemContainer();
            this.buttonItem15 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem16 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem17 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem18 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem19 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem20 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem14 = new DevComponents.DotNetBar.ButtonItem();
            this.galleryContainer2 = new DevComponents.DotNetBar.GalleryContainer();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtSQL = new System.Windows.Forms.RichTextBox();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "Changed";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "Greater than or equal to 1";
            // 
            // combCondition
            // 
            this.combCondition.DisplayMember = "Text";
            this.combCondition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combCondition.FormattingEnabled = true;
            this.combCondition.ItemHeight = 15;
            this.combCondition.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.combCondition.Location = new System.Drawing.Point(72, 18);
            this.combCondition.Name = "combCondition";
            this.combCondition.Size = new System.Drawing.Size(279, 21);
            this.combCondition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combCondition.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Location = new System.Drawing.Point(3, 20);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(68, 16);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Tag value:";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.Location = new System.Drawing.Point(22, 55);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(31, 16);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "SQL:";
            // 
            // office2007StartButton2
            // 
            this.office2007StartButton2.AutoExpandOnClick = true;
            this.office2007StartButton2.CanCustomize = false;
            this.office2007StartButton2.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.office2007StartButton2.ImagePaddingHorizontal = 2;
            this.office2007StartButton2.ImagePaddingVertical = 2;
            this.office2007StartButton2.Name = "office2007StartButton2";
            this.office2007StartButton2.ShowSubItems = false;
            this.office2007StartButton2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer5});
            this.office2007StartButton2.Text = "&File";
            // 
            // itemContainer5
            // 
            // 
            // 
            // 
            this.itemContainer5.BackgroundStyle.Class = "RibbonFileMenuContainer";
            this.itemContainer5.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer5.Name = "itemContainer5";
            this.itemContainer5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer6});
            // 
            // itemContainer6
            // 
            // 
            // 
            // 
            this.itemContainer6.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            this.itemContainer6.ItemSpacing = 0;
            this.itemContainer6.Name = "itemContainer6";
            this.itemContainer6.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer7});
            // 
            // itemContainer7
            // 
            // 
            // 
            // 
            this.itemContainer7.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer";
            this.itemContainer7.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer7.MinimumSize = new System.Drawing.Size(120, 0);
            this.itemContainer7.Name = "itemContainer7";
            this.itemContainer7.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem15,
            this.buttonItem16,
            this.buttonItem17,
            this.buttonItem18,
            this.buttonItem19,
            this.buttonItem20});
            // 
            // buttonItem15
            // 
            this.buttonItem15.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem15.Name = "buttonItem15";
            this.buttonItem15.SubItemsExpandWidth = 24;
            this.buttonItem15.Text = "&New";
            // 
            // buttonItem16
            // 
            this.buttonItem16.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem16.Name = "buttonItem16";
            this.buttonItem16.SubItemsExpandWidth = 24;
            this.buttonItem16.Text = "&Open...";
            // 
            // buttonItem17
            // 
            this.buttonItem17.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem17.Name = "buttonItem17";
            this.buttonItem17.SubItemsExpandWidth = 24;
            this.buttonItem17.Text = "&Save...";
            // 
            // buttonItem18
            // 
            this.buttonItem18.BeginGroup = true;
            this.buttonItem18.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem18.Name = "buttonItem18";
            this.buttonItem18.SubItemsExpandWidth = 24;
            this.buttonItem18.Text = "S&hare...";
            // 
            // buttonItem19
            // 
            this.buttonItem19.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem19.Name = "buttonItem19";
            this.buttonItem19.SubItemsExpandWidth = 24;
            this.buttonItem19.Text = "&Print...";
            // 
            // buttonItem20
            // 
            this.buttonItem20.BeginGroup = true;
            this.buttonItem20.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem20.Name = "buttonItem20";
            this.buttonItem20.SubItemsExpandWidth = 24;
            this.buttonItem20.Text = "&Close";
            // 
            // buttonItem14
            // 
            this.buttonItem14.Name = "buttonItem14";
            this.buttonItem14.Text = "buttonItem14";
            // 
            // galleryContainer2
            // 
            // 
            // 
            // 
            this.galleryContainer2.BackgroundStyle.Class = "RibbonFileMenuColumnTwoContainer";
            this.galleryContainer2.EnableGalleryPopup = false;
            this.galleryContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.galleryContainer2.MinimumSize = new System.Drawing.Size(180, 240);
            this.galleryContainer2.MultiLine = false;
            this.galleryContainer2.Name = "galleryContainer2";
            this.galleryContainer2.PopupUsesStandardScrollbars = false;
            // 
            // labelItem1
            // 
            this.labelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.labelItem1.BorderType = DevComponents.DotNetBar.eBorderType.Etched;
            this.labelItem1.CanCustomize = false;
            this.labelItem1.Name = "labelItem1";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtSQL);
            this.groupPanel1.Controls.Add(this.btnClose);
            this.groupPanel1.Controls.Add(this.btnSave);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.combCondition);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupPanel1.Size = new System.Drawing.Size(425, 328);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Condition";
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(72, 55);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(279, 186);
            this.txtSQL.TabIndex = 6;
            this.txtSQL.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(276, 259);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(72, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(425, 328);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.FrmEdit_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx combCondition;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Office2007StartButton office2007StartButton2;
        private DevComponents.DotNetBar.ItemContainer itemContainer5;
        private DevComponents.DotNetBar.ItemContainer itemContainer6;
        private DevComponents.DotNetBar.ItemContainer itemContainer7;
        private DevComponents.DotNetBar.ButtonItem buttonItem15;
        private DevComponents.DotNetBar.ButtonItem buttonItem16;
        private DevComponents.DotNetBar.ButtonItem buttonItem17;
        private DevComponents.DotNetBar.ButtonItem buttonItem18;
        private DevComponents.DotNetBar.ButtonItem buttonItem19;
        private DevComponents.DotNetBar.ButtonItem buttonItem20;
        private DevComponents.DotNetBar.ButtonItem buttonItem14;
        private DevComponents.DotNetBar.GalleryContainer galleryContainer2;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.RichTextBox txtSQL;
        private DevComponents.DotNetBar.ButtonX btnSave;

    }
}