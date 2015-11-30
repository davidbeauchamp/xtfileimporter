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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._tabs = new System.Windows.Forms.TabControl();
            this._importTab = new System.Windows.Forms.TabPage();
            this._ignoreDuplicates = new System.Windows.Forms.CheckBox();
            this._column = new System.Windows.Forms.ComboBox();
            this._matchAgainstGroup = new System.Windows.Forms.GroupBox();
            this._matchDirectory = new System.Windows.Forms.RadioButton();
            this._matchFileName = new System.Windows.Forms.RadioButton();
            this._overrideColumn = new System.Windows.Forms.CheckBox();
            this._separator = new System.Windows.Forms.ComboBox();
            this._separatorLit = new System.Windows.Forms.Label();
            this._searchMethod = new System.Windows.Forms.ComboBox();
            this._maskLit = new System.Windows.Forms.Label();
            this._mask = new System.Windows.Forms.TextBox();
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
            this._browseDirectory = new System.Windows.Forms.Button();
            this._extractSourceType = new System.Windows.Forms.ComboBox();
            this._extract = new System.Windows.Forms.Button();
            this._extractSourceLit = new System.Windows.Forms.Label();
            this._outputPathLit = new System.Windows.Forms.Label();
            this._outputPath = new System.Windows.Forms.TextBox();
            this._outputPathChooser = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this._tabs.SuspendLayout();
            this._importTab.SuspendLayout();
            this._matchAgainstGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._previewGrid)).BeginInit();
            this._exportTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._tabs, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 462);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _tabs
            // 
            this._tabs.Controls.Add(this._importTab);
            this._tabs.Controls.Add(this._exportTab);
            this._tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabs.Location = new System.Drawing.Point(3, 3);
            this._tabs.Name = "_tabs";
            this._tabs.SelectedIndex = 0;
            this._tabs.Size = new System.Drawing.Size(678, 456);
            this._tabs.TabIndex = 0;
            // 
            // _importTab
            // 
            this._importTab.Controls.Add(this._ignoreDuplicates);
            this._importTab.Controls.Add(this._column);
            this._importTab.Controls.Add(this._matchAgainstGroup);
            this._importTab.Controls.Add(this._overrideColumn);
            this._importTab.Controls.Add(this._separator);
            this._importTab.Controls.Add(this._separatorLit);
            this._importTab.Controls.Add(this._searchMethod);
            this._importTab.Controls.Add(this._maskLit);
            this._importTab.Controls.Add(this._mask);
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
            this._importTab.Size = new System.Drawing.Size(670, 430);
            this._importTab.TabIndex = 0;
            this._importTab.Text = "Bulk Import Files";
            this._importTab.UseVisualStyleBackColor = true;
            // 
            // _ignoreDuplicates
            // 
            this._ignoreDuplicates.AutoSize = true;
            this._ignoreDuplicates.Checked = true;
            this._ignoreDuplicates.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ignoreDuplicates.Location = new System.Drawing.Point(275, 77);
            this._ignoreDuplicates.Name = "_ignoreDuplicates";
            this._ignoreDuplicates.Size = new System.Drawing.Size(128, 17);
            this._ignoreDuplicates.TabIndex = 27;
            this._ignoreDuplicates.Text = "Ignore Duplicate Files";
            this._ignoreDuplicates.UseVisualStyleBackColor = true;
            // 
            // _column
            // 
            this._column.Enabled = false;
            this._column.FormattingEnabled = true;
            this._column.Location = new System.Drawing.Point(484, 106);
            this._column.Name = "_column";
            this._column.Size = new System.Drawing.Size(145, 21);
            this._column.TabIndex = 26;
            // 
            // _matchAgainstGroup
            // 
            this._matchAgainstGroup.Controls.Add(this._matchDirectory);
            this._matchAgainstGroup.Controls.Add(this._matchFileName);
            this._matchAgainstGroup.Location = new System.Drawing.Point(75, 59);
            this._matchAgainstGroup.Name = "_matchAgainstGroup";
            this._matchAgainstGroup.Size = new System.Drawing.Size(194, 41);
            this._matchAgainstGroup.TabIndex = 25;
            this._matchAgainstGroup.TabStop = false;
            this._matchAgainstGroup.Text = "Match Target Using";
            // 
            // _matchDirectory
            // 
            this._matchDirectory.AutoSize = true;
            this._matchDirectory.Location = new System.Drawing.Point(82, 18);
            this._matchDirectory.Name = "_matchDirectory";
            this._matchDirectory.Size = new System.Drawing.Size(98, 17);
            this._matchDirectory.TabIndex = 24;
            this._matchDirectory.TabStop = true;
            this._matchDirectory.Text = "Directory Name";
            this._matchDirectory.UseVisualStyleBackColor = true;
            // 
            // _matchFileName
            // 
            this._matchFileName.AutoSize = true;
            this._matchFileName.Checked = true;
            this._matchFileName.Location = new System.Drawing.Point(6, 18);
            this._matchFileName.Name = "_matchFileName";
            this._matchFileName.Size = new System.Drawing.Size(72, 17);
            this._matchFileName.TabIndex = 22;
            this._matchFileName.TabStop = true;
            this._matchFileName.Text = "File Name";
            this._matchFileName.UseVisualStyleBackColor = true;
            // 
            // _overrideColumn
            // 
            this._overrideColumn.AutoSize = true;
            this._overrideColumn.Location = new System.Drawing.Point(374, 108);
            this._overrideColumn.Name = "_overrideColumn";
            this._overrideColumn.Size = new System.Drawing.Size(104, 17);
            this._overrideColumn.TabIndex = 21;
            this._overrideColumn.Text = "Override Column";
            this._overrideColumn.UseVisualStyleBackColor = true;
            this._overrideColumn.CheckedChanged += new System.EventHandler(this._overrideColumn_CheckedChanged);
            // 
            // _separator
            // 
            this._separator.FormattingEnabled = true;
            this._separator.Items.AddRange(new object[] {
            "_",
            "-",
            "."});
            this._separator.Location = new System.Drawing.Point(311, 106);
            this._separator.Name = "_separator";
            this._separator.Size = new System.Drawing.Size(38, 21);
            this._separator.TabIndex = 20;
            this._separator.Text = "_";
            // 
            // _separatorLit
            // 
            this._separatorLit.AutoSize = true;
            this._separatorLit.Location = new System.Drawing.Point(234, 109);
            this._separatorLit.Name = "_separatorLit";
            this._separatorLit.Size = new System.Drawing.Size(71, 13);
            this._separatorLit.TabIndex = 19;
            this._separatorLit.Text = "Separated By";
            // 
            // _searchMethod
            // 
            this._searchMethod.FormattingEnabled = true;
            this._searchMethod.Items.AddRange(new object[] {
            "Begins With",
            "Equals"});
            this._searchMethod.Location = new System.Drawing.Point(75, 106);
            this._searchMethod.Name = "_searchMethod";
            this._searchMethod.Size = new System.Drawing.Size(153, 21);
            this._searchMethod.TabIndex = 16;
            this._searchMethod.Text = "Begins With";
            this._searchMethod.SelectedIndexChanged += new System.EventHandler(this._searchMethod_SelectedIndexChanged);
            this._searchMethod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._searchMethod_KeyPress);
            // 
            // _maskLit
            // 
            this._maskLit.AutoSize = true;
            this._maskLit.Location = new System.Drawing.Point(448, 9);
            this._maskLit.Name = "_maskLit";
            this._maskLit.Size = new System.Drawing.Size(33, 13);
            this._maskLit.TabIndex = 14;
            this._maskLit.Text = "Mask";
            // 
            // _mask
            // 
            this._mask.Location = new System.Drawing.Point(489, 6);
            this._mask.Name = "_mask";
            this._mask.Size = new System.Drawing.Size(51, 20);
            this._mask.TabIndex = 13;
            this._mask.Text = "*.*";
            // 
            // _attempt
            // 
            this._attempt.Location = new System.Drawing.Point(387, 133);
            this._attempt.Name = "_attempt";
            this._attempt.Size = new System.Drawing.Size(150, 23);
            this._attempt.TabIndex = 12;
            this._attempt.Text = "Attempt Match";
            this._attempt.UseVisualStyleBackColor = true;
            this._attempt.Click += new System.EventHandler(this._attempt_Click);
            // 
            // _preview
            // 
            this._preview.Location = new System.Drawing.Point(231, 133);
            this._preview.Name = "_preview";
            this._preview.Size = new System.Drawing.Size(150, 23);
            this._preview.TabIndex = 11;
            this._preview.Text = "Preview Files";
            this._preview.UseVisualStyleBackColor = true;
            this._preview.Click += new System.EventHandler(this._preview_Click);
            // 
            // _previewGrid
            // 
            this._previewGrid.AllowUserToAddRows = false;
            this._previewGrid.AllowUserToDeleteRows = false;
            this._previewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._previewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._previewGrid.Location = new System.Drawing.Point(0, 162);
            this._previewGrid.Name = "_previewGrid";
            this._previewGrid.ReadOnly = true;
            this._previewGrid.ShowEditingIcon = false;
            this._previewGrid.Size = new System.Drawing.Size(670, 265);
            this._previewGrid.TabIndex = 9;
            // 
            // _recursive
            // 
            this._recursive.AutoSize = true;
            this._recursive.Location = new System.Drawing.Point(456, 33);
            this._recursive.Name = "_recursive";
            this._recursive.Size = new System.Drawing.Size(173, 17);
            this._recursive.TabIndex = 8;
            this._recursive.Text = "Recurse through subdirectories";
            this._recursive.UseVisualStyleBackColor = true;
            // 
            // _attach
            // 
            this._attach.Location = new System.Drawing.Point(75, 133);
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
            this._attachOnly.Location = new System.Drawing.Point(355, 33);
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
            this._saveToDb.Location = new System.Drawing.Point(234, 33);
            this._saveToDb.Name = "_saveToDb";
            this._saveToDb.Size = new System.Drawing.Size(115, 17);
            this._saveToDb.TabIndex = 5;
            this._saveToDb.Text = "Save To Database";
            this._saveToDb.UseVisualStyleBackColor = true;
            // 
            // _importSourceType
            // 
            this._importSourceType.FormattingEnabled = true;
            this._importSourceType.Location = new System.Drawing.Point(75, 32);
            this._importSourceType.Name = "_importSourceType";
            this._importSourceType.Size = new System.Drawing.Size(153, 21);
            this._importSourceType.TabIndex = 4;
            this._importSourceType.Text = "Item";
            this._importSourceType.SelectedIndexChanged += new System.EventHandler(this._importSourceType_SelectedIndexChanged);
            this._importSourceType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._searchMethod_KeyPress);
            // 
            // _importSourceTypeLit
            // 
            this._importSourceTypeLit.AutoSize = true;
            this._importSourceTypeLit.Location = new System.Drawing.Point(15, 35);
            this._importSourceTypeLit.Name = "_importSourceTypeLit";
            this._importSourceTypeLit.Size = new System.Drawing.Size(54, 13);
            this._importSourceTypeLit.TabIndex = 3;
            this._importSourceTypeLit.Text = "Attach To";
            // 
            // _inputPathLit
            // 
            this._inputPathLit.AutoSize = true;
            this._inputPathLit.Location = new System.Drawing.Point(6, 9);
            this._inputPathLit.Name = "_inputPathLit";
            this._inputPathLit.Size = new System.Drawing.Size(66, 13);
            this._inputPathLit.TabIndex = 2;
            this._inputPathLit.Text = "Source Path";
            // 
            // _inputPath
            // 
            this._inputPath.Location = new System.Drawing.Point(75, 6);
            this._inputPath.Name = "_inputPath";
            this._inputPath.Size = new System.Drawing.Size(293, 20);
            this._inputPath.TabIndex = 5;
            // 
            // _inputPathChooser
            // 
            this._inputPathChooser.Location = new System.Drawing.Point(374, 4);
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
            this._exportTab.Size = new System.Drawing.Size(670, 430);
            this._exportTab.TabIndex = 2;
            this._exportTab.Text = "Bulk Export Files";
            this._exportTab.UseVisualStyleBackColor = true;
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
            // _extractSourceType
            // 
            this._extractSourceType.FormattingEnabled = true;
            this._extractSourceType.Location = new System.Drawing.Point(111, 49);
            this._extractSourceType.Name = "_extractSourceType";
            this._extractSourceType.Size = new System.Drawing.Size(153, 21);
            this._extractSourceType.TabIndex = 12;
            this._extractSourceType.Text = "Item";
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
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "main";
            this.Text = "File Importer for xTuple";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.Load += new System.EventHandler(this.main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this._tabs.ResumeLayout(false);
            this._importTab.ResumeLayout(false);
            this._importTab.PerformLayout();
            this._matchAgainstGroup.ResumeLayout(false);
            this._matchAgainstGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._previewGrid)).EndInit();
            this._exportTab.ResumeLayout(false);
            this._exportTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.Label _maskLit;
        private System.Windows.Forms.TextBox _mask;
        private System.Windows.Forms.ComboBox _searchMethod;
        private System.Windows.Forms.ComboBox _separator;
        private System.Windows.Forms.Label _separatorLit;
        private System.Windows.Forms.CheckBox _overrideColumn;
        private System.Windows.Forms.GroupBox _matchAgainstGroup;
        private System.Windows.Forms.RadioButton _matchDirectory;
        private System.Windows.Forms.RadioButton _matchFileName;
        private System.Windows.Forms.ComboBox _column;
        private System.Windows.Forms.CheckBox _ignoreDuplicates;
    }
}