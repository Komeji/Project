namespace LibraryWindowsUI
{
    partial class Search
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
            this.btAdminLoginNo = new System.Windows.Forms.Button();
            this.btAdminLoginYes = new System.Windows.Forms.Button();
            this.tbAdminPwd = new System.Windows.Forms.TextBox();
            this.tbAdminId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btAdminLoginNo
            // 
            this.btAdminLoginNo.Location = new System.Drawing.Point(169, 113);
            this.btAdminLoginNo.Name = "btAdminLoginNo";
            this.btAdminLoginNo.Size = new System.Drawing.Size(63, 23);
            this.btAdminLoginNo.TabIndex = 11;
            this.btAdminLoginNo.Text = "取消";
            this.btAdminLoginNo.UseVisualStyleBackColor = true;
            this.btAdminLoginNo.Click += new System.EventHandler(this.btAdminLoginNo_Click);
            // 
            // btAdminLoginYes
            // 
            this.btAdminLoginYes.Location = new System.Drawing.Point(50, 113);
            this.btAdminLoginYes.Name = "btAdminLoginYes";
            this.btAdminLoginYes.Size = new System.Drawing.Size(63, 23);
            this.btAdminLoginYes.TabIndex = 10;
            this.btAdminLoginYes.Text = "确定";
            this.btAdminLoginYes.UseVisualStyleBackColor = true;
            this.btAdminLoginYes.Click += new System.EventHandler(this.btAdminLoginYes_Click);
            // 
            // tbAdminPwd
            // 
            this.tbAdminPwd.Location = new System.Drawing.Point(89, 66);
            this.tbAdminPwd.Name = "tbAdminPwd";
            this.tbAdminPwd.Size = new System.Drawing.Size(132, 21);
            this.tbAdminPwd.TabIndex = 9;
            this.tbAdminPwd.UseSystemPasswordChar = true;
            // 
            // tbAdminId
            // 
            this.tbAdminId.Location = new System.Drawing.Point(89, 29);
            this.tbAdminId.Name = "tbAdminId";
            this.tbAdminId.Size = new System.Drawing.Size(132, 21);
            this.tbAdminId.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名:";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 167);
            this.Controls.Add(this.btAdminLoginNo);
            this.Controls.Add(this.btAdminLoginYes);
            this.Controls.Add(this.tbAdminPwd);
            this.Controls.Add(this.tbAdminId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAdminLoginNo;
        private System.Windows.Forms.Button btAdminLoginYes;
        private System.Windows.Forms.TextBox tbAdminPwd;
        private System.Windows.Forms.TextBox tbAdminId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}