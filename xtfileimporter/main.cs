using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using xtfileimporter.Properties;
using Npgsql;
using System.IO;
using NpgsqlTypes;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;

namespace xtfileimporter
{
    public partial class main : Form
    {
        #region arguments
        // used for command line arguments
        // some of it is plumbing for an upcoming build
        string username = String.Empty;
        string password = String.Empty;
        string database = String.Empty;
        string server = String.Empty;
        string sourcetype = String.Empty;
        string targettype = String.Empty;
        string outputpath = String.Empty;
        string inputpath = String.Empty;
        string mode = String.Empty;
        int port = 0;
        bool headless = false;
        bool recursive = false;
        #endregion

        // used to store the file list
        DataTable files = new DataTable();
        // string that gets built and displayed at the end of the run
        string output = String.Empty;

        #region type map
        //// this whole thing is made useless by the source table expanded in v4.9.0 of xTuple. I will be replacing this with that table soon
        /// <summary>
        /// Array of supported document types
        /// </summary>
        /// <para>Multidimensional array of supported document types. 
        /// Columns are:
        /// 0: Document  
        /// 1: Document Type Abbreviation
        /// 2: Query to retrieve source id given the document number
        /// </para> 
        string[,] types = new string[,] { {"Items",         "I",        "SELECT item_id     FROM item       WHERE {0}  = :source_number;", "item_number",         "item"},
                                          {"CRMAccounts",   "CRMA",     "SELECT crmacct_id  FROM crmacct    WHERE {0}  = :source_number;", "crmacct_number",      "crmacct"},
                                          {"SalesOrder",    "S",        "SELECT cohead_id   FROM cohead     WHERE {0}  = :source_number;", "cohead_number",       "cohead"},
                                          {"LotSerial",     "LS",       "SELECT ls_id       FROM ls         WHERE {0}  = :source_number;", "ls_number",           "ls"},
                                          {"WorkOrder",     "W",        "SELECT wo_id       FROM wo         WHERE {0}  = :source_number;", "wo_number::text || '-' || wo_subnumber::text",     "wo"},
                                          {"PurchaseOrder", "P",        "SELECT pohead_id   FROM pohead     WHERE {0}  = :source_number;", "pohead_number",       "pohead"},
                                          {"Vendor",        "V",        "SELECT vend_id     FROM vendinfo   WHERE {0}  = :source_number;", "vend_number",         "vendinfo"},
                                          {"Contacts",      "T",        "SELECT cntct_id    FROM cntct      WHERE {0}  = :source_number;", "cntct_number",        "cntct"},
                                          {"Invoice",       "INV",      "SELECT invchead_id FROM invchead   WHERE {0}  = :source_number;", "invchead_invcnumber", "invchead"},
                                          {"Project",       "J",        "SELECT prj_id      FROM prj        WHERE {0}  = :source_number;", "prj_number",          "prj"},
                                          {"Quote",         "Q",        "SELECT quhead_id   FROM quhead     WHERE {0}  = :source_number;", "quhead_number",       "quhead"},
                                          {"Incident",      "INCDT",    "SELECT vend_id     FROM vendinfo   WHERE {0}  = :source_number;", "vend_number",         "vendinfo"}
        };

        // these constants represent the columns in the above types array
        int SOURCE = 0,
            SOURCETYPE = 1,
            SOURCEQUERY = 2,
            SOURCECOLUMN = 3,
            SOURCETABLE = 4;

        #endregion

        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args">arguments as passed in via command line</param>
        /// <returns>main</returns>
        public main(string[] _args)
        {
            InitializeComponent();

            try
            {
                if (_args.Length > 0)
                {
                    processArguments(_args);
                }

                // populate comboboxes
                addTypeChoices();

                // prepare the DataTable with the columns we will use
                files.Columns.Add(new DataColumn("fileName"));
                files.Columns.Add(new DataColumn("fileNameNoExt"));
                files.Columns.Add(new DataColumn("filePath"));
                files.Columns.Add(new DataColumn("sourceNumber"));
            }
            catch (Exception e)
            {
                 MessageBox.Show(e.ToString(), "Error Starting file importer");
            }
        }

        #region helper

        /// <summary>
        /// Method to build the global connection string. Used in case people make changes in between operations
        /// </summary>
        /// <returns>string</returns>
        private string getConnectionString()
        {if (String.IsNullOrEmpty(_server.Text) || String.IsNullOrEmpty(_port.Text) || String.IsNullOrEmpty(_user.Text) || String.IsNullOrEmpty(_password.Text) || String.IsNullOrEmpty(_database.Text))
            {
                MessageBox.Show("Please completely fill out server information before continuing");
                return null;
            }
           return String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                _server.Text, _port.Text, _user.Text, _password.Text, _database.Text);
        }

        /// <summary>
        /// Method to return a NpgsqlCommand with the right query for the chosen input sourceType
        /// Only used for file imports, not exports
        /// </summary>
        /// <param name="conn">NpgsqlConnection to use for the command</param>
        /// <returns>NpgsqlCommand</returns>
        private NpgsqlCommand getSourceCommand(NpgsqlConnection conn)
        {
            string sourceQuery = types[_importSourceType.Items.IndexOf(_importSourceType.Text), SOURCEQUERY];
            if (_overrideColumn.Checked)
            {
                sourceQuery = String.Format(sourceQuery, _column.Text);
            }
            else
            {
                sourceQuery = String.Format(sourceQuery, types[_importSourceType.Items.IndexOf(_importSourceType.Text), SOURCECOLUMN]);
            }

            NpgsqlCommand sourceCommand = new NpgsqlCommand(sourceQuery, conn);
            sourceCommand.Parameters.Add(new NpgsqlParameter("source_number", NpgsqlDbType.Text));
            return sourceCommand;
        }
              
        /// <summary>
        /// Method to get byte array from a file
        /// </summary>
        /// <param name="_fileName">File name to get byte array</param>
        /// <returns>Byte Array</returns>
        private byte[] fileToByteArray(string _fileName)
        {
            byte[] _buffer = null;

            try
            {
                // Open file for reading
                System.IO.FileStream _fileStream = new System.IO.FileStream(_fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                // attach filestream to binary reader
                System.IO.BinaryReader _binaryReader = new System.IO.BinaryReader(_fileStream);

                // get total byte length of the file
                long _totalBytes = new System.IO.FileInfo(_fileName).Length;

                // read entire file into buffer
                _buffer = _binaryReader.ReadBytes((Int32)_totalBytes);

                // close file reader
                _fileStream.Close();
                _fileStream.Dispose();
                _binaryReader.Close();
            }
            catch (Exception e)
            {
                // Error
                Console.WriteLine(e.ToString());
            }

            return _buffer;
        }

        #endregion

        #region meta

        /// <summary>
        /// Adds the available types to the comboboxes
        /// </summary>
        /// <returns>void</returns>
        private void addTypeChoices()
        {
            for (int i = 0; i < types.GetLength(0); i += 1 )
            {
                _importSourceType.Items.Add(types[i, SOURCE]);
                _extractSourceType.Items.Add(types[i, SOURCE]);
            }
            _column.Text = types[_importSourceType.Items.IndexOf(_importSourceType.Text), SOURCECOLUMN];
        }

        /// <summary>
        /// Method to pass out any arguments passed via the command line
        /// should be in the format --argument=value
        /// --help will display a list of valid arguments
        /// </summary>
        /// <param name="args">arguments as passed in from the command line</param>
        /// <returns>void</returns>
        private void processArguments(string[] args)
        {
            try
            {
                foreach (string s in args)
                {
                    if (s.ToLower().Contains("--help"))
                    {
                        showHelp();
                        Environment.Exit(0);
                    }
                    else if (s.ToLower().Contains("--version"))
                    {
                        showVersion();
                        Environment.Exit(0);
                    }
                    else if (s.ToLower().Contains("--username="))
                    {
                        this.username = s.Remove(0, 11);
                        _user.Text = this.username;
                    }
                    else if (s.ToLower().Contains("--password="))
                    {
                        this.password = s.Remove(0, 11);
                        _password.Text = this.password;
                    }
                    else if (s.ToLower().Contains("--server="))
                    {
                        this.server = s.Remove(0, 9);
                        _server.Text = this.server;
                    }
                    else if (s.ToLower().Contains("--database="))
                    {
                        this.database = s.Remove(0, 11);
                        _database.Text = this.database;
                    }
                    else if (s.ToLower().Contains("--port="))
                    {
                        this.port = Convert.ToInt16(s.Remove(0, 7));
                        _port.Text = this.port.ToString();
                    }
                    else if (s.ToLower().Contains("--headless"))
                    {
                        this.headless = true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
                Environment.Exit(-1);
            }
        }
        private void showHelp()
        {
            MessageBox.Show(this, @"xTuple File Importer Command Line Arguments" + Environment.NewLine + Environment.NewLine
                      + "--help: Show this message, then exit." + Environment.NewLine
                      + "--version: Show version information, then exit." + Environment.NewLine
                      + "--server=<SERVER>: The PostgreSQL server. Required in headless mode." + Environment.NewLine
                      + "--username=<USERNAME>: The PostgreSQL username. Required in headless mode." + Environment.NewLine
                      + "--password=<PASSWORD>: The PostgreSQL password. Required in headless mode." + Environment.NewLine
                      + "--database=<DATABSE>: The xTuple database you want to import into. Required in headless mode." + Environment.NewLine
                      + "--port=<PORT>: The PostgreSQL server port for." + Environment.NewLine
                      + "--headless: Forces headless operation.", "xtfileimporter " + AssemblyInfo.Version);
        }
        private void showVersion()
        {
            MessageBox.Show(this, @"Version: " + AssemblyInfo.Version + " Built On: " + AssemblyInfo.getBuildDate().ToString() + Environment.NewLine
                      + "Written by David Beauchamp" + Environment.NewLine
                      + "david@xtuple.com" + Environment.NewLine, "File importer for xTuple ERP");
        }
        private void loadSettings()
        {
            // window location
            if (Settings.Default.WindowLocation != null)
            {
                this.Location = Settings.Default.WindowLocation;
            }

            // window size
            if (Settings.Default.WindowSize != null)
            {
                this.Size = Settings.Default.WindowSize;
            }
        }
        private void saveSettings()
        {
            // save window location to app settings
            Settings.Default.WindowLocation = this.Location;

            // save window size to app settings
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowSize = this.Size;
            }
            else
            {
                Settings.Default.WindowSize = this.RestoreBounds.Size;
            }

            Settings.Default.Save();
        }

        #endregion

        #region event handlers

        private void main_Load(object sender, EventArgs e)
        {
            this.Text = "xtfileimporter " + AssemblyInfo.Version;
            loadSettings();
        }
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }
        private void _exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void _attach_Click(object sender, EventArgs e)
        {
            new Thread(delegate()
            {
                this.Invoke((MethodInvoker)delegate
                {
                    attachFiles(types[_importSourceType.Items.IndexOf(_importSourceType.Text), SOURCETYPE]);
                });
                
            }).Start();
            
        }
        private void _preview_Click(object sender, EventArgs e)
        {
            previewFiles();
        }
        private void _attempt_Click(object sender, EventArgs e)
        {
            new Thread(delegate()
            {
                this.Invoke((MethodInvoker)delegate
                {
                    attemptmatch();
                });

            }).Start();
        }
        private void _extract_Click(object sender, EventArgs e)
        {
            new Thread(delegate()
            {
                this.Invoke((MethodInvoker)delegate
                {
                    extractFiles(types[_extractSourceType.Items.IndexOf(_extractSourceType.Text), SOURCETYPE]);
                });

            }).Start();
        }
        private void _browseDirectory_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _outputPath.Text);
        }
        private void _inputPathChooser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _inputPath.Text = fd.SelectedPath;
            }
        }
        private void _outputPathChooser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _outputPath.Text = fd.SelectedPath;
            }
        }

        #endregion

        #region main

        /// <summary>
        /// Method attach files to xTuple ERP documents for the chosen sourceType.
        /// </summary>
        /// <param name="sourceType">string source type from documents.cpp in qt-client/widgets</param>
        /// <returns>void</returns>
        private void attachFiles(string sourceType)
        {
            output = "Started " + DateTime.Now + Environment.NewLine;
            string[] filesFound;
            string insertSourceQuery = "";
            bool saveToDb = _saveToDb.Checked;

            Int32 target_id = 0;
            Int32 source_id = 0;

            NpgsqlConnection conn = new NpgsqlConnection(getConnectionString());
            if (saveToDb)
            {
                insertSourceQuery = "INSERT INTO file (file_title, file_stream, file_descrip) VALUES (:file_title, :file_stream, :file_descrip) RETURNING file_id;";
            }
            else
            {
                insertSourceQuery = "INSERT INTO urlinfo (url_title, url_url) VALUES (:url_title, :url_url) RETURNING url_id;";
            }

            string insertDocassQuery = "INSERT INTO docass (docass_source_id, docass_source_type, docass_target_id, docass_target_type, docass_purpose) "
                                                 +" VALUES (:docass_source_id, :docass_source_type, :docass_target_id, :docass_target_type, 'S');";

            try
            {
                if (String.IsNullOrEmpty(_inputPath.Text))
                {
                    MessageBox.Show("Input path is empty");
                    return;
                }
                else
                {

                    filesFound = Directory.GetFiles(_inputPath.Text, String.IsNullOrEmpty(_mask.Text) ? "*.*" : _mask.Text, 
                                                    _recursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

                    progress progress = new progress();
                    progress.setMaxValue(filesFound.Length);
                    progress.Show();
                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand(insertSourceQuery, conn);
                    if (saveToDb)
                    {
                        command.Parameters.Add(new NpgsqlParameter("file_title", NpgsqlDbType.Text));
                        command.Parameters.Add(new NpgsqlParameter("file_stream", NpgsqlDbType.Bytea));
                        command.Parameters.Add(new NpgsqlParameter("file_descrip", NpgsqlDbType.Text));
                    }
                    else
                    {
                        command.Parameters.Add(new NpgsqlParameter("url_title", NpgsqlDbType.Text));
                        command.Parameters.Add(new NpgsqlParameter("url_url", NpgsqlDbType.Text));
                    }
                    
                    NpgsqlCommand docassCommand = new NpgsqlCommand(insertDocassQuery, conn);
                    docassCommand.Parameters.Add(new NpgsqlParameter("docass_source_id", NpgsqlDbType.Integer));
                    docassCommand.Parameters.Add(new NpgsqlParameter("docass_source_type", NpgsqlDbType.Text));
                    docassCommand.Parameters.Add(new NpgsqlParameter("docass_target_id", NpgsqlDbType.Integer));
                    docassCommand.Parameters.Add(new NpgsqlParameter("docass_target_type", NpgsqlDbType.Text));

                    docassCommand.Parameters["docass_source_type"].Value = sourceType;
                    docassCommand.Parameters["docass_target_type"].Value = saveToDb ? "FILE" : "URL";

                    NpgsqlCommand sourceId = getSourceCommand(conn);
                    
                    foreach (string file in filesFound)
                    {
                        progress.incremenet();

                        string sourceNumber = "";
                        if (_searchMethod.Text == "Begins With")
                        {
                            Regex regex = new Regex(@"[" + (String.IsNullOrEmpty(_separator.Text) ? "_" : _separator.Text) + "]");
                            string[] matches = regex.Split(Path.GetFileNameWithoutExtension(file).ToUpper());
                            //Match match = regex.Match(row["fileName"].ToString());
                            if (matches.Length > 0)
                            {
                                sourceNumber = matches[0].ToUpper();
                            }
                            else
                            {
                                // if we didn't get any matches, maybe the filename is the document number on its own
                                sourceNumber = Path.GetFileNameWithoutExtension(file).ToUpper();
                            }

                        }
                        else if (_searchMethod.Text == "Equals")
                        {
                            sourceNumber = Path.GetFileNameWithoutExtension(file).ToUpper();
                        }

                        sourceId.Parameters["source_number"].Value = sourceNumber;

                        try
                        {
                            source_id = (Int32)sourceId.ExecuteScalar();
                        }
                        catch (NullReferenceException) {
                            output += "Match For Number " + sourceNumber + " not found. " + Environment.NewLine;
                            continue;
                        }

                        if (saveToDb)
                        {
                            command.Parameters["file_title"].Value = Path.GetFileName(file);
                            command.Parameters["file_descrip"].Value = Path.GetFileName(file);
                            command.Parameters["file_stream"].Value = fileToByteArray(file);
                        }
                        else
                        {
                            command.Parameters["url_title"].Value = Path.GetFileName(file);
                            command.Parameters["url_url"].Value = "file:" + Path.GetFullPath(file).Replace('\\', '/');
                        }

                        target_id = (Int32)command.ExecuteScalar();

                        docassCommand.Parameters["docass_source_id"].Value = source_id;
                        docassCommand.Parameters["docass_target_id"].Value = target_id;
                        docassCommand.ExecuteScalar();
                    }
                    progress.Close();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                output += "Completed at " + DateTime.Now;
                conn.Close();
                conn.Dispose();
                outputlog ol = new outputlog();
                ol.setText(output);
                ol.Show();
            }

        }

        private void _searchMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            _separator.Enabled = (_searchMethod.Text == "Begins With");
            _separatorLit.Enabled = (_searchMethod.Text == "Begins With");
        }

        private void _overrideColumn_CheckedChanged(object sender, EventArgs e)
        {
            _column.Enabled = _overrideColumn.Checked;
        }

        private void _importSourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _column.Text = types[_importSourceType.Items.IndexOf(_importSourceType.Text), SOURCECOLUMN];
        }

        private void _searchMethod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        /// <summary>
        /// Method to extract files from an xTuple database for chosen sourceType
        /// </summary>
        /// <param name="sourceType">string source type from documents.cpp in qt-client/widgets</param>
        /// <returns>void</returns>
        private void extractFiles(string sourceType)
        {
            output = "Started " + DateTime.Now + Environment.NewLine;

            string fileQuery = String.Format("SELECT file_stream, file_descrip, file_title "
                                            +" FROM docass "
                                            +" JOIN file ON (docass_target_id = file_id AND docass_target_type = 'FILE') "
                                            +" WHERE docass_source_type = '{0}';", sourceType);
            
            DataTable filesToExtract = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection(getConnectionString());
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(fileQuery, conn);

            try
            {
                if (String.IsNullOrEmpty(_outputPath.Text))
                {
                    MessageBox.Show("Output path is empty");
                    return;
                }
                else
                {
                    progress progress = new progress();

                    if (filesToExtract.Rows.Count > 0)
                    {
                        progress.setMaxValue(filesToExtract.Rows.Count);
                        progress.Show();
                    }
                    conn.Open();
                    da.Fill(filesToExtract);

                    foreach (DataRow row in filesToExtract.Rows)
                    {
                        progress.incremenet();

                        File.WriteAllBytes(_outputPath.Text + "\\" + row["file_descrip"].ToString().ToUpper(), (byte[])row["file_stream"]);
                        output += String.Format("Wrote {0} to {1}", row["file_descrip"].ToString().ToUpper(), _outputPath.Text + "\\" + row["file_descrip"].ToString().ToUpper() + Environment.NewLine);
                    }
                    progress.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                output += "Completed at " + DateTime.Now;
                conn.Close();
                conn.Dispose();
                outputlog ol = new outputlog();
                ol.setText(output);
                ol.Show();
            }
        }

        /// <summary>
        /// Method to preview results of file scan
        /// </summary>
        /// <returns>void</returns>
        private void previewFiles()
        {
            files.Clear();
            string[] filesFound;

            if (String.IsNullOrEmpty(_inputPath.Text))
            {
                MessageBox.Show("Input path is empty");
                return;
            }
            else
            {
                filesFound = Directory.GetFiles(_inputPath.Text, String.IsNullOrEmpty(_mask.Text) ? "*.*" : _mask.Text, _recursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                foreach (string file in filesFound)
                {
                    DataRow row = files.NewRow();
                    row["fileName"] = Path.GetFileName(file);
                    row["fileNameNoExt"] = Path.GetFileNameWithoutExtension(file);
                    row["filePath"] = Path.GetFullPath(file);
                    files.Rows.Add(row);
                }
                _previewGrid.DataSource = files;
            }
        }

        /// <summary>
        /// Method to attempt matching the source document number from the preview grid to the document within xTuple
        /// </summary>
        /// <returns>void</returns>
        private void attemptmatch()
        {
            NpgsqlConnection conn = new NpgsqlConnection(getConnectionString());
            previewFiles();
            try
            {
                if (String.IsNullOrEmpty(_inputPath.Text))
                {
                    MessageBox.Show("Input path is empty");
                    return;
                }
                else
                {
                    progress progress = new progress();

                    conn.Open();

                    NpgsqlCommand sourceId = getSourceCommand(conn);

                    if (files.Rows.Count > 0)
                    {
                        progress.setMaxValue(files.Rows.Count);
                        progress.Show();
                    }

                    foreach (DataRow row in files.Rows)
                    {
                        string sourceNumber = "";

                        if (_searchMethod.Text == "Begins With")
                        {
                            Regex regex = new Regex(@"[" + (String.IsNullOrEmpty(_separator.Text) ? "_" : _separator.Text) + "]");
                            string[] matches = regex.Split(row["fileNameNoExt"].ToString());
                            //Match match = regex.Match(row["fileName"].ToString());
                            if (matches.Length > 0)
                            {
                                sourceNumber = matches[0].ToUpper();
                            }
                            else
                            {
                                sourceNumber = row["fileNameNoExt"].ToString().ToUpper();
                            }

                        }
                        else if (_searchMethod.Text == "Equals") {
                            sourceNumber = row["fileNameNoExt"].ToString().ToUpper();
                        }

                        sourceId.Parameters["source_number"].Value = sourceNumber;
                        progress.incremenet();
                        try
                        {
                            Int32 source_id = (Int32)sourceId.ExecuteScalar();
                            row["sourceNumber"] = sourceNumber;
                        }
                        catch (Exception)
                        {
                            row["sourceNumber"] = null;
                            continue;
                        }
                    }
                    progress.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                files.AcceptChanges();
                conn.Close();
                conn.Dispose();
            }
        }

        #endregion

    }
}
