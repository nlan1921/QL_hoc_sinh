namespace ProjectQuanLySinhVien
{
    partial class rp_GT
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.diem1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._19CT112_04_05DataSet = new ProjectQuanLySinhVien._19CT112_04_05DataSet();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.diem1TableAdapter = new ProjectQuanLySinhVien._19CT112_04_05DataSetTableAdapters.Diem1TableAdapter();
            this.diem1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.diem1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._19CT112_04_05DataSet)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diem1BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // diem1BindingSource
            // 
            this.diem1BindingSource.DataMember = "Diem1";
            this.diem1BindingSource.DataSource = this._19CT112_04_05DataSet;
            // 
            // _19CT112_04_05DataSet
            // 
            this._19CT112_04_05DataSet.DataSetName = "_19CT112_04_05DataSet";
            this._19CT112_04_05DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportViewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1196, 536);
            this.panel2.TabIndex = 4;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.diem1BindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProjectQuanLySinhVien.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(8, 18);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1171, 476);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(157)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 81);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1196, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "SINH VIÊN DIEM1 > 5";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // diem1TableAdapter
            // 
            this.diem1TableAdapter.ClearBeforeFill = true;
            // 
            // diem1BindingSource1
            // 
            this.diem1BindingSource1.DataMember = "Diem1";
            this.diem1BindingSource1.DataSource = this._19CT112_04_05DataSet;
            // 
            // rp_GT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 617);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "rp_GT";
            this.Text = "rp_GT";
            this.Load += new System.EventHandler(this.rp_GT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.diem1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._19CT112_04_05DataSet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diem1BindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private _19CT112_04_05DataSet _19CT112_04_05DataSet;
        private System.Windows.Forms.BindingSource diem1BindingSource;
        private _19CT112_04_05DataSetTableAdapters.Diem1TableAdapter diem1TableAdapter;
        private System.Windows.Forms.BindingSource diem1BindingSource1;
    }
}