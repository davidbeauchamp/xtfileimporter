using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using xtfileimporter.Properties;
using Npgsql;
using System.IO;
using NpgsqlTypes;
using System.Diagnostics;

namespace xtfileimporter
{
    public partial class main : Form
    {
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

        DataTable files = new DataTable();
        string output = String.Empty;

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
        {
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
            NpgsqlCommand sourceCommand;
            string sourceQuery = "";

            switch (_importSourceType.Text)
            {
                case "Items":
                    sourceQuery = "SELECT item_id FROM item WHERE item_number = :source_number;";
                    break;
                case "CRM Accounts":
                    sourceQuery = "SELECT crmacct_id FROM crmacct WHERE crmacct_number = :source_number;";
                    break;
                case "Sales Order":
                    sourceQuery = "SELECT cohead_id FROM cohead WHERE cohead_number = :source_number;";
                    break;
                case "Lot/Serial":
                    sourceQuery = "SELECT ls_id FROM ls WHERE ls_number = :source_number;";
                    break;
                case "Work Order":
                    sourceQuery = "SELECT wo_id FROM wo WHERE wo_number::text = :source_number;";
                    break;
                case "Purchase Order":
                    sourceQuery = "SELECT pohead_id FROM pohead WHERE pohead_number = :source_number;";
                    break;
                case "Vendor":
                    sourceQuery = "SELECT vend_id FROM vendinfo WHERE vend_number = :source_number;";
                    break;
            }

            sourceCommand = new NpgsqlCommand(sourceQuery, conn);
            sourceCommand.Parameters.Add(new NpgsqlParameter("source_number", NpgsqlDbType.Text));
            return sourceCommand;
        }
              
        /// <summary>
        /// Method to get byte array from a file
        /// </summary>
        /// <param name="_fileName">File name to get byte array</param>
        /// <returns>Byte Array</returns>
        public byte[] fileToByteArray(string _fileName)
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

        /// <summary>
        /// Method to get currently chosen source type
        /// </summary>
        /// <param name="cb">Combobox with the users choice</param>
        /// <returns>string</returns>
        private string getSourceType(ComboBox cb)
        {
            switch (cb.Text)
            {
                case "Items":
                    return "I";
                case "CRM Accounts":
                    return "CRMA";
                case "Sales Order":
                    return "S";
                case "Lot/Serial":
                    return "LS";
                case "Work Order":
                    return "W";
                case "Purchase Order":
                    return "P";
                case "Vendor":
                    return "V";
            }
            return String.Empty;
        }

        #endregion

        #region meta

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
                      + "--username=<USERNAME>: The PostgreSQL username. Required in headless mode." + Environment.NewLine
                      + "--password=<PASSWORD>: The PostgreSQL password. Required in headless mode." + Environment.NewLine
                      + "--database=<DATABSE>: The xTuple database you want to import into. Required in headless mode." + Environment.NewLine
                      + "--port=<PORT>: The PostgreSQL server port for." + Environment.NewLine
                      + "--headless: Forces headless operation.", "fileimporter " + AssemblyInfo.Version);
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
            this.Text = "fileimporter " + AssemblyInfo.Version;
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
            attachFiles(getSourceType(_importSourceType));
        }
        private void _preview_Click(object sender, EventArgs e)
        {
            previewFiles();
        }
        private void _attempt_Click(object sender, EventArgs e)
        {
            attemptmatch();
        }
        private void _extract_Click(object sender, EventArgs e)
        {
            extractFiles(getSourceType(_extractSourceType));
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
                insertSourceQuery = "INSERT INTO urlinfo (url_title, url_url) VALUES (:fileName, :filePath) RETURNING url_id;";
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
                    filesFound = Directory.GetFiles(_inputPath.Text, "*.*", _recursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
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
                        command.Parameters.Add(new NpgsqlParameter("fileName", NpgsqlDbType.Text));
                        command.Parameters.Add(new NpgsqlParameter("filePath", NpgsqlDbType.Text));
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
                        string sourceNumber = Path.GetFileNameWithoutExtension(file).ToUpper();
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
                            command.Parameters["file_title"].Value = sourceNumber;
                            command.Parameters["file_descrip"].Value = Path.GetFileName(file);
                            command.Parameters["file_stream"].Value = fileToByteArray(file);
                        }
                        else
                        {
                            command.Parameters["fileName"].Value = Path.GetFileName(file);
                            command.Parameters["filePath"].Value = "file:" + Path.GetFullPath(file).Replace('\\', '/');
                        }

                        target_id = (Int32)command.ExecuteScalar();

                        docassCommand.Parameters["docass_source_id"].Value = source_id;
                        docassCommand.Parameters["docass_target_id"].Value = target_id;
                        docassCommand.ExecuteScalar();
                    }
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
                    conn.Open();
                    da.Fill(filesToExtract);

                    foreach (DataRow row in filesToExtract.Rows)
                    {
                        File.WriteAllBytes(_outputPath.Text + "\\" + row["file_descrip"].ToString().ToUpper(), (byte[])row["file_stream"]);
                        output += String.Format("Wrote {0} to {1}", row["file_descrip"].ToString().ToUpper(), _outputPath.Text + "\\" + row["file_descrip"].ToString().ToUpper() + Environment.NewLine);
                    }
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
                filesFound = Directory.GetFiles(_inputPath.Text, "*.*", _recursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
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
        /// Method to attempt finding the source document number from the preview grid to the document within xTuple
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
                    conn.Open();

                    NpgsqlCommand sourceId = getSourceCommand(conn);

                    foreach (DataRow row in files.Rows)
                    {
                        string sourceNumber = row["fileNameNoExt"].ToString().ToUpper();
                        sourceId.Parameters["source_number"].Value = sourceNumber;
                        try
                        {
                            Int32 source_id = (Int32)sourceId.ExecuteScalar();
                            row["sourceNumber"] = sourceNumber;
                        }
                        catch (NullReferenceException)
                        {
                            row["sourceNumber"] = null;
                            continue;
                        }
                    }
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
