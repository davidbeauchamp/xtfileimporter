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
            this._import = new System.Windows.Forms.Button();
            this._attachOnly = new System.Windows.Forms.RadioButton();
            this._saveToDb = new System.Windows.Forms.RadioButton();
            this._purpose = new System.Windows.Forms.ComboBox();
            this._purposeLit = new System.Windows.Forms.Label();
            this.inputPathLabel = new System.Windows.Forms.Label();
            this._inputPath = new System.Windows.Forms.TextBox();
            this.inputPathButton = new System.Windows.Forms.Button();
            this._exportTab = new System.Windows.Forms.TabPage();
            this._previewExtract = new System.Windows.Forms.Button();
            this._previewExtractGrid = new System.Windows.Forms.DataGridView();
            this._extract = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._outputPath = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._database = new System.Windows.Forms.TextBox();
            this._exit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._port = new System.Windows.Forms.TextBox();
            this._serverLit = new System.Windows.Forms.Label();
            this._server = new System.Windows.Forms.TextBox();
            this._passwordLit = new System.Windows.Forms.Label();
            this._password = new System.Windows.Forms.TextBox();
            this._userLit = new System.Windows.Forms.Label();
            this._user = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this._tabs.SuspendLayout();
            this._importTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._previewGrid)).BeginInit();
            this._exportTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._previewExtractGrid)).BeginInit();
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
            this._importTab.Controls.Add(this._import);
            this._importTab.Controls.Add(this._attachOnly);
            this._importTab.Controls.Add(this._saveToDb);
            this._importTab.Controls.Add(this._purpose);
            this._importTab.Controls.Add(this._purposeLit);
            this._importTab.Controls.Add(this.inputPathLabel);
            this._importTab.Controls.Add(this._inputPath);
            this._importTab.Controls.Add(this.inputPathButton);
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
            this._attempt.Location = new System.Drawing.Point(387, 99);
            this._attempt.Name = "_attempt";
            this._attempt.Size = new System.Drawing.Size(150, 23);
            this._attempt.TabIndex = 12;
            this._attempt.Text = "Attempt Item Match";
            this._attempt.UseVisualStyleBackColor = true;
            this._attempt.Click += new System.EventHandler(this._attempt_Click);
            // 
            // _preview
            // 
            this._preview.Location = new System.Drawing.Point(231, 99);
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
            this._previewGrid.Location = new System.Drawing.Point(0, 128);
            this._previewGrid.Name = "_previewGrid";
            this._previewGrid.Size = new System.Drawing.Size(670, 224);
            this._previewGrid.TabIndex = 9;
            // 
            // _recursive
            // 
            this._recursive.AutoSize = true;
            this._recursive.Location = new System.Drawing.Point(75, 76);
            this._recursive.Name = "_recursive";
            this._recursive.Size = new System.Drawing.Size(173, 17);
            this._recursive.TabIndex = 8;
            this._recursive.Text = "Recurse through subdirectories";
            this._recursive.UseVisualStyleBackColor = true;
            // 
            // _import
            // 
            this._import.Location = new System.Drawing.Point(75, 99);
            this._import.Name = "_import";
            this._import.Size = new System.Drawing.Size(150, 23);
            this._import.TabIndex = 7;
            this._import.Text = "Attach Files";
            this._import.UseVisualStyleBackColor = true;
            this._import.Click += new System.EventHandler(this._import_Click);
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
            this._attachOnly.CheckedChanged += new System.EventHandler(this._checkedChanged);
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
            this._saveToDb.CheckedChanged += new System.EventHandler(this._checkedChanged);
            // 
            // _purpose
            // 
            this._purpose.FormattingEnabled = true;
            this._purpose.Items.AddRange(new object[] {
            "Items"});
            this._purpose.Location = new System.Drawing.Point(75, 49);
            this._purpose.Name = "_purpose";
            this._purpose.Size = new System.Drawing.Size(153, 21);
            this._purpose.TabIndex = 4;
            this._purpose.Text = "Items";
            // 
            // _purposeLit
            // 
            this._purposeLit.AutoSize = true;
            this._purposeLit.Location = new System.Drawing.Point(15, 52);
            this._purposeLit.Name = "_purposeLit";
            this._purposeLit.Size = new System.Drawing.Size(54, 13);
            this._purposeLit.TabIndex = 3;
            this._purposeLit.Text = "Attach To";
            // 
            // inputPathLabel
            // 
            this.inputPathLabel.AutoSize = true;
            this.inputPathLabel.Location = new System.Drawing.Point(3, 26);
            this.inputPathLabel.Name = "inputPathLabel";
            this.inputPathLabel.Size = new System.Drawing.Size(66, 13);
            this.inputPathLabel.TabIndex = 2;
            this.inputPathLabel.Text = "Source Path";
            // 
            // _inputPath
            // 
            this._inputPath.Location = new System.Drawing.Point(75, 23);
            this._inputPath.Name = "_inputPath";
            this._inputPath.Size = new System.Drawing.Size(293, 20);
            this._inputPath.TabIndex = 1;
            // 
            // inputPathButton
            // 
            this.inputPathButton.Location = new System.Drawing.Point(374, 21);
            this.inputPathButton.Name = "inputPathButton";
            this.inputPathButton.Size = new System.Drawing.Size(47, 23);
            this.inputPathButton.TabIndex = 0;
            this.inputPathButton.Text = "...";
            this.inputPathButton.UseVisualStyleBackColor = true;
            this.inputPathButton.Click += new System.EventHandler(this.inputPathButton_Click);
            // 
            // _exportTab
            // 
            this._exportTab.Controls.Add(this._previewExtract);
            this._exportTab.Controls.Add(this._previewExtractGrid);
            this._exportTab.Controls.Add(this._extract);
            this._exportTab.Controls.Add(this.comboBox1);
            this._exportTab.Controls.Add(this.label2);
            this._exportTab.Controls.Add(this.label4);
            this._exportTab.Controls.Add(this._outputPath);
            this._exportTab.Controls.Add(this.button4);
            this._exportTab.Location = new System.Drawing.Point(4, 22);
            this._exportTab.Name = "_exportTab";
            this._exportTab.Padding = new System.Windows.Forms.Padding(3);
            this._exportTab.Size = new System.Drawing.Size(670, 355);
            this._exportTab.TabIndex = 2;
            this._exportTab.Text = "Bulk Export Files";
            this._exportTab.UseVisualStyleBackColor = true;
            // 
            // _previewExtract
            // 
            this._previewExtract.Location = new System.Drawing.Point(267, 76);
            this._previewExtract.Name = "_previewExtract";
            this._previewExtract.Size = new System.Drawing.Size(150, 23);
            this._previewExtract.TabIndex = 11;
            this._previewExtract.Text = "Preview Files";
            this._previewExtract.UseVisualStyleBackColor = true;
            this._previewExtract.Click += new System.EventHandler(this._previewExtract_Click);
            // 
            // _previewExtractGrid
            // 
            this._previewExtractGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._previewExtractGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._previewExtractGrid.Location = new System.Drawing.Point(0, 105);
            this._previewExtractGrid.Name = "_previewExtractGrid";
            this._previewExtractGrid.Size = new System.Drawing.Size(670, 247);
            this._previewExtractGrid.TabIndex = 9;
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Items"});
            this.comboBox1.Location = new System.Drawing.Point(111, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Extract From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Destination Path";
            // 
            // _outputPath
            // 
            this._outputPath.Location = new System.Drawing.Point(111, 23);
            this._outputPath.Name = "_outputPath";
            this._outputPath.Size = new System.Drawing.Size(293, 20);
            this._outputPath.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(410, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._database);
            this.panel1.Controls.Add(this._exit);
            this.panel1.Controls.Add(this.label3);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Database";
            // 
            // _database
            // 
            this._database.Location = new System.Drawing.Point(250, 35);
            this._database.Name = "_database";
            this._database.Size = new System.Drawing.Size(158, 20);
            this._database.TabIndex = 11;
            // 
            // _exit
            // 
            this._exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._exit.Location = new System.Drawing.Point(594, 7);
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(75, 23);
            this._exit.TabIndex = 10;
            this._exit.Text = "Exit";
            this._exit.UseVisualStyleBackColor = true;
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port";
            // 
            // _port
            // 
            this._port.Location = new System.Drawing.Point(460, 35);
            this._port.Name = "_port";
            this._port.Size = new System.Drawing.Size(100, 20);
            this._port.TabIndex = 6;
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
            this._server.TabIndex = 4;
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
            this._password.TabIndex = 2;
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
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "File Importer for xTuple";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.renderer_FormClosing);
            this.Load += new System.EventHandler(this.main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this._tabs.ResumeLayout(false);
            this._importTab.ResumeLayout(false);
            this._importTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._previewGrid)).EndInit();
            this._exportTab.ResumeLayout(false);
            this._exportTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._previewExtractGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _exit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _port;
        private System.Windows.Forms.Label _serverLit;
        private System.Windows.Forms.TextBox _server;
        private System.Windows.Forms.Label _passwordLit;
        private System.Windows.Forms.TextBox _password;
        private System.Windows.Forms.Label _userLit;
        private System.Windows.Forms.TextBox _user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _database;
        private System.Windows.Forms.TabControl _tabs;
        private System.Windows.Forms.TabPage _importTab;
        private System.Windows.Forms.Button _attempt;
        private System.Windows.Forms.Button _preview;
        private System.Windows.Forms.DataGridView _previewGrid;
        private System.Windows.Forms.CheckBox _recursive;
        private System.Windows.Forms.Button _import;
        private System.Windows.Forms.RadioButton _attachOnly;
        private System.Windows.Forms.RadioButton _saveToDb;
        private System.Windows.Forms.ComboBox _purpose;
        private System.Windows.Forms.Label _purposeLit;
        private System.Windows.Forms.Label inputPathLabel;
        private System.Windows.Forms.TextBox _inputPath;
        private System.Windows.Forms.Button inputPathButton;
        private System.Windows.Forms.TabPage _exportTab;
        private System.Windows.Forms.Button _previewExtract;
        private System.Windows.Forms.DataGridView _previewExtractGrid;
        private System.Windows.Forms.Button _extract;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _outputPath;
        private System.Windows.Forms.Button button4;

    }
}