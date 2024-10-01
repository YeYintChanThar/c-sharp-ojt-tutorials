namespace CustomerInfo
{
    partial class Registeration_Form
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
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.cboMemberCard = new System.Windows.Forms.ComboBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
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
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblConfirmPwd = new System.Windows.Forms.Label();
            this.txtConfirmPwd = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCreateAccount.Location = new System.Drawing.Point(494, 596);
            this.btnCreateAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(140, 39);
            this.btnCreateAccount.TabIndex = 69;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // cboMemberCard
            // 
            this.cboMemberCard.FormattingEnabled = true;
            this.cboMemberCard.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cboMemberCard.Location = new System.Drawing.Point(355, 360);
            this.cboMemberCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMemberCard.Name = "cboMemberCard";
            this.cboMemberCard.Size = new System.Drawing.Size(167, 24);
            this.cboMemberCard.TabIndex = 68;
            // 
            // dtpDOB
            // 
            this.dtpDOB.CustomFormat = "dd/MM/yyyy";
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOB.Location = new System.Drawing.Point(355, 267);
            this.dtpDOB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(200, 22);
            this.dtpDOB.TabIndex = 67;
            this.dtpDOB.Value = new System.DateTime(1994, 2, 28, 0, 0, 0, 0);
            this.dtpDOB.ValueChanged += new System.EventHandler(this.dtpDOB_ValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClear.Location = new System.Drawing.Point(673, 596);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 38);
            this.btnClear.TabIndex = 65;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(707, 367);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(346, 172);
            this.txtAddress.TabIndex = 64;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(627, 379);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 16);
            this.lblAddress.TabIndex = 63;
            this.lblAddress.Text = "Address";
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpload.Location = new System.Drawing.Point(952, 267);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(101, 30);
            this.btnUpload.TabIndex = 62;
            this.btnUpload.Text = "Choose File";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click_1);
            // 
            // img
            // 
            this.img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img.Location = new System.Drawing.Point(707, 267);
            this.img.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(226, 80);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img.TabIndex = 61;
            this.img.TabStop = false;
            // 
            // txtPh2
            // 
            this.txtPh2.Location = new System.Drawing.Point(707, 210);
            this.txtPh2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPh2.Name = "txtPh2";
            this.txtPh2.Size = new System.Drawing.Size(226, 22);
            this.txtPh2.TabIndex = 60;
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Location = new System.Drawing.Point(714, 75);
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
            this.rdoFemale.Location = new System.Drawing.Point(844, 75);
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
            this.rdoMale.Location = new System.Drawing.Point(780, 75);
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
            this.lblImg.Location = new System.Drawing.Point(627, 267);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(45, 16);
            this.lblImg.TabIndex = 56;
            this.lblImg.Text = "Image";
            // 
            // lblPh2
            // 
            this.lblPh2.AutoSize = true;
            this.lblPh2.Location = new System.Drawing.Point(627, 213);
            this.lblPh2.Name = "lblPh2";
            this.lblPh2.Size = new System.Drawing.Size(70, 16);
            this.lblPh2.TabIndex = 55;
            this.lblPh2.Text = "Phone No.";
            // 
            // lblPh1
            // 
            this.lblPh1.AutoSize = true;
            this.lblPh1.Location = new System.Drawing.Point(627, 145);
            this.lblPh1.Name = "lblPh1";
            this.lblPh1.Size = new System.Drawing.Size(70, 16);
            this.lblPh1.TabIndex = 54;
            this.lblPh1.Text = "Phone No.";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(627, 77);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(52, 16);
            this.lblGender.TabIndex = 53;
            this.lblGender.Text = "Gender";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(225, 421);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 16);
            this.lblEmail.TabIndex = 52;
            this.lblEmail.Text = "Email";
            // 
            // txtPh1
            // 
            this.txtPh1.Location = new System.Drawing.Point(707, 145);
            this.txtPh1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPh1.Name = "txtPh1";
            this.txtPh1.Size = new System.Drawing.Size(226, 22);
            this.txtPh1.TabIndex = 51;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(355, 418);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(167, 22);
            this.txtEmail.TabIndex = 50;
            // 
            // lblMemberCard
            // 
            this.lblMemberCard.AutoSize = true;
            this.lblMemberCard.Location = new System.Drawing.Point(225, 360);
            this.lblMemberCard.Name = "lblMemberCard";
            this.lblMemberCard.Size = new System.Drawing.Size(89, 16);
            this.lblMemberCard.TabIndex = 49;
            this.lblMemberCard.Text = "Member Card";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(225, 317);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 16);
            this.lblAge.TabIndex = 48;
            this.lblAge.Text = "Age";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(225, 267);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(79, 16);
            this.lblDOB.TabIndex = 47;
            this.lblDOB.Text = "Date of Birth";
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtAge.Location = new System.Drawing.Point(355, 317);
            this.txtAge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(167, 22);
            this.txtAge.TabIndex = 46;
            // 
            // txtNRC
            // 
            this.txtNRC.Location = new System.Drawing.Point(355, 207);
            this.txtNRC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(167, 22);
            this.txtNRC.TabIndex = 45;
            // 
            // lblNRC
            // 
            this.lblNRC.AutoSize = true;
            this.lblNRC.Location = new System.Drawing.Point(225, 207);
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Size = new System.Drawing.Size(60, 16);
            this.lblNRC.TabIndex = 44;
            this.lblNRC.Text = "NRC No.";
            // 
            // txtCustomName
            // 
            this.txtCustomName.Location = new System.Drawing.Point(355, 145);
            this.txtCustomName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomName.Name = "txtCustomName";
            this.txtCustomName.Size = new System.Drawing.Size(167, 22);
            this.txtCustomName.TabIndex = 43;
            // 
            // lblCustomName
            // 
            this.lblCustomName.AutoSize = true;
            this.lblCustomName.Location = new System.Drawing.Point(225, 145);
            this.lblCustomName.Name = "lblCustomName";
            this.lblCustomName.Size = new System.Drawing.Size(104, 16);
            this.lblCustomName.TabIndex = 42;
            this.lblCustomName.Text = "Customer Name";
            // 
            // txtCustomID
            // 
            this.txtCustomID.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtCustomID.Location = new System.Drawing.Point(355, 77);
            this.txtCustomID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomID.Name = "txtCustomID";
            this.txtCustomID.ReadOnly = true;
            this.txtCustomID.Size = new System.Drawing.Size(167, 22);
            this.txtCustomID.TabIndex = 41;
            // 
            // lblCustomID
            // 
            this.lblCustomID.AutoSize = true;
            this.lblCustomID.Location = new System.Drawing.Point(225, 77);
            this.lblCustomID.Name = "lblCustomID";
            this.lblCustomID.Size = new System.Drawing.Size(80, 16);
            this.lblCustomID.TabIndex = 40;
            this.lblCustomID.Text = "Customer ID";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(355, 472);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(167, 22);
            this.txtPwd.TabIndex = 70;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(225, 475);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(67, 16);
            this.lblPwd.TabIndex = 71;
            this.lblPwd.Text = "Password";
            // 
            // lblConfirmPwd
            // 
            this.lblConfirmPwd.AutoSize = true;
            this.lblConfirmPwd.Location = new System.Drawing.Point(225, 523);
            this.lblConfirmPwd.Name = "lblConfirmPwd";
            this.lblConfirmPwd.Size = new System.Drawing.Size(115, 16);
            this.lblConfirmPwd.TabIndex = 72;
            this.lblConfirmPwd.Text = "Confirm Password";
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.Location = new System.Drawing.Point(355, 517);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.Size = new System.Drawing.Size(167, 22);
            this.txtConfirmPwd.TabIndex = 73;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1395, 24);
            this.menuStrip1.TabIndex = 74;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Registeration_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 671);
            this.Controls.Add(this.txtConfirmPwd);
            this.Controls.Add(this.lblConfirmPwd);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.cboMemberCard);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.btnClear);
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Registeration_Form";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.ComboBox cboMemberCard;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Button btnClear;
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
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblConfirmPwd;
        private System.Windows.Forms.TextBox txtConfirmPwd;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}