using System.Windows.Forms;

namespace CustomerInfo
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();

            
            this.lbCustomID = new System.Windows.Forms.Label();
            this.txtCustomID = new System.Windows.Forms.TextBox();
            this.lbCustomName = new System.Windows.Forms.Label();
            this.txtCustomName = new System.Windows.Forms.TextBox();
            this.lbNRC = new System.Windows.Forms.Label();
            this.txtNRC = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lbDOB = new System.Windows.Forms.Label();
            this.lbAge = new System.Windows.Forms.Label();
            this.lbMemberCard = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPh1 = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbGender = new System.Windows.Forms.Label();
            this.lbPh1 = new System.Windows.Forms.Label();
            this.lbPh2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.txtPh2 = new System.Windows.Forms.TextBox();
            this.img = new System.Windows.Forms.PictureBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lbAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.ddlMemberCard = new System.Windows.Forms.ComboBox();
            this.btnAddAndUpdate = new System.Windows.Forms.Button();
            this.btnSoftDelete = new System.Windows.Forms.Button();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.lblTotalRowsCount = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.lblOf = new System.Windows.Forms.Label();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCustomID
            // 
            this.lbCustomID.AutoSize = true;
            this.lbCustomID.Location = new System.Drawing.Point(57, 55);
            this.lbCustomID.Name = "lbCustomID";
            this.lbCustomID.Size = new System.Drawing.Size(80, 16);
            this.lbCustomID.TabIndex = 0;
            this.lbCustomID.Text = "Customer ID";
            // 
            // txtCustomID
            // 
            this.txtCustomID.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtCustomID.Location = new System.Drawing.Point(187, 55);
            this.txtCustomID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomID.Name = "txtCustomID";
            this.txtCustomID.ReadOnly = true;
            this.txtCustomID.Size = new System.Drawing.Size(167, 22);
            this.txtCustomID.TabIndex = 1;
            // 
            // lbCustomName
            // 
            this.lbCustomName.AutoSize = true;
            this.lbCustomName.Location = new System.Drawing.Point(57, 123);
            this.lbCustomName.Name = "lbCustomName";
            this.lbCustomName.Size = new System.Drawing.Size(104, 16);
            this.lbCustomName.TabIndex = 2;
            this.lbCustomName.Text = "Customer Name";
            // 
            // txtCustomName
            // 
            this.txtCustomName.Location = new System.Drawing.Point(187, 123);
            this.txtCustomName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomName.Name = "txtCustomName";
            this.txtCustomName.Size = new System.Drawing.Size(167, 22);
            this.txtCustomName.TabIndex = 3;
            // 
            // lbNRC
            // 
            this.lbNRC.AutoSize = true;
            this.lbNRC.Location = new System.Drawing.Point(57, 185);
            this.lbNRC.Name = "lbNRC";
            this.lbNRC.Size = new System.Drawing.Size(60, 16);
            this.lbNRC.TabIndex = 4;
            this.lbNRC.Text = "NRC No.";
            // 
            // txtNRC
            // 
            this.txtNRC.Location = new System.Drawing.Point(187, 185);
            this.txtNRC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(167, 22);
            this.txtNRC.TabIndex = 5;
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtAge.Location = new System.Drawing.Point(187, 295);
            this.txtAge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(167, 22);
            this.txtAge.TabIndex = 6;
            // 
            // lbDOB
            // 
            this.lbDOB.AutoSize = true;
            this.lbDOB.Location = new System.Drawing.Point(57, 245);
            this.lbDOB.Name = "lbDOB";
            this.lbDOB.Size = new System.Drawing.Size(79, 16);
            this.lbDOB.TabIndex = 7;
            this.lbDOB.Text = "Date of Birth";
            // 
            // lbAge
            // 
            this.lbAge.AutoSize = true;
            this.lbAge.Location = new System.Drawing.Point(57, 295);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(32, 16);
            this.lbAge.TabIndex = 9;
            this.lbAge.Text = "Age";
            // 
            // lbMemberCard
            // 
            this.lbMemberCard.AutoSize = true;
            this.lbMemberCard.Location = new System.Drawing.Point(57, 338);
            this.lbMemberCard.Name = "lbMemberCard";
            this.lbMemberCard.Size = new System.Drawing.Size(89, 16);
            this.lbMemberCard.TabIndex = 10;
            this.lbMemberCard.Text = "Member Card";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(187, 385);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(167, 22);
            this.txtEmail.TabIndex = 11;
            // 
            // txtPh1
            // 
            this.txtPh1.Location = new System.Drawing.Point(691, 123);
            this.txtPh1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPh1.Name = "txtPh1";
            this.txtPh1.Size = new System.Drawing.Size(173, 22);
            this.txtPh1.TabIndex = 12;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(57, 385);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(41, 16);
            this.lbEmail.TabIndex = 16;
            this.lbEmail.Text = "Email";
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.Location = new System.Drawing.Point(572, 68);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(52, 16);
            this.lbGender.TabIndex = 17;
            this.lbGender.Text = "Gender";
            // 
            // lbPh1
            // 
            this.lbPh1.AutoSize = true;
            this.lbPh1.Location = new System.Drawing.Point(572, 123);
            this.lbPh1.Name = "lbPh1";
            this.lbPh1.Size = new System.Drawing.Size(70, 16);
            this.lbPh1.TabIndex = 18;
            this.lbPh1.Text = "Phone No.";
            // 
            // lbPh2
            // 
            this.lbPh2.AutoSize = true;
            this.lbPh2.Location = new System.Drawing.Point(572, 185);
            this.lbPh2.Name = "lbPh2";
            this.lbPh2.Size = new System.Drawing.Size(70, 16);
            this.lbPh2.TabIndex = 19;
            this.lbPh2.Text = "Phone No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(572, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Image";
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Location = new System.Drawing.Point(823, 68);
            this.rdoMale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(58, 20);
            this.rdoMale.TabIndex = 24;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "Male";
            this.rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(927, 68);
            this.rdoFemale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(74, 20);
            this.rdoFemale.TabIndex = 25;
            this.rdoFemale.TabStop = true;
            this.rdoFemale.Text = "Female";
            this.rdoFemale.UseVisualStyleBackColor = true;
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Location = new System.Drawing.Point(691, 68);
            this.rdoOther.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(60, 20);
            this.rdoOther.TabIndex = 26;
            this.rdoOther.TabStop = true;
            this.rdoOther.Text = "Other";
            this.rdoOther.UseVisualStyleBackColor = true;
            // 
            // txtPh2
            // 
            this.txtPh2.Location = new System.Drawing.Point(691, 178);
            this.txtPh2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPh2.Name = "txtPh2";
            this.txtPh2.Size = new System.Drawing.Size(173, 22);
            this.txtPh2.TabIndex = 27;
            // 
            // img
            // 
            this.img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img.Location = new System.Drawing.Point(691, 245);
            this.img.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(125, 66);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img.TabIndex = 28;
            this.img.TabStop = false;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpload.Location = new System.Drawing.Point(836, 255);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(101, 30);
            this.btnUpload.TabIndex = 29;
            this.btnUpload.Text = "Choose File";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(572, 346);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(58, 16);
            this.lbAddress.TabIndex = 30;
            this.lbAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(691, 342);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(247, 90);
            this.txtAddress.TabIndex = 31;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClear.Location = new System.Drawing.Point(567, 460);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 32);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnDelete.Location = new System.Drawing.Point(691, 460);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 32);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(103, 561);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1248, 417);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Customer ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Image";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Staff Name";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "NRC No.";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Staff Type";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Email";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Gender";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "Age";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "Phone No.";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.HeaderText = "Phone No.";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column11.HeaderText = "Address";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.Visible = false;
            // 
            // dtpDOB
            // 
            this.dtpDOB.CustomFormat = "dd/MM/yyyy";
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOB.Location = new System.Drawing.Point(187, 245);
            this.dtpDOB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(200, 22);
            this.dtpDOB.TabIndex = 36;
            this.dtpDOB.Value = new System.DateTime(1994, 2, 28, 0, 0, 0, 0);
            this.dtpDOB.ValueChanged += new System.EventHandler(this.dtpDOB_ValueChanged);
            // 
            // ddlMemberCard
            // 
            this.ddlMemberCard.FormattingEnabled = true;
            this.ddlMemberCard.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.ddlMemberCard.Location = new System.Drawing.Point(187, 338);
            this.ddlMemberCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ddlMemberCard.Name = "ddlMemberCard";
            this.ddlMemberCard.Size = new System.Drawing.Size(167, 24);
            this.ddlMemberCard.TabIndex = 37;
            // 
            // btnAddAndUpdate
            // 
            this.btnAddAndUpdate.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddAndUpdate.Location = new System.Drawing.Point(187, 460);
            this.btnAddAndUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAndUpdate.Name = "btnAddAndUpdate";
            this.btnAddAndUpdate.Size = new System.Drawing.Size(100, 39);
            this.btnAddAndUpdate.TabIndex = 38;
            this.btnAddAndUpdate.Text = "Add/Update";
            this.btnAddAndUpdate.UseVisualStyleBackColor = false;
            this.btnAddAndUpdate.Click += new System.EventHandler(this.btnAddAndUpdate_Click);
            // 
            // btnSoftDelete
            // 
            this.btnSoftDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSoftDelete.Location = new System.Drawing.Point(813, 457);
            this.btnSoftDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSoftDelete.Name = "btnSoftDelete";
            this.btnSoftDelete.Size = new System.Drawing.Size(104, 34);
            this.btnSoftDelete.TabIndex = 39;
            this.btnSoftDelete.Text = "Soft Delete";
            this.btnSoftDelete.UseVisualStyleBackColor = false;
            this.btnSoftDelete.Click += new System.EventHandler(this.btnSoftDelete_Click);
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Location = new System.Drawing.Point(117, 529);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(78, 16);
            this.lblTotalRows.TabIndex = 40;
            this.lblTotalRows.Text = "Total Rows:";
            // 
            // lblTotalRowsCount
            // 
            this.lblTotalRowsCount.AutoSize = true;
            this.lblTotalRowsCount.Location = new System.Drawing.Point(201, 529);
            this.lblTotalRowsCount.Name = "lblTotalRowsCount";
            this.lblTotalRowsCount.Size = new System.Drawing.Size(14, 16);
            this.lblTotalRowsCount.TabIndex = 41;
            this.lblTotalRowsCount.Text = "0";
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(1139, 535);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(40, 16);
            this.lblPage.TabIndex = 42;
            this.lblPage.Text = "Page";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Location = new System.Drawing.Point(1195, 535);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(14, 16);
            this.lblCurrentPage.TabIndex = 43;
            this.lblCurrentPage.Text = "0";
            // 
            // lblOf
            // 
            this.lblOf.AutoSize = true;
            this.lblOf.Location = new System.Drawing.Point(1228, 535);
            this.lblOf.Name = "lblOf";
            this.lblOf.Size = new System.Drawing.Size(20, 16);
            this.lblOf.TabIndex = 44;
            this.lblOf.Text = "Of";
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Location = new System.Drawing.Point(1269, 535);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(14, 16);
            this.lblTotalPages.TabIndex = 45;
            this.lblTotalPages.Text = "0";
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFirst.Location = new System.Drawing.Point(989, 1000);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(88, 34);
            this.btnFirst.TabIndex = 46;
            this.btnFirst.Text = "FIRST";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrev.Location = new System.Drawing.Point(1093, 1000);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 34);
            this.btnPrev.TabIndex = 47;
            this.btnPrev.Text = "PREV";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Location = new System.Drawing.Point(1183, 1000);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 34);
            this.btnNext.TabIndex = 48;
            this.btnNext.Text = "NEXT";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLast.Location = new System.Drawing.Point(1276, 1000);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 34);
            this.btnLast.TabIndex = 49;
            this.btnLast.Text = "LAST";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1521, 1055);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.lblTotalPages);
            this.Controls.Add(this.lblOf);
            this.Controls.Add(this.lblCurrentPage);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.lblTotalRowsCount);
            this.Controls.Add(this.lblTotalRows);
            this.Controls.Add(this.btnSoftDelete);
            this.Controls.Add(this.btnAddAndUpdate);
            this.Controls.Add(this.ddlMemberCard);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.img);
            this.Controls.Add(this.txtPh2);
            this.Controls.Add(this.rdoOther);
            this.Controls.Add(this.rdoFemale);
            this.Controls.Add(this.rdoMale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbPh2);
            this.Controls.Add(this.lbPh1);
            this.Controls.Add(this.lbGender);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.txtPh1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lbMemberCard);
            this.Controls.Add(this.lbAge);
            this.Controls.Add(this.lbDOB);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtNRC);
            this.Controls.Add(this.lbNRC);
            this.Controls.Add(this.txtCustomName);
            this.Controls.Add(this.lbCustomName);
            this.Controls.Add(this.txtCustomID);
            this.Controls.Add(this.lbCustomID);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCustomID;
        private System.Windows.Forms.TextBox txtCustomID;
        private System.Windows.Forms.Label lbCustomName;
        private System.Windows.Forms.TextBox txtCustomName;
        private System.Windows.Forms.Label lbNRC;
        private System.Windows.Forms.TextBox txtNRC;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lbDOB;
        private System.Windows.Forms.Label lbAge;
        private System.Windows.Forms.Label lbMemberCard;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPh1;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.Label lbPh1;
        private System.Windows.Forms.Label lbPh2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.TextBox txtPh2;
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.ComboBox ddlMemberCard;
        private System.Windows.Forms.Button btnAddAndUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Button btnSoftDelete;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.Label lblTotalRowsCount;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label lblOf;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
    }
}

