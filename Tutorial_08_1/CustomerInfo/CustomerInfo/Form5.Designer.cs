namespace CustomerInfo
{
    partial class ExportForm
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExportWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(77, 29);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(715, 346);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExportPDF.Location = new System.Drawing.Point(430, 406);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(93, 35);
            this.btnExportPDF.TabIndex = 2;
            this.btnExportPDF.Text = "Export PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExportExcel.Location = new System.Drawing.Point(553, 406);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(98, 35);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnExportWord
            // 
            this.btnExportWord.BackColor = System.Drawing.Color.LimeGreen;
            this.btnExportWord.Location = new System.Drawing.Point(683, 406);
            this.btnExportWord.Name = "btnExportWord";
            this.btnExportWord.Size = new System.Drawing.Size(109, 35);
            this.btnExportWord.TabIndex = 4;
            this.btnExportWord.Text = "Export Word";
            this.btnExportWord.UseVisualStyleBackColor = false;
            this.btnExportWord.Click += new System.EventHandler(this.btnExportWord_Click);
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 505);
            this.Controls.Add(this.btnExportWord);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ExportForm";
            this.Text = "Form5";
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportWord;
    }
}