using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using fileimporter.Properties;
using System.Collections;
using System.Collections.Generic;
using Npgsql;
using System.IO;
using NpgsqlTypes;

namespace xtfileimporter
{
    public partial class main : Form
    {
        string username;
        string password;
        string report;
        string database;
        int port;
        bool headless = false;
        string connString;
        DataTable files = new DataTable();
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        string errors;

        public main(string[] _args)
        {
            InitializeComponent();

            try
            {
                if (_args.Length > 0)
                {
                    _processArguments(_args);
                }
                files.Columns.Add(new DataColumn("fileName"));
                files.Columns.Add(new DataColumn("fileNameNoExt"));
                files.Columns.Add(new DataColumn("filePath"));
                files.Columns.Add(new DataColumn("itemNumber"));
            }
            catch (Exception e)
            {
                 MessageBox.Show(e.ToString(), "Error Starting file importer");
            }

        }

        #region database
        private string setConnectionString()
        {
            connString = "Server=" + _server.Text + ";Port=" + _port.Text + ";User Id=" + _user.Text + ";Password=" + _password.Text + ";Database=" + _database.Text + ";";
            Console.WriteLine(connString);
            return connString;
        }
        #endregion

        #region helper
        
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
        /// Method to get strip duplicate values from a string[] array
        /// </summary>
        /// <param name="_sourceArray">array containing duplicate values</param>
        /// <returns>string[]</returns>
        public string[] removeDuplicates(string[] _sourceArray)
        {
            string[] uniqueArray = _sourceArray;
            ArrayList tempList1 = new ArrayList(uniqueArray);
            ArrayList tempList2 = new ArrayList();
            foreach (string str in tempList1)
            {
                if (!tempList2.Contains(str))
                {
                    tempList2.Add(str);
                }
            }
            uniqueArray = tempList2.ToArray(typeof(string)) as string[];
            return uniqueArray;
        }

        //alternate way
        /*
        public void LoadFile()
        {
            FileInfo file = new FileInfo(this.fileUrl);
            if (!file.Exists)
            {
                throw new ArgumentException("file with Url " + this.fileUrl + " could not be found.");
            }
            FileStream stream = new FileStream(this.fileUrl, FileMode.Open, FileAccess.Read);
            this.content = new byte[stream.Length];
            stream.Read(this.content, 0, this.content.Length);
            stream.Close();
        }
         * */


        #endregion
        
        #region meta
        private void _processArguments(string[] args)
        {
            try
            {
                foreach (string s in args)
                {
                    if (s.ToLower().Contains("--help"))
                    {
                        _showHelp();
                        Environment.Exit(0);
                    }
                    else if (s.ToLower().Contains("--version"))
                    {
                        _showVersion();
                        Environment.Exit(0);
                    }
                    else if (s.ToLower().Contains("--username="))
                    {
                        this.username = s.Remove(0, 11);
                    }
                    else if (s.ToLower().Contains("--password="))
                    {
                        this.password = s.Remove(0, 11);
                    }
                    else if (s.ToLower().Contains("--database="))
                    {
                        this.database = s.Remove(0, 11);
                    }
                    else if (s.ToLower().Contains("--port="))
                    {
                        this.port = Convert.ToInt16(s.Remove(0, 6));
                    }
                    else if (s.ToLower().Contains("--report="))
                    {
                        this.report = s.Remove(0, 9);
                    }
                    else if (s.ToLower().Contains("--headless"))
                    {
                        this.headless = true;
                    }
                    else
                    {
                        // we only care if it is in the parameter format
                        if (s.IndexOf("--") > -1 && s.IndexOf('=') > 0)
                        {
                            string argname = s.Substring(s.LastIndexOf('-') + 1, (s.IndexOf('=') - 1) - s.LastIndexOf('-'));
                            string argvalue = s.Substring(s.IndexOf('=') + 1, s.Length - s.IndexOf('=') - 1);
                            parameters.Add(argname, argvalue);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
                Environment.Exit(-1);
            }
        }
        private void _showHelp()
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
        private void _showVersion()
        {
            MessageBox.Show(this, @"Version: " + AssemblyInfo.Version + " Built On: " + AssemblyInfo.getBuildDate().ToString() + Environment.NewLine
                      + "Written by David Beauchamp" + Environment.NewLine
                      + "david@xtuple.com" + Environment.NewLine, "File importer for xTuple ERP");
        }
        #endregion

        #region event handlers
        private void main_Load(object sender, EventArgs e)
        {
            this.Text = "fileimporter " + AssemblyInfo.Version;
            _loadSettings();
        }
        private void _loadSettings()
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

        private void renderer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _saveSettings();
        }
        private void _saveSettings()
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

        private void _exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void inputPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _inputPath.Text = fd.SelectedPath;
            }
        }

        private void _checkedChanged(object sender, EventArgs e)
        {
            _import.Text = _saveToDb.Checked ? "Import Files" : "Attach Files";
        }

        private void _import_Click(object sender, EventArgs e)
        {
            switch (_saveToDb.Checked) {
            case true:
                saveToDb();
                break;
            case false:
                attachFiles();
                break;
            }
        }

        private void attemptmatch()
        {
            NpgsqlConnection conn = new NpgsqlConnection(setConnectionString());
            
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

                    NpgsqlCommand itemQry = new NpgsqlCommand("SELECT item_id FROM item WHERE item_number = :item_number;", conn);
                    itemQry.Parameters.Add(new NpgsqlParameter("item_number", NpgsqlDbType.Text));

                    foreach (DataRow row in files.Rows)
                    {
                        string itemNumber = row["fileNameNoExt"].ToString().ToUpper();
                        itemQry.Parameters["item_number"].Value = itemNumber;
                        try
                        {
                          Int32 item_id = (Int32)itemQry.ExecuteScalar();          
                        }
                        catch (NullReferenceException)
                        {
                            continue;
                        }
                        row["itemNumber"] = itemNumber;
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

        private void attachFiles()
        {
            errors = "Started " + DateTime.Now + Environment.NewLine;
            string[] filesFound;

            
            Int32 url_id = 0;
            NpgsqlConnection conn = new NpgsqlConnection(setConnectionString());
            string insertUrlQuery = "INSERT INTO urlinfo (url_title, url_url) VALUES (:fileName, :filePath) RETURNING url_id;";
            string insertDocassQuery = "INSERT INTO docass (docass_source_id, docass_source_type, docass_target_id, docass_target_type, docass_purpose) VALUES (:docass_source_id, 'I', :docass_target_id,'URL', 'S');";

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

                    NpgsqlCommand command = new NpgsqlCommand(insertUrlQuery, conn);
                    NpgsqlCommand docassCommand = new NpgsqlCommand(insertDocassQuery, conn);

                    command.Parameters.Add(new NpgsqlParameter("fileName", NpgsqlDbType.Text));
                    command.Parameters.Add(new NpgsqlParameter("filePath", NpgsqlDbType.Text));

                    docassCommand.Parameters.Add(new NpgsqlParameter("docass_source_id", NpgsqlDbType.Integer));
                    docassCommand.Parameters.Add(new NpgsqlParameter("docass_target_id", NpgsqlDbType.Integer));

                    NpgsqlCommand itemId = new NpgsqlCommand("SELECT item_id FROM item WHERE item_number = :item_number;", conn);
                    itemId.Parameters.Add(new NpgsqlParameter("item_number", NpgsqlDbType.Text));

                    foreach (string file in filesFound)
                    {
                        string itemNumber = Path.GetFileNameWithoutExtension(file).ToUpper();
                        itemId.Parameters["item_number"].Value = itemNumber;
                        Int32 item_id = 0;
                        try
                        {
                            item_id = (Int32)itemId.ExecuteScalar();
                        }
                        catch (NullReferenceException) {
                            errors += "Item Number " + itemNumber + " not found. " + Environment.NewLine;
                            continue;
                        }

                        command.Parameters["fileName"].Value = Path.GetFileName(file);
                        command.Parameters["filePath"].Value = "file:" + Path.GetFullPath(file).Replace('\\', '/');
                        url_id = (Int32)command.ExecuteScalar();

                        docassCommand.Parameters["docass_source_id"].Value = item_id;
                        docassCommand.Parameters["docass_target_id"].Value = url_id;
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
                errors += "Completed at " + DateTime.Now;
                conn.Close();
                conn.Dispose();
                outputlog ol = new outputlog();
                ol.setText(errors);
                ol.Show();
            }

        }

        private void saveToDb()
        {
            errors = "Started " + DateTime.Now + Environment.NewLine;
            string[] filesFound;
            
            Int32 file_id = 0;
            NpgsqlConnection conn = new NpgsqlConnection(setConnectionString());
            string insertUrlQuery = "INSERT INTO file (file_title, file_stream, file_descrip) VALUES (:file_title, :file_stream, :file_descrip) RETURNING file_id;";
            string insertDocassQuery = "INSERT INTO docass (docass_source_id, docass_source_type, docass_target_id, docass_target_type, docass_purpose) VALUES (:docass_source_id, 'I', :docass_target_id, 'FILE', 'S');";

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

                    NpgsqlCommand command = new NpgsqlCommand(insertUrlQuery, conn);
                    NpgsqlCommand docassCommand = new NpgsqlCommand(insertDocassQuery, conn);

                    command.Parameters.Add(new NpgsqlParameter("file_title", NpgsqlDbType.Text));
                    command.Parameters.Add(new NpgsqlParameter("file_stream", NpgsqlDbType.Bytea));
                    command.Parameters.Add(new NpgsqlParameter("file_descrip", NpgsqlDbType.Text));

                    docassCommand.Parameters.Add(new NpgsqlParameter("docass_source_id", NpgsqlDbType.Integer));
                    docassCommand.Parameters.Add(new NpgsqlParameter("docass_target_id", NpgsqlDbType.Integer));

                    NpgsqlCommand itemId = new NpgsqlCommand("SELECT item_id FROM item WHERE item_number = :item_number;", conn);
                    itemId.Parameters.Add(new NpgsqlParameter("item_number", NpgsqlDbType.Text));

                    foreach (string file in filesFound)
                    {
                        string itemNumber = Path.GetFileNameWithoutExtension(file).ToUpper();
                        itemId.Parameters["item_number"].Value = itemNumber;
                        Int32 item_id = 0;
                        try
                        {
                            item_id = (Int32)itemId.ExecuteScalar();
                        }
                        catch (NullReferenceException)
                        {
                            errors += "Item Number " + itemNumber + " not found. " + Environment.NewLine;
                            continue;
                        }

                        command.Parameters["file_title"].Value = itemNumber;
                        command.Parameters["file_descrip"].Value = Path.GetFileName(file);
                        command.Parameters["file_stream"].Value = fileToByteArray(file);
                        file_id = (Int32)command.ExecuteScalar();

                        docassCommand.Parameters["docass_source_id"].Value = item_id;
                        docassCommand.Parameters["docass_target_id"].Value = file_id;
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
                errors += "Completed at " + DateTime.Now;
                conn.Close();
                conn.Dispose();
                outputlog ol = new outputlog();
                ol.setText(errors);
                ol.Show();
            }

        }

        private void _preview_Click(object sender, EventArgs e)
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

        private void _attempt_Click(object sender, EventArgs e)
        {
            attemptmatch();
        }

        private void _extract_Click(object sender, EventArgs e)
        {
            extractFiles();
        }

        private void extractFiles()
        {
            string fileQuery = "select file_stream, file_descrip, file_title, item_number "
                                          + " from docass "
                                          + " join item on (docass_source_id = item_id AND docass_source_type = 'I') "
                                          + " join file on (docass_target_id = file_id AND docass_target_type = 'FILE')";

            DataTable filesToExtract = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection(setConnectionString());
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
                        File.WriteAllBytes(_outputPath.Text + "\\" + row["file_descrip"], (byte[])row["file_stream"]);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void extractPreview()
        {
            string fileQuery = "select item_number, file_descrip, file_title "
                                + " from docass "
                                + " join item on (docass_source_id = item_id AND docass_source_type = 'I') "
                                + " join file on (docass_target_id = file_id AND docass_target_type = 'FILE')";

            DataTable filesToExtract = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection(setConnectionString());
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

                    if (filesToExtract != null)
                    {
                        _previewExtractGrid.DataSource = filesToExtract;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void _previewExtract_Click(object sender, EventArgs e)
        {
            extractPreview();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _outputPath.Text = fd.SelectedPath;
            }
        }

    }
}
