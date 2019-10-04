namespace CreateSQLiteTables
{
    partial class FO_Principal
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
            this.lbl_database = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_file = new System.Windows.Forms.Button();
            this.btn_create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_database
            // 
            this.lbl_database.AutoSize = true;
            this.lbl_database.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_database.Location = new System.Drawing.Point(12, 22);
            this.lbl_database.Name = "lbl_database";
            this.lbl_database.Size = new System.Drawing.Size(64, 14);
            this.lbl_database.TabIndex = 0;
            this.lbl_database.Text = "DataBase";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(302, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btn_file
            // 
            this.btn_file.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_file.Location = new System.Drawing.Point(391, 22);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(41, 23);
            this.btn_file.TabIndex = 2;
            this.btn_file.Text = "File";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // btn_create
            // 
            this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_create.Location = new System.Drawing.Point(340, 64);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(104, 23);
            this.btn_create.TabIndex = 2;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // FO_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(445, 87);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.btn_file);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_database);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FO_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreaterTable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_database;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_file;
        private System.Windows.Forms.Button btn_create;
    }
}

