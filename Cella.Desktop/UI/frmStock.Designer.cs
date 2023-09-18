namespace Cella.Desktop.UI
{
    partial class frmStock
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
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtStockCode = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            autoLabel8 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            textBoxExt7 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel7 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            textBoxExt6 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            textBoxExt5 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            textBoxExt4 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            tabPage2 = new TabPage();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            cboItemType = new Syncfusion.Windows.Forms.Tools.ComboDropDown();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            dtStartDate = new DateTimePicker();
            autoLabel9 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel10 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            dtEndDate = new DateTimePicker();
            sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            autoLabel11 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            textBoxExt1 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel12 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            comboDropDown1 = new Syncfusion.Windows.Forms.Tools.ComboDropDown();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStockCode).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBoxExt7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt4).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboItemType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboDropDown1).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(200, 27);
            txtName.Location = new Point(5, 93);
            txtName.Name = "txtName";
            txtName.Size = new Size(461, 27);
            txtName.TabIndex = 0;
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(5, 63);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(52, 20);
            autoLabel1.TabIndex = 1;
            autoLabel1.Text = "Name:";
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(5, 3);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(87, 20);
            autoLabel2.TabIndex = 3;
            autoLabel2.Text = "Stock Code:";
            // 
            // txtStockCode
            // 
            txtStockCode.BeforeTouchSize = new Size(200, 27);
            txtStockCode.Location = new Point(5, 31);
            txtStockCode.Name = "txtStockCode";
            txtStockCode.Size = new Size(200, 27);
            txtStockCode.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(516, 33);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(85, 24);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Enabled";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(516, 63);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(114, 24);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Show Online";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(657, 33);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(194, 24);
            checkBox3.TabIndex = 8;
            checkBox3.Text = "Is Avaialbe to buy online";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(657, 62);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(144, 24);
            checkBox4.TabIndex = 9;
            checkBox4.Text = "Show Call Button";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(6, 403);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(796, 249);
            tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(autoLabel12);
            tabPage1.Controls.Add(comboDropDown1);
            tabPage1.Controls.Add(autoLabel11);
            tabPage1.Controls.Add(textBoxExt1);
            tabPage1.Controls.Add(autoLabel8);
            tabPage1.Controls.Add(textBoxExt7);
            tabPage1.Controls.Add(autoLabel7);
            tabPage1.Controls.Add(textBoxExt6);
            tabPage1.Controls.Add(autoLabel6);
            tabPage1.Controls.Add(textBoxExt5);
            tabPage1.Controls.Add(autoLabel4);
            tabPage1.Controls.Add(textBoxExt4);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(788, 216);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // autoLabel8
            // 
            autoLabel8.Location = new Point(582, 33);
            autoLabel8.Name = "autoLabel8";
            autoLabel8.Size = new Size(38, 20);
            autoLabel8.TabIndex = 11;
            autoLabel8.Text = "Row";
            // 
            // textBoxExt7
            // 
            textBoxExt7.BeforeTouchSize = new Size(179, 27);
            textBoxExt7.Location = new Point(582, 61);
            textBoxExt7.Name = "textBoxExt7";
            textBoxExt7.Size = new Size(179, 27);
            textBoxExt7.TabIndex = 10;
            // 
            // autoLabel7
            // 
            autoLabel7.Location = new Point(3, 119);
            autoLabel7.Name = "autoLabel7";
            autoLabel7.Size = new Size(95, 20);
            autoLabel7.TabIndex = 9;
            autoLabel7.Text = "Part Number:";
            // 
            // textBoxExt6
            // 
            textBoxExt6.BeforeTouchSize = new Size(200, 27);
            textBoxExt6.Location = new Point(3, 147);
            textBoxExt6.Name = "textBoxExt6";
            textBoxExt6.Size = new Size(179, 27);
            textBoxExt6.TabIndex = 8;
            // 
            // autoLabel6
            // 
            autoLabel6.Location = new Point(6, 61);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(77, 20);
            autoLabel6.TabIndex = 7;
            autoLabel6.Text = "UPC / SKU";
            // 
            // textBoxExt5
            // 
            textBoxExt5.BeforeTouchSize = new Size(200, 27);
            textBoxExt5.Location = new Point(6, 89);
            textBoxExt5.Name = "textBoxExt5";
            textBoxExt5.Size = new Size(179, 27);
            textBoxExt5.TabIndex = 6;
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(6, 3);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(79, 20);
            autoLabel4.TabIndex = 5;
            autoLabel4.Text = "Price Level";
            // 
            // textBoxExt4
            // 
            textBoxExt4.BeforeTouchSize = new Size(200, 27);
            textBoxExt4.Location = new Point(6, 31);
            textBoxExt4.Name = "textBoxExt4";
            textBoxExt4.Size = new Size(179, 27);
            textBoxExt4.TabIndex = 4;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(sfDataGrid1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(788, 216);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Bill of Materials";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(4, 123);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(88, 20);
            autoLabel3.TabIndex = 12;
            autoLabel3.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.BeforeTouchSize = new Size(200, 27);
            txtDescription.Location = new Point(4, 153);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(746, 117);
            txtDescription.TabIndex = 11;
            // 
            // cboItemType
            // 
            cboItemType.BeforeTouchSize = new Size(235, 28);
            cboItemType.Location = new Point(5, 369);
            cboItemType.Name = "cboItemType";
            cboItemType.Size = new Size(235, 28);
            cboItemType.TabIndex = 13;
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new Point(6, 346);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(74, 20);
            autoLabel5.TabIndex = 14;
            autoLabel5.Text = "Item Type";
            // 
            // dtStartDate
            // 
            dtStartDate.Location = new Point(4, 316);
            dtStartDate.Name = "dtStartDate";
            dtStartDate.Size = new Size(250, 27);
            dtStartDate.TabIndex = 15;
            // 
            // autoLabel9
            // 
            autoLabel9.Location = new Point(5, 283);
            autoLabel9.Name = "autoLabel9";
            autoLabel9.Size = new Size(76, 20);
            autoLabel9.TabIndex = 16;
            autoLabel9.Text = "Start Date";
            // 
            // autoLabel10
            // 
            autoLabel10.Location = new Point(297, 283);
            autoLabel10.Name = "autoLabel10";
            autoLabel10.Size = new Size(66, 20);
            autoLabel10.TabIndex = 18;
            autoLabel10.Text = "EndDate";
            // 
            // dtEndDate
            // 
            dtEndDate.Location = new Point(296, 316);
            dtEndDate.Name = "dtEndDate";
            dtEndDate.Size = new Size(250, 27);
            dtEndDate.TabIndex = 17;
            // 
            // sfDataGrid1
            // 
            sfDataGrid1.AccessibleName = "Table";
            sfDataGrid1.Location = new Point(17, 21);
            sfDataGrid1.Name = "sfDataGrid1";
            sfDataGrid1.PreviewRowHeight = 35;
            sfDataGrid1.Size = new Size(750, 188);
            sfDataGrid1.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.TabIndex = 0;
            sfDataGrid1.Text = "grdBomList";
            // 
            // autoLabel11
            // 
            autoLabel11.BackColor = Color.FromArgb(255, 255, 255);
            autoLabel11.ForeColor = Color.FromArgb(68, 68, 68);
            autoLabel11.Location = new Point(301, 61);
            autoLabel11.Name = "autoLabel11";
            autoLabel11.Size = new Size(59, 20);
            autoLabel11.Style = Syncfusion.Windows.Forms.Tools.AutoLabelStyle.Office2016Colorful;
            autoLabel11.TabIndex = 13;
            autoLabel11.Text = "Weight:";
            autoLabel11.ThemeName = "Office2016Colorful";
            // 
            // textBoxExt1
            // 
            textBoxExt1.BeforeTouchSize = new Size(179, 27);
            textBoxExt1.Location = new Point(301, 89);
            textBoxExt1.Name = "textBoxExt1";
            textBoxExt1.Size = new Size(179, 27);
            textBoxExt1.TabIndex = 12;
            // 
            // autoLabel12
            // 
            autoLabel12.Location = new Point(301, 2);
            autoLabel12.Name = "autoLabel12";
            autoLabel12.Size = new Size(78, 20);
            autoLabel12.TabIndex = 16;
            autoLabel12.Text = "UOM Type";
            // 
            // comboDropDown1
            // 
            comboDropDown1.BeforeTouchSize = new Size(235, 28);
            comboDropDown1.Location = new Point(301, 25);
            comboDropDown1.Name = "comboDropDown1";
            comboDropDown1.Size = new Size(235, 28);
            comboDropDown1.TabIndex = 15;
            // 
            // frmStock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 693);
            Controls.Add(autoLabel10);
            Controls.Add(dtEndDate);
            Controls.Add(autoLabel9);
            Controls.Add(dtStartDate);
            Controls.Add(autoLabel5);
            Controls.Add(cboItemType);
            Controls.Add(autoLabel3);
            Controls.Add(txtDescription);
            Controls.Add(tabControl1);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(autoLabel2);
            Controls.Add(txtStockCode);
            Controls.Add(autoLabel1);
            Controls.Add(txtName);
            Name = "frmStock";
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Cella Stock Managment";
            Load += frmStock_Load;
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStockCode).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBoxExt7).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt6).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt5).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt4).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboItemType).EndInit();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt1).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboDropDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtStockCode;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel7;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt6;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.Windows.Forms.Tools.ComboDropDown cboItemType;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel8;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt7;
        private DateTimePicker dtStartDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel9;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel10;
        private DateTimePicker dtEndDate;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel11;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel12;
        private Syncfusion.Windows.Forms.Tools.ComboDropDown comboDropDown1;
    }
}