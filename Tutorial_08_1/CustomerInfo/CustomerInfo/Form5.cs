using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace CustomerInfo
{
    public partial class ExportForm : Form
    {
        public ExportForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
            reportViewer1.Dock = DockStyle.Fill; 
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
            
        }

   
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            ExportReport("PDF");
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportReport("Excel");
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
           ExportReport("Word");
        }
        private void LoadData()
        {
            string connectionString = @"Data Source=DESKTOP-GKTPEC8\SQLEXPRESSTESTER;Initial Catalog=CustomerDb;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    MessageBox.Show($"Records retrieved: {dt.Rows.Count}");
                    ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                    reportViewer1.LocalReport.ReportPath = @"C:\\Users\\yyct\\Desktop\\c-sharp-ojt-tutorials\\Tutorial_08_1\\CustomerInfo\\CustomerInfo\\CustomerListReport.rdlc";
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void ExportReport(string format)
        {
            if (reportViewer1.LocalReport.DataSources.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            string mimeType;
            string encoding;
            string fileNameExtension;

            string[] streams;
            Warning[] warnings;

            // Render the report
            byte[] renderedBytes = reportViewer1.LocalReport.Render(
                format,
                null,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            // Save the file


            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = $"{fileNameExtension.ToUpper()} Files (*.{fileNameExtension})|*.{fileNameExtension}";
                saveFileDialog.FileName = $"Report.{fileNameExtension}";

                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        fs.Write(renderedBytes, 0, renderedBytes.Length);
                    }
                    MessageBox.Show("Report exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }


    }
}
