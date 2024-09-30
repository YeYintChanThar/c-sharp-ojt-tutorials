namespace CustomerInfo
{
    partial class CustomerInfoEdit
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.cboMemberCard = new System.Windows.Forms.ComboBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.img = new System.Windows.Forms.PictureBox();
            this.txtPh2 = new System.Windows.Forms.TextBox();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.lblImg = new System.Windows.Forms.Label();
            this.lblPh2 = new System.Windows.Forms.Label();
            this.lblPh1 = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPh1 = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMemberCard = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtNRC = new System.Windows.Forms.TextBox();
            this.lblNRC = new System.Windows.Forms.Label();
            this.txtCustomName = new System.Windows.Forms.TextBox();
            this.lblCustomName = new System.Windows.Forms.Label();
            this.txtCustomID = new System.Windows.Forms.TextBox();
            this.lblCustomID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEdit.Location = new System.Drawing.Point(197, 487);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 39);
            this.btnEdit.TabIndex = 69;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cboMemberCard
            // 
            this.cboMemberCard.FormattingEnabled = true;
            this.cboMemberCard.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cboMemberCard.Location = new System.Drawing.Point(197, 365);
            this.cboMemberCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMemberCard.Name = "cboMemberCard";
            this.cboMemberCard.Size = new System.Drawing.Size(167, 24);
            this.cboMemberCard.TabIndex = 68;
            // 
            // dtpDOB
            // 
            this.dtpDOB.CustomFormat = "dd/MM/yyyy";
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOB.Location = new System.Drawing.Point(197, 272);
            this.dtpDOB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(200, 22);
            this.dtpDOB.TabIndex = 67;
            this.dtpDOB.Value = new System.DateTime(1994, 2, 28, 0, 0, 0, 0);
            this.dtpDOB.ValueChanged += new System.EventHandler(this.dtpDOB_ValueChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnDelete.Location = new System.Drawing.Point(701, 487);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 39);
            this.btnDelete.TabIndex = 66;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(701, 369);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(247, 90);
            this.txtAddress.TabIndex = 64;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(582, 373);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 16);
            this.lblAddress.TabIndex = 63;
            this.lblAddress.Text = "Address";
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpload.Location = new System.Drawing.Point(846, 282);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(101, 30);
            this.btnUpload.TabIndex = 62;
            this.btnUpload.Text = "Choose File";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // img
            // 
            this.img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img.Location = new System.Drawing.Point(701, 272);
            this.img.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(125, 66);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img.TabIndex = 61;
            this.img.TabStop = false;
            this.img.Click += new System.EventHandler(this.img_Click);
            // 
            // txtPh2
            // 
            this.txtPh2.Location = new System.Drawing.Point(701, 205);
            this.txtPh2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPh2.Name = "txtPh2";
            this.txtPh2.Size = new System.Drawing.Size(173, 22);
            this.txtPh2.TabIndex = 60;
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Location = new System.Drawing.Point(701, 95);
            this.rdoOther.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(60, 20);
            this.rdoOther.TabIndex = 59;
            this.rdoOther.TabStop = true;
            this.rdoOther.Text = "Other";
            this.rdoOther.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(937, 95);
            this.rdoFemale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(74, 20);
            this.rdoFemale.TabIndex = 58;
            this.rdoFemale.TabStop = true;
            this.rdoFemale.Text = "Female";
            this.rdoFemale.UseVisualStyleBackColor = true;
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Location = new System.Drawing.Point(833, 95);
            this.rdoMale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(58, 20);
            this.rdoMale.TabIndex = 57;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "Male";
            this.rdoMale.UseVisualStyleBackColor = true;
            // 
            // lblImg
            // 
            this.lblImg.AutoSize = true;
            this.lblImg.Location = new System.Drawing.Point(582, 272);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(45, 16);
            this.lblImg.TabIndex = 56;
            this.lblImg.Text = "Image";
            // 
            // lblPh2
            // 
            this.lblPh2.AutoSize = true;
            this.lblPh2.Location = new System.Drawing.Point(582, 212);
            this.lblPh2.Name = "lblPh2";
            this.lblPh2.Size = new System.Drawing.Size(70, 16);
            this.lblPh2.TabIndex = 55;
            this.lblPh2.Text = "Phone No.";
            // 
            // lblPh1
            // 
            this.lblPh1.AutoSize = true;
            this.lblPh1.Location = new System.Drawing.Point(582, 150);
            this.lblPh1.Name = "lblPh1";
            this.lblPh1.Size = new System.Drawing.Size(70, 16);
            this.lblPh1.TabIndex = 54;
            this.lblPh1.Text = "Phone No.";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(582, 95);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(52, 16);
            this.lblGender.TabIndex = 53;
            this.lblGender.Text = "Gender";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(67, 412);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 16);
            this.lblEmail.TabIndex = 52;
            this.lblEmail.Text = "Email";
            // 
            // txtPh1
            // 
            this.txtPh1.Location = new System.Drawing.Point(701, 150);
            this.txtPh1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPh1.Name = "txtPh1";
            this.txtPh1.Size = new System.Drawing.Size(173, 22);
            this.txtPh1.TabIndex = 51;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(197, 412);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(167, 22);
            this.txtEmail.TabIndex = 50;
            // 
            // lblMemberCard
            // 
            this.lblMemberCard.AutoSize = true;
            this.lblMemberCard.Location = new System.Drawing.Point(67, 365);
            this.lblMemberCard.Name = "lblMemberCard";
            this.lblMemberCard.Size = new System.Drawing.Size(89, 16);
            this.lblMemberCard.TabIndex = 49;
            this.lblMemberCard.Text = "Member Card";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(67, 322);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 16);
            this.lblAge.TabIndex = 48;
            this.lblAge.Text = "Age";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(67, 272);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(79, 16);
            this.lblDOB.TabIndex = 47;
            this.lblDOB.Text = "Date of Birth";
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtAge.Location = new System.Drawing.Point(197, 322);
            this.txtAge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(167, 22);
            this.txtAge.TabIndex = 46;
            // 
            // txtNRC
            // 
            this.txtNRC.Location = new System.Drawing.Point(197, 212);
            this.txtNRC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(167, 22);
            this.txtNRC.TabIndex = 45;
            // 
            // lblNRC
            // 
            this.lblNRC.AutoSize = true;
            this.lblNRC.Location = new System.Drawing.Point(67, 212);
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Size = new System.Drawing.Size(60, 16);
            this.lblNRC.TabIndex = 44;
            this.lblNRC.Text = "NRC No.";
            // 
            // txtCustomName
            // 
            this.txtCustomName.Location = new System.Drawing.Point(197, 150);
            this.txtCustomName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomName.Name = "txtCustomName";
            this.txtCustomName.Size = new System.Drawing.Size(167, 22);
            this.txtCustomName.TabIndex = 43;
            // 
            // lblCustomName
            // 
            this.lblCustomName.AutoSize = true;
            this.lblCustomName.Location = new System.Drawing.Point(67, 150);
            this.lblCustomName.Name = "lblCustomName";
            this.lblCustomName.Size = new System.Drawing.Size(104, 16);
            this.lblCustomName.TabIndex = 42;
            this.lblCustomName.Text = "Customer Name";
            // 
            // txtCustomID
            // 
            this.txtCustomID.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtCustomID.Location = new System.Drawing.Point(197, 82);
            this.txtCustomID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomID.Name = "txtCustomID";
            this.txtCustomID.ReadOnly = true;
            this.txtCustomID.Size = new System.Drawing.Size(167, 22);
            this.txtCustomID.TabIndex = 41;
            // 
            // lblCustomID
            // 
            this.lblCustomID.AutoSize = true;
            this.lblCustomID.Location = new System.Drawing.Point(67, 82);
            this.lblCustomID.Name = "lblCustomID";
            this.lblCustomID.Size = new System.Drawing.Size(80, 16);
            this.lblCustomID.TabIndex = 40;
            this.lblCustomID.Text = "Customer ID";
            // 
            // CustomerInfoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 608);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cboMemberCard);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.img);
            this.Controls.Add(this.txtPh2);
            this.Controls.Add(this.rdoOther);
            this.Controls.Add(this.rdoFemale);
            this.Controls.Add(this.rdoMale);
            this.Controls.Add(this.lblImg);
            this.Controls.Add(this.lblPh2);
            this.Controls.Add(this.lblPh1);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPh1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblMemberCard);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtNRC);
            this.Controls.Add(this.lblNRC);
            this.Controls.Add(this.txtCustomName);
            this.Controls.Add(this.lblCustomName);
            this.Controls.Add(this.txtCustomID);
            this.Controls.Add(this.lblCustomID);
            this.Name = "CustomerInfoEdit";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cboMemberCard;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.TextBox txtPh2;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.Label lblImg;
        private System.Windows.Forms.Label lblPh2;
        private System.Windows.Forms.Label lblPh1;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPh1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMemberCard;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtNRC;
        private System.Windows.Forms.Label lblNRC;
        private System.Windows.Forms.TextBox txtCustomName;
        private System.Windows.Forms.Label lblCustomName;
        private System.Windows.Forms.TextBox txtCustomID;
        private System.Windows.Forms.Label lblCustomID;
    }
}