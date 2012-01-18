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
            this.button1 = new System.Windows.Forms.Button();
            this.listViewIssues = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRepo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.listViewRepos = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonList = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.tabControlForm.SuspendLayout();
            this.tabPageIssues.SuspendLayout();
            this.tabPageRepositories.SuspendLayout();
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
            this.tabPageIssues.Controls.Add(this.label4);
            this.tabPageIssues.Controls.Add(this.textBoxBody);
            this.tabPageIssues.Controls.Add(this.label3);
            this.tabPageIssues.Controls.Add(this.textBoxTitle);
            this.tabPageIssues.Controls.Add(this.label2);
            this.tabPageIssues.Controls.Add(this.textBoxRepo);
            this.tabPageIssues.Controls.Add(this.label1);
            this.tabPageIssues.Controls.Add(this.textBoxUser);
            this.tabPageIssues.Controls.Add(this.button2);
            this.tabPageIssues.Controls.Add(this.listViewIssues);
            this.tabPageIssues.Controls.Add(this.button1);
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
            this.tabPageRepositories.Controls.Add(this.label5);
            this.tabPageRepositories.Controls.Add(this.textBoxPage);
            this.tabPageRepositories.Controls.Add(this.label6);
            this.tabPageRepositories.Controls.Add(this.textBoxDesc);
            this.tabPageRepositories.Controls.Add(this.label7);
            this.tabPageRepositories.Controls.Add(this.textBoxName);
            this.tabPageRepositories.Controls.Add(this.button3);
            this.tabPageRepositories.Controls.Add(this.buttonList);
            this.tabPageRepositories.Controls.Add(this.listViewRepos);
            this.tabPageRepositories.Location = new System.Drawing.Point(4, 22);
            this.tabPageRepositories.Name = "tabPageRepositories";
            this.tabPageRepositories.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRepositories.Size = new System.Drawing.Size(632, 269);
            this.tabPageRepositories.TabIndex = 1;
            this.tabPageRepositories.Text = "Repositories";
            this.tabPageRepositories.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(473, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "list";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewIssues
            // 
            this.listViewIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewIssues.Location = new System.Drawing.Point(6, 35);
            this.listViewIssues.Name = "listViewIssues";
            this.listViewIssues.Size = new System.Drawing.Size(300, 228);
            this.listViewIssues.TabIndex = 1;
            this.listViewIssues.UseCompatibleStateImageBehavior = false;
            this.listViewIssues.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Comments";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Body";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(367, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Create New";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(367, 23);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(100, 20);
            this.textBoxUser.TabIndex = 3;
            this.textBoxUser.Text = "vilhena-services";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "user";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "repo";
            // 
            // textBoxRepo
            // 
            this.textBoxRepo.Location = new System.Drawing.Point(367, 49);
            this.textBoxRepo.Name = "textBoxRepo";
            this.textBoxRepo.Size = new System.Drawing.Size(100, 20);
            this.textBoxRepo.TabIndex = 5;
            this.textBoxRepo.Text = "fillwithstuff";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "title";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(367, 75);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(100, 20);
            this.textBoxTitle.TabIndex = 7;
            this.textBoxTitle.Text = "Tittle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "body";
            // 
            // textBoxBody
            // 
            this.textBoxBody.Location = new System.Drawing.Point(367, 101);
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(100, 20);
            this.textBoxBody.TabIndex = 9;
            this.textBoxBody.Text = "Body";
            // 
            // listViewRepos
            // 
            this.listViewRepos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.listViewRepos.Location = new System.Drawing.Point(6, 35);
            this.listViewRepos.Name = "listViewRepos";
            this.listViewRepos.Size = new System.Drawing.Size(300, 228);
            this.listViewRepos.TabIndex = 2;
            this.listViewRepos.UseCompatibleStateImageBehavior = false;
            this.listViewRepos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Description";
            // 
            // buttonList
            // 
            this.buttonList.Location = new System.Drawing.Point(312, 35);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(75, 23);
            this.buttonList.TabIndex = 3;
            this.buttonList.Text = "list";
            this.buttonList.UseVisualStyleBackColor = true;
            this.buttonList.Click += new System.EventHandler(this.buttonList_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(476, 113);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "create";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "page";
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(451, 87);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(100, 20);
            this.textBoxPage.TabIndex = 13;
            this.textBoxPage.Text = "homepage";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(410, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "desc";
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Location = new System.Drawing.Point(451, 61);
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(100, 20);
            this.textBoxDesc.TabIndex = 11;
            this.textBoxDesc.Text = "description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(451, 35);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 9;
            this.textBoxName.Text = "name";
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
            this.tabPageIssues.ResumeLayout(false);
            this.tabPageIssues.PerformLayout();
            this.tabPageRepositories.ResumeLayout(false);
            this.tabPageRepositories.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listViewIssues;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRepo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.ListView listViewRepos;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxName;
    }
}

