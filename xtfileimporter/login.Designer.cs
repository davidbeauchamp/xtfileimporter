namespace xtfileimporter
{
    partial class login
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
            this._database = new System.Windows.Forms.TextBox();
            this._portLit = new System.Windows.Forms.Label();
            this._server = new System.Windows.Forms.TextBox();
            this._user = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._login = new System.Windows.Forms.Button();
            this._databaseLit = new System.Windows.Forms.Label();
            this._exit = new System.Windows.Forms.Button();
            this._port = new System.Windows.Forms.TextBox();
            this._serverLit = new System.Windows.Forms.Label();
            this._passwordLit = new System.Windows.Forms.Label();
            this._password = new System.Windows.Forms.TextBox();
            this._userLit = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _database
            // 
            this._database.Location = new System.Drawing.Point(79, 112);
            this._database.Name = "_database";
            this._database.Size = new System.Drawing.Size(158, 20);
            this._database.TabIndex = 3;
            // 
            // _portLit
            // 
            this._portLit.AutoSize = true;
            this._portLit.Location = new System.Drawing.Point(47, 89);
            this._portLit.Name = "_portLit";
            this._portLit.Size = new System.Drawing.Size(26, 13);
            this._portLit.TabIndex = 7;
            this._portLit.Text = "Port";
            // 
            // _server
            // 
            this._server.Location = new System.Drawing.Point(79, 60);
            this._server.Name = "_server";
            this._server.Size = new System.Drawing.Size(158, 20);
            this._server.TabIndex = 2;
            // 
            // _user
            // 
            this._user.Location = new System.Drawing.Point(79, 9);
            this._user.Name = "_user";
            this._user.Size = new System.Drawing.Size(158, 20);
            this._user.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._login);
            this.panel1.Controls.Add(this._databaseLit);
            this.panel1.Controls.Add(this._database);
            this.panel1.Controls.Add(this._exit);
            this.panel1.Controls.Add(this._portLit);
            this.panel1.Controls.Add(this._port);
            this.panel1.Controls.Add(this._serverLit);
            this.panel1.Controls.Add(this._server);
            this.panel1.Controls.Add(this._passwordLit);
            this.panel1.Controls.Add(this._password);
            this.panel1.Controls.Add(this._userLit);
            this.panel1.Controls.Add(this._user);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 146);
            this.panel1.TabIndex = 2;
            // 
            // _login
            // 
            this._login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._login.Location = new System.Drawing.Point(260, 39);
            this._login.Name = "_login";
            this._login.Size = new System.Drawing.Size(75, 23);
            this._login.TabIndex = 5;
            this._login.Text = "Login";
            this._login.UseVisualStyleBackColor = true;
            this._login.Click += new System.EventHandler(this._login_Click);
            // 
            // _databaseLit
            // 
            this._databaseLit.AutoSize = true;
            this._databaseLit.Location = new System.Drawing.Point(20, 115);
            this._databaseLit.Name = "_databaseLit";
            this._databaseLit.Size = new System.Drawing.Size(53, 13);
            this._databaseLit.TabIndex = 12;
            this._databaseLit.Text = "Database";
            // 
            // _exit
            // 
            this._exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._exit.Location = new System.Drawing.Point(260, 9);
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(75, 23);
            this._exit.TabIndex = 6;
            this._exit.Text = "Exit";
            this._exit.UseVisualStyleBackColor = true;
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // _port
            // 
            this._port.Location = new System.Drawing.Point(79, 86);
            this._port.Name = "_port";
            this._port.Size = new System.Drawing.Size(158, 20);
            this._port.TabIndex = 4;
            this._port.Text = "5432";
            // 
            // _serverLit
            // 
            this._serverLit.AutoSize = true;
            this._serverLit.Location = new System.Drawing.Point(35, 63);
            this._serverLit.Name = "_serverLit";
            this._serverLit.Size = new System.Drawing.Size(38, 13);
            this._serverLit.TabIndex = 5;
            this._serverLit.Text = "Server";
            // 
            // _passwordLit
            // 
            this._passwordLit.AutoSize = true;
            this._passwordLit.Location = new System.Drawing.Point(20, 38);
            this._passwordLit.Name = "_passwordLit";
            this._passwordLit.Size = new System.Drawing.Size(53, 13);
            this._passwordLit.TabIndex = 3;
            this._passwordLit.Text = "Password";
            // 
            // _password
            // 
            this._password.Location = new System.Drawing.Point(79, 35);
            this._password.Name = "_password";
            this._password.PasswordChar = '*';
            this._password.Size = new System.Drawing.Size(158, 20);
            this._password.TabIndex = 1;
            // 
            // _userLit
            // 
            this._userLit.AutoSize = true;
            this._userLit.Location = new System.Drawing.Point(44, 12);
            this._userLit.Name = "_userLit";
            this._userLit.Size = new System.Drawing.Size(29, 13);
            this._userLit.TabIndex = 1;
            this._userLit.Text = "User";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 146);
            this.Controls.Add(this.panel1);
            this.Name = "login";
            this.Text = "login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox _database;
        private System.Windows.Forms.Label _portLit;
        private System.Windows.Forms.TextBox _server;
        private System.Windows.Forms.TextBox _user;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _databaseLit;
        private System.Windows.Forms.Button _exit;
        private System.Windows.Forms.TextBox _port;
        private System.Windows.Forms.Label _serverLit;
        private System.Windows.Forms.Label _passwordLit;
        private System.Windows.Forms.TextBox _password;
        private System.Windows.Forms.Label _userLit;
        private System.Windows.Forms.Button _login;
    }
}