namespace GitHubSoap.Client.Forms
{
    partial class GitHubClient
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.bttConnect = new System.Windows.Forms.Button();
            this.ckbConnected = new System.Windows.Forms.CheckBox();
            this.tabControlForm = new System.Windows.Forms.TabControl();
            this.tabPageIssues = new System.Windows.Forms.TabPage();
            this.tabPageRepositories = new System.Windows.Forms.TabPage();
            this.tabControlForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(118, 12);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // bttConnect
            // 
            this.bttConnect.Location = new System.Drawing.Point(225, 8);
            this.bttConnect.Name = "bttConnect";
            this.bttConnect.Size = new System.Drawing.Size(75, 23);
            this.bttConnect.TabIndex = 2;
            this.bttConnect.Text = "Connect";
            this.bttConnect.UseVisualStyleBackColor = true;
            this.bttConnect.Click += new System.EventHandler(this.bttConnect_Click);
            // 
            // ckbConnected
            // 
            this.ckbConnected.AutoSize = true;
            this.ckbConnected.Enabled = false;
            this.ckbConnected.Location = new System.Drawing.Point(307, 14);
            this.ckbConnected.Name = "ckbConnected";
            this.ckbConnected.Size = new System.Drawing.Size(15, 14);
            this.ckbConnected.TabIndex = 3;
            this.ckbConnected.UseVisualStyleBackColor = true;
            // 
            // tabControlForm
            // 
            this.tabControlForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlForm.Controls.Add(this.tabPageIssues);
            this.tabControlForm.Controls.Add(this.tabPageRepositories);
            this.tabControlForm.Enabled = false;
            this.tabControlForm.Location = new System.Drawing.Point(12, 38);
            this.tabControlForm.Name = "tabControlForm";
            this.tabControlForm.SelectedIndex = 0;
            this.tabControlForm.Size = new System.Drawing.Size(640, 295);
            this.tabControlForm.TabIndex = 4;
            // 
            // tabPageIssues
            // 
            this.tabPageIssues.Location = new System.Drawing.Point(4, 22);
            this.tabPageIssues.Name = "tabPageIssues";
            this.tabPageIssues.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIssues.Size = new System.Drawing.Size(632, 269);
            this.tabPageIssues.TabIndex = 0;
            this.tabPageIssues.Text = "Issues";
            this.tabPageIssues.UseVisualStyleBackColor = true;
            // 
            // tabPageRepositories
            // 
            this.tabPageRepositories.Location = new System.Drawing.Point(4, 22);
            this.tabPageRepositories.Name = "tabPageRepositories";
            this.tabPageRepositories.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRepositories.Size = new System.Drawing.Size(632, 231);
            this.tabPageRepositories.TabIndex = 1;
            this.tabPageRepositories.Text = "Repositories";
            this.tabPageRepositories.UseVisualStyleBackColor = true;
            // 
            // GitHubClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 335);
            this.Controls.Add(this.tabControlForm);
            this.Controls.Add(this.ckbConnected);
            this.Controls.Add(this.bttConnect);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Name = "GitHubClient";
            this.Text = "Git Hub Client";
            this.tabControlForm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button bttConnect;
        private System.Windows.Forms.CheckBox ckbConnected;
        private System.Windows.Forms.TabControl tabControlForm;
        private System.Windows.Forms.TabPage tabPageIssues;
        private System.Windows.Forms.TabPage tabPageRepositories;
    }
}

