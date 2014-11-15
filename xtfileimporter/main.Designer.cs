namespace xtfileimporter
{
    partial class main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._tabs = new System.Windows.Forms.TabControl();
            this._importTab = new System.Windows.Forms.TabPage();
            this._attempt = new System.Windows.Forms.Button();
            this._preview = new System.Windows.Forms.Button();
            this._previewGrid = new System.Windows.Forms.DataGridView();
            this._recursive = new System.Windows.Forms.CheckBox();
            this._attach = new System.Windows.Forms.Button();
            this._attachOnly = new System.Windows.Forms.RadioButton();
            this._saveToDb = new System.Windows.Forms.RadioButton();
            this._importSourceType = new System.Windows.Forms.ComboBox();
            this._importSourceTypeLit = new System.Windows.Forms.Label();
            this._inputPathLit = new System.Windows.Forms.Label();
            this._inputPath = new System.Windows.Forms.TextBox();
            this._inputPathChooser = new System.Windows.Forms.Button();
            this._exportTab = new System.Windows.Forms.TabPage();
            this._extractSourceType = new System.Windows.Forms.ComboBox();
            this._extract = new System.Windows.Forms.Button();
            this._extractSourceLit = new System.Windows.Forms.Label();
            this._outputPathLit = new System.Windows.Forms.Label();
            this._outputPath = new System.Windows.Forms.TextBox();
            this._outputPathChooser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._databaseLit = new System.Windows.Forms.Label();
            this._database = new System.Windows.Forms.TextBox();
            this._exit = new System.Windows.Forms.Button();
            this._portLit = new System.Windows.Forms.Label();
            this._port = new System.Windows.Forms.TextBox();
            this._serverLit = new System.Windows.Forms.Label();
            this._server = new System.Windows.Forms.TextBox();
            this._passwordLit = new System.Windows.Forms.Label();
            this._password = new System.Windows.Forms.TextBox();
            this._userLit = new System.Windows.Forms.Label();
            this._user = new System.Windows.Forms.TextBox();
            this._browseDirectory = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this._tabs.SuspendLayout();
            this._importTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._previewGrid)).BeginInit();
            this._exportTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._tabs, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 462);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _tabs
            // 
            this._tabs.Controls.Add(this._importTab);
            this._tabs.Controls.Add(this._exportTab);
            this._tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabs.Location = new System.Drawing.Point(3, 78);
            this._tabs.Name = "_tabs";
            this._tabs.SelectedIndex = 0;
            this._tabs.Size = new System.Drawing.Size(678, 381);
            this._tabs.TabIndex = 0;
            // 
            // _importTab
            // 
            this._importTab.Controls.Add(this._attempt);
            this._importTab.Controls.Add(this._preview);
            this._importTab.Controls.Add(this._previewGrid);
            this._importTab.Controls.Add(this._recursive);
            this._importTab.Controls.Add(this._attach);
            this._importTab.Controls.Add(this._attachOnly);
            this._importTab.Controls.Add(this._saveToDb);
            this._importTab.Controls.Add(this._importSourceType);
            this._importTab.Controls.Add(this._importSourceTypeLit);
            this._importTab.Controls.Add(this._inputPathLit);
            this._importTab.Controls.Add(this._inputPath);
            this._importTab.Controls.Add(this._inputPathChooser);
            this._importTab.Location = new System.Drawing.Point(4, 22);
            this._importTab.Name = "_importTab";
            this._importTab.Padding = new System.Windows.Forms.Padding(3);
            this._importTab.Size = new System.Drawing.Size(670, 355);
            this._importTab.TabIndex = 0;
            this._importTab.Text = "Bulk Import Files";
            this._importTab.UseVisualStyleBackColor = true;
            // 
            // _attempt
            // 
            this._attempt.Location = new System.Drawing.Point(390, 76);
            this._attempt.Name = "_attempt";
            this._attempt.Size = new System.Drawing.Size(150, 23);
            this._attempt.TabIndex = 12;
            this._attempt.Text = "Attempt Match";
            this._attempt.UseVisualStyleBackColor = true;
            this._attempt.Click += new System.EventHandler(this._attempt_Click);
            // 
            // _preview
            // 
            this._preview.Location = new System.Drawing.Point(234, 76);
            this._preview.Name = "_preview";
            this._preview.Size = new System.Drawing.Size(150, 23);
            this._preview.TabIndex = 11;
            this._preview.Text = "Preview Files";
            this._preview.UseVisualStyleBackColor = true;
            this._preview.Click += new System.EventHandler(this._preview_Click);
            // 
            // _previewGrid
            // 
            this._previewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._previewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._previewGrid.Location = new System.Drawing.Point(0, 105);
            this._previewGrid.Name = "_previewGrid";
            this._previewGrid.Size = new System.Drawing.Size(670, 247);
            this._previewGrid.TabIndex = 9;
            // 
            // _recursive
            // 
            this._recursive.AutoSize = true;
            this._recursive.Location = new System.Drawing.Point(427, 25);
            this._recursive.Name = "_recursive";
            this._recursive.Size = new System.Drawing.Size(173, 17);
            this._recursive.TabIndex = 8;
            this._recursive.Text = "Recurse through subdirectories";
            this._recursive.UseVisualStyleBackColor = true;
            // 
            // _attach
            // 
            this._attach.Location = new System.Drawing.Point(78, 76);
            this._attach.Name = "_attach";
            this._attach.Size = new System.Drawing.Size(150, 23);
            this._attach.TabIndex = 7;
            this._attach.Text = "Attach Files";
            this._attach.UseVisualStyleBackColor = true;
            this._attach.Click += new System.EventHandler(this._attach_Click);
            // 
            // _attachOnly
            // 
            this._attachOnly.AutoSize = true;
            this._attachOnly.Checked = true;
            this._attachOnly.Location = new System.Drawing.Point(355, 50);
            this._attachOnly.Name = "_attachOnly";
            this._attachOnly.Size = new System.Drawing.Size(80, 17);
            this._attachOnly.TabIndex = 6;
            this._attachOnly.TabStop = true;
            this._attachOnly.Text = "Attach Only";
            this._attachOnly.UseVisualStyleBackColor = true;
            // 
            // _saveToDb
            // 
            this._saveToDb.AutoSize = true;
            this._saveToDb.Location = new System.Drawing.Point(234, 50);
            this._saveToDb.Name = "_saveToDb";
            this._saveToDb.Size = new System.Drawing.Size(115, 17);
            this._saveToDb.TabIndex = 5;
            this._saveToDb.Text = "Save To Database";
            this._saveToDb.UseVisualStyleBackColor = true;
            // 
            // _importSourceType
            // 
            this._importSourceType.FormattingEnabled = true;
            this._importSourceType.Items.AddRange(new object[] {
            "Items",
            "CRM Accounts",
            "Sales Order",
            "Lot/Serial",
            "Work Order",
            "Purchase Order",
            "Vendor"});
            this._importSourceType.Location = new System.Drawing.Point(75, 49);
            this._importSourceType.Name = "_importSourceType";
            this._importSourceType.Size = new System.Drawing.Size(153, 21);
            this._importSourceType.TabIndex = 4;
            this._importSourceType.Text = "Items";
            // 
            // _importSourceTypeLit
            // 
            this._importSourceTypeLit.AutoSize = true;
            this._importSourceTypeLit.Location = new System.Drawing.Point(15, 52);
            this._importSourceTypeLit.Name = "_importSourceTypeLit";
            this._importSourceTypeLit.Size = new System.Drawing.Size(54, 13);
            this._importSourceTypeLit.TabIndex = 3;
            this._importSourceTypeLit.Text = "Attach To";
            // 
            // _inputPathLit
            // 
            this._inputPathLit.AutoSize = true;
            this._inputPathLit.Location = new System.Drawing.Point(3, 26);
            this._inputPathLit.Name = "_inputPathLit";
            this._inputPathLit.Size = new System.Drawing.Size(66, 13);
            this._inputPathLit.TabIndex = 2;
            this._inputPathLit.Text = "Source Path";
            // 
            // _inputPath
            // 
            this._inputPath.Location = new System.Drawing.Point(75, 23);
            this._inputPath.Name = "_inputPath";
            this._inputPath.Size = new System.Drawing.Size(293, 20);
            this._inputPath.TabIndex = 5;
            // 
            // _inputPathChooser
            // 
            this._inputPathChooser.Location = new System.Drawing.Point(374, 21);
            this._inputPathChooser.Name = "_inputPathChooser";
            this._inputPathChooser.Size = new System.Drawing.Size(47, 23);
            this._inputPathChooser.TabIndex = 6;
            this._inputPathChooser.Text = "...";
            this._inputPathChooser.UseVisualStyleBackColor = true;
            this._inputPathChooser.Click += new System.EventHandler(this._inputPathChooser_Click);
            // 
            // _exportTab
            // 
            this._exportTab.Controls.Add(this._browseDirectory);
            this._exportTab.Controls.Add(this._extractSourceType);
            this._exportTab.Controls.Add(this._extract);
            this._exportTab.Controls.Add(this._extractSourceLit);
            this._exportTab.Controls.Add(this._outputPathLit);
            this._exportTab.Controls.Add(this._outputPath);
            this._exportTab.Controls.Add(this._outputPathChooser);
            this._exportTab.Location = new System.Drawing.Point(4, 22);
            this._exportTab.Name = "_exportTab";
            this._exportTab.Padding = new System.Windows.Forms.Padding(3);
            this._exportTab.Size = new System.Drawing.Size(670, 355);
            this._exportTab.TabIndex = 2;
            this._exportTab.Text = "Bulk Export Files";
            this._exportTab.UseVisualStyleBackColor = true;
            // 
            // _extractSourceType
            // 
            this._extractSourceType.FormattingEnabled = true;
            this._extractSourceType.Items.AddRange(new object[] {
            "Items",
            "CRM Accounts",
            "Sales Order",
            "Lot/Serial",
            "Work Order",
            "Purchase Order",
            "Vendor"});
            this._extractSourceType.Location = new System.Drawing.Point(111, 49);
            this._extractSourceType.Name = "_extractSourceType";
            this._extractSourceType.Size = new System.Drawing.Size(153, 21);
            this._extractSourceType.TabIndex = 12;
            this._extractSourceType.Text = "Items";
            // 
            // _extract
            // 
            this._extract.Location = new System.Drawing.Point(111, 76);
            this._extract.Name = "_extract";
            this._extract.Size = new System.Drawing.Size(150, 23);
            this._extract.TabIndex = 7;
            this._extract.Text = "Extract Files";
            this._extract.UseVisualStyleBackColor = true;
            this._extract.Click += new System.EventHandler(this._extract_Click);
            // 
            // _extractSourceLit
            // 
            this._extractSourceLit.AutoSize = true;
            this._extractSourceLit.Location = new System.Drawing.Point(34, 52);
            this._extractSourceLit.Name = "_extractSourceLit";
            this._extractSourceLit.Size = new System.Drawing.Size(66, 13);
            this._extractSourceLit.TabIndex = 3;
            this._extractSourceLit.Text = "Extract From";
            // 
            // _outputPathLit
            // 
            this._outputPathLit.AutoSize = true;
            this._outputPathLit.Location = new System.Drawing.Point(15, 26);
            this._outputPathLit.Name = "_outputPathLit";
            this._outputPathLit.Size = new System.Drawing.Size(85, 13);
            this._outputPathLit.TabIndex = 2;
            this._outputPathLit.Text = "Destination Path";
            // 
            // _outputPath
            // 
            this._outputPath.Location = new System.Drawing.Point(111, 23);
            this._outputPath.Name = "_outputPath";
            this._outputPath.Size = new System.Drawing.Size(293, 20);
            this._outputPath.TabIndex = 1;
            // 
            // _outputPathChooser
            // 
            this._outputPathChooser.Location = new System.Drawing.Point(410, 21);
            this._outputPathChooser.Name = "_outputPathChooser";
            this._outputPathChooser.Size = new System.Drawing.Size(47, 23);
            this._outputPathChooser.TabIndex = 0;
            this._outputPathChooser.Text = "...";
            this._outputPathChooser.UseVisualStyleBackColor = true;
            this._outputPathChooser.Click += new System.EventHandler(this._outputPathChooser_Click);
            // 
            // panel1
            // 
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
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 69);
            this.panel1.TabIndex = 1;
            // 
            // _databaseLit
            // 
            this._databaseLit.AutoSize = true;
            this._databaseLit.Location = new System.Drawing.Point(194, 38);
            this._databaseLit.Name = "_databaseLit";
            this._databaseLit.Size = new System.Drawing.Size(53, 13);
            this._databaseLit.TabIndex = 12;
            this._databaseLit.Text = "Database";
            // 
            // _database
            // 
            this._database.Location = new System.Drawing.Point(250, 35);
            this._database.Name = "_database";
            this._database.Size = new System.Drawing.Size(158, 20);
            this._database.TabIndex = 3;
            // 
            // _exit
            // 
            this._exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._exit.Location = new System.Drawing.Point(594, 7);
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(75, 23);
            this._exit.TabIndex = 10;
            this._exit.Text = "Exit";
            this._exit.UseVisualStyleBackColor = true;
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // _portLit
            // 
            this._portLit.AutoSize = true;
            this._portLit.Location = new System.Drawing.Point(428, 38);
            this._portLit.Name = "_portLit";
            this._portLit.Size = new System.Drawing.Size(26, 13);
            this._portLit.TabIndex = 7;
            this._portLit.Text = "Port";
            // 
            // _port
            // 
            this._port.Location = new System.Drawing.Point(460, 35);
            this._port.Name = "_port";
            this._port.Size = new System.Drawing.Size(100, 20);
            this._port.TabIndex = 4;
            this._port.Text = "5432";
            // 
            // _serverLit
            // 
            this._serverLit.AutoSize = true;
            this._serverLit.Location = new System.Drawing.Point(206, 12);
            this._serverLit.Name = "_serverLit";
            this._serverLit.Size = new System.Drawing.Size(38, 13);
            this._serverLit.TabIndex = 5;
            this._serverLit.Text = "Server";
            // 
            // _server
            // 
            this._server.Location = new System.Drawing.Point(250, 9);
            this._server.Name = "_server";
            this._server.Size = new System.Drawing.Size(158, 20);
            this._server.TabIndex = 2;
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
            this._password.Size = new System.Drawing.Size(100, 20);
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
            // _user
            // 
            this._user.Location = new System.Drawing.Point(79, 9);
            this._user.Name = "_user";
            this._user.Size = new System.Drawing.Size(100, 20);
            this._user.TabIndex = 0;
            // 
            // _browseDirectory
            // 
            this._browseDirectory.Location = new System.Drawing.Point(463, 21);
            this._browseDirectory.Name = "_browseDirectory";
            this._browseDirectory.Size = new System.Drawing.Size(93, 23);
            this._browseDirectory.TabIndex = 13;
            this._browseDirectory.Text = "Browse Directory";
            this._browseDirectory.UseVisualStyleBackColor = true;
            this._browseDirectory.Click += new System.EventHandler(this._browseDirectory_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "File Importer for xTuple";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.Load += new System.EventHandler(this.main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this._tabs.ResumeLayout(false);
            this._importTab.ResumeLayout(false);
            this._importTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._previewGrid)).EndInit();
            this._exportTab.ResumeLayout(false);
            this._exportTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _exit;
        private System.Windows.Forms.Label _portLit;
        private System.Windows.Forms.TextBox _port;
        private System.Windows.Forms.Label _serverLit;
        private System.Windows.Forms.TextBox _server;
        private System.Windows.Forms.Label _passwordLit;
        private System.Windows.Forms.TextBox _password;
        private System.Windows.Forms.Label _userLit;
        private System.Windows.Forms.TextBox _user;
        private System.Windows.Forms.Label _databaseLit;
        private System.Windows.Forms.TextBox _database;
        private System.Windows.Forms.TabControl _tabs;
        private System.Windows.Forms.TabPage _importTab;
        private System.Windows.Forms.Button _attempt;
        private System.Windows.Forms.Button _preview;
        private System.Windows.Forms.DataGridView _previewGrid;
        private System.Windows.Forms.CheckBox _recursive;
        private System.Windows.Forms.Button _attach;
        private System.Windows.Forms.RadioButton _attachOnly;
        private System.Windows.Forms.RadioButton _saveToDb;
        private System.Windows.Forms.ComboBox _importSourceType;
        private System.Windows.Forms.Label _importSourceTypeLit;
        private System.Windows.Forms.Label _inputPathLit;
        private System.Windows.Forms.TextBox _inputPath;
        private System.Windows.Forms.Button _inputPathChooser;
        private System.Windows.Forms.TabPage _exportTab;
        private System.Windows.Forms.Button _extract;
        private System.Windows.Forms.Label _extractSourceLit;
        private System.Windows.Forms.Label _outputPathLit;
        private System.Windows.Forms.TextBox _outputPath;
        private System.Windows.Forms.Button _outputPathChooser;
        private System.Windows.Forms.ComboBox _extractSourceType;
        private System.Windows.Forms.Button _browseDirectory;

    }
}