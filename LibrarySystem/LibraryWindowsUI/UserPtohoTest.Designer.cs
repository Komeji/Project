namespace LibraryWindowsUI
{
    partial class UserPtohoTest
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
            this.pBTest = new System.Windows.Forms.PictureBox();
            this.tbTest = new System.Windows.Forms.TextBox();
            this.btInsertTest = new System.Windows.Forms.Button();
            this.btSelectTest = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pBTest)).BeginInit();
            this.SuspendLayout();
            // 
            // pBTest
            // 
            this.pBTest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBTest.Location = new System.Drawing.Point(205, 27);
            this.pBTest.Name = "pBTest";
            this.pBTest.Size = new System.Drawing.Size(120, 167);
            this.pBTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBTest.TabIndex = 7;
            this.pBTest.TabStop = false;
            this.toolTip1.SetToolTip(this.pBTest, "单击选择照片");
            this.pBTest.Click += new System.EventHandler(this.pBTest_Click);
            // 
            // tbTest
            // 
            this.tbTest.Location = new System.Drawing.Point(73, 173);
            this.tbTest.Name = "tbTest";
            this.tbTest.Size = new System.Drawing.Size(100, 21);
            this.tbTest.TabIndex = 6;
            // 
            // btInsertTest
            // 
            this.btInsertTest.Location = new System.Drawing.Point(236, 200);
            this.btInsertTest.Name = "btInsertTest";
            this.btInsertTest.Size = new System.Drawing.Size(75, 23);
            this.btInsertTest.TabIndex = 5;
            this.btInsertTest.Text = "插入照片";
            this.btInsertTest.UseVisualStyleBackColor = true;
            this.btInsertTest.Click += new System.EventHandler(this.btInsertTest_Click);
            // 
            // btSelectTest
            // 
            this.btSelectTest.Location = new System.Drawing.Point(87, 200);
            this.btSelectTest.Name = "btSelectTest";
            this.btSelectTest.Size = new System.Drawing.Size(75, 23);
            this.btSelectTest.TabIndex = 4;
            this.btSelectTest.Text = "查找相片";
            this.btSelectTest.UseVisualStyleBackColor = true;
            this.btSelectTest.Click += new System.EventHandler(this.btSelectTest_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UserPtohoTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 265);
            this.Controls.Add(this.pBTest);
            this.Controls.Add(this.tbTest);
            this.Controls.Add(this.btInsertTest);
            this.Controls.Add(this.btSelectTest);
            this.Name = "UserPtohoTest";
            this.Text = "UserPtohoTest";
            this.Load += new System.EventHandler(this.UserPtohoTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBTest;
        private System.Windows.Forms.TextBox tbTest;
        private System.Windows.Forms.Button btInsertTest;
        private System.Windows.Forms.Button btSelectTest;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}