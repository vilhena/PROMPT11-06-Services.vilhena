namespace ChatServiceClient
{
    partial class Chat
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
            this.Send = new System.Windows.Forms.Button();
            this.Msg = new System.Windows.Forms.TextBox();
            this.ChatText = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.Nickname = new System.Windows.Forms.TextBox();
            this.Logout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(506, 326);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 0;
            this.Send.Text = "send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Msg
            // 
            this.Msg.Location = new System.Drawing.Point(265, 241);
            this.Msg.Multiline = true;
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(316, 79);
            this.Msg.TabIndex = 1;
            // 
            // ChatText
            // 
            this.ChatText.Location = new System.Drawing.Point(12, 12);
            this.ChatText.Multiline = true;
            this.ChatText.Name = "ChatText";
            this.ChatText.Size = new System.Drawing.Size(569, 223);
            this.ChatText.TabIndex = 2;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(119, 289);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 23);
            this.Login.TabIndex = 3;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Nickname
            // 
            this.Nickname.Location = new System.Drawing.Point(13, 289);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(100, 20);
            this.Nickname.TabIndex = 4;
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(119, 325);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 23);
            this.Logout.TabIndex = 5;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 359);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.Nickname);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.ChatText);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.Send);
            this.Name = "Chat";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox Msg;
        private System.Windows.Forms.TextBox ChatText;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox Nickname;
        private System.Windows.Forms.Button Logout;
    }
}

