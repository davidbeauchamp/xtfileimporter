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
        string sourcetype = String.Empty;
        string targettype = String.Empty;
        string outputpath = String.Empty;
        string inputpath = String.Empty;
        string mode = String.Empty;
        
        //bool recursive = false;
        NpgsqlConnection conn;
        #endregion

        // used to store the file list
        DataTable files = new DataTable();
        // string that gets built and displayed at the end of the run
        string output = String.Empty;

        string[,] types;

        // these constants represent the columns in the above types array
        int SOURCE = 0,
            SOURCETYPE = 1,
            SOURCEQUERY = 2,
            SOURCECOLUMN = 3, 
            SOURCETABLE = 4;

        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args">arguments as passed in via command line</param>
        /// <returns>main</returns>
        public main(NpgsqlConnection _conn)
        {
            InitializeComponent();
            this.conn = _conn;
            try
            {
                // populate comboboxes
                addTypeChoices();

                // prepare the DataTable with the columns we will use
                files.Columns.Add(new DataColumn("fileName"));
                files.Columns.Add(new DataColumn("fileNameNoExt"));
                files.Columns.Add(new DataColumn("filePath"));
                files.Columns.Add(new DataColumn("type"));
                files.Columns.Add(new DataColumn("sourceNumber"));
            }
            catch (Exception e)
            {
                 MessageBox.Show(e.ToString(), "Error Starting file importer");
            }
        }

        #region helper



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
            string sourceQuery = " SELECT * FROM source "
                                +" WHERE source_docass IS NOT NULL"
                                +" ORDER BY source_descrip ASC;";
            DataTable sources = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sourceQuery, conn);
            da.Fill(sources);
            int count = 0;
            if (sources.Rows.Count > 0)
            {
                types = new string[sources.Rows.Count, 5];
            }
            else { return; }

            foreach (DataRow row in sources.Rows)
            {
                types[count, SOURCE] = row["source_descrip"].ToString();
                types[count, SOURCETYPE] = row["source_docass"].ToString();
                types[count, SOURCEQUERY] = "SELECT " + row["source_key_field"].ToString() + ", " + row["source_number_field"].ToString() + " FROM " + row["source_table"].ToString() + " " + row["source_joins"] + " WHERE UPPER({0}) = :source_number;";
                types[count, SOURCECOLUMN] = row["source_number_field"].ToString();
                types[count, SOURCETABLE] = row["source_table"].ToString();
                _importSourceType.Items.Add(row["source_descrip"].ToString());
                _extractSourceType.Items.Add(row["source_descrip"].ToString());
                count += 1;
            }
            
            _column.Text = types[_importSourceType.Items.IndexOf(_importSourceType.Text), SOURCECOLUMN];
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
        private void _attach_Click(object sender, EventArgs e)
        {
            new Thread(delegate()
            {
                this.Invoke((MethodInvoker)delegate
                {
                    attachFiles(types[_importSourceType.Items.IndexOf(_importSourceType.Text), SOURCETYPE], false);
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
                    attachFiles(types[_importSourceType.Items.IndexOf(_importSourceType.Text), SOURCETYPE], true);
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
            DataTable columns = new DataTable();

            string query = " SELECT column_name from information_schema.columns "
                         + " WHERE table_name = :source_table "
                         + " AND table_schema != 'api' "
                         + " ORDER BY column_name ASC;";

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.Add(new NpgsqlParameter("source_table", NpgsqlDbType.Text));
            cmd.Parameters["source_table"].Value = types[_importSourceType.Items.IndexOf(_importSourceType.Text), SOURCETABLE];
            columns.Load(cmd.ExecuteReader());
            _column.Items.Clear();
            foreach (DataRow row in columns.Rows)
            {
                _column.Items.Add(row["column_name"].ToString());
            }
            _column.Text = types[_importSourceType.Items.IndexOf(_importSourceType.Text), SOURCECOLUMN];
        }
        private void _searchMethod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }
        #endregion

        #region main

        /// <summary>
        /// Method attach files to xTuple ERP documents for the chosen sourceType.
        /// </summary>
        /// <param name="sourceType">string source type from source_docass in public.source table</param>
        /// <param name="attemptOnly">boolean whether or not to actually insert the file or just attempt to match the id</param>
        /// <returns>void</returns>
        private void attachFiles(string sourceType, bool attemptOnly)
        {
            output = "Started " + DateTime.Now + Environment.NewLine;
            string insertSourceQuery = "";
            bool saveToDb = _saveToDb.Checked;
            previewFiles();
            Int32 target_id = 0;
            Int32 source_id = 0;

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

                    progress progress = new progress();
                    if (files.Rows.Count > 0)
                    {
                        progress.setMaxValue(files.Rows.Count);
                        progress.Show();
                    }
                    else
                    {
                        return;
                    }

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
                    
                    foreach (DataRow row in files.Rows)
                    {
                        if (row["type"].ToString() == "D")
                        {
                            continue;
                        }
                        string sourceNumber = "";

                        if (_searchMethod.Text == "Begins With")
                        {
                            Regex regex = new Regex(@"[" + (String.IsNullOrEmpty(_separator.Text) ? "_" : _separator.Text) + "]");
                            string[] matches = regex.Split(row["fileNameNoExt"].ToString());
                            if (matches.Length > 0)
                            {
                                sourceNumber = matches[0].ToUpper();
                            }
                            else
                            {
                                sourceNumber = row["fileNameNoExt"].ToString().ToUpper();
                            }

                        }
                        else if (_searchMethod.Text == "Equals")
                        {
                            sourceNumber = row["fileNameNoExt"].ToString().ToUpper();
                        }


                        sourceId.Parameters["source_number"].Value = sourceNumber;
                        progress.incremenet();
                        try
                        {
                            source_id = (Int32)sourceId.ExecuteScalar();
                            row["sourceNumber"] = sourceNumber;
                        }
                        catch (NullReferenceException) {
                            output += "Match For Number " + sourceNumber + " not found. " + Environment.NewLine;
                            continue;
                        }

                        if (attemptOnly) { continue; }

                        if (saveToDb)
                        {
                            command.Parameters["file_title"].Value = row["fileName"].ToString();
                            command.Parameters["file_descrip"].Value = row["fileName"].ToString();
                            command.Parameters["file_stream"].Value = fileToByteArray(row["filePath"].ToString());
                        }
                        else
                        {
                            command.Parameters["url_title"].Value = row["fileName"].ToString();
                            command.Parameters["url_url"].Value = "file:" + row["filePath"].ToString().Replace('\\', '/');
                        }

                        target_id = (Int32)command.ExecuteScalar();

                        docassCommand.Parameters["docass_source_id"].Value = source_id;
                        docassCommand.Parameters["docass_target_id"].Value = target_id;
                        docassCommand.ExecuteScalar();
                        output += "Successfully uploaded " + row["filePath"].ToString() + Environment.NewLine;
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
                if (!attemptOnly)
                {
                    outputlog ol = new outputlog();
                    ol.setText(output);
                    ol.Show();
                }
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
                if (_matchFileName.Checked)
                {
                    filesFound = Directory.GetFiles(_inputPath.Text, String.IsNullOrEmpty(_mask.Text) ? "*.*" : _mask.Text, _recursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                    foreach (string file in filesFound)
                    {
                        DataRow row = files.NewRow();
                        row["fileName"] = Path.GetFileName(file);
                        row["fileNameNoExt"] = Path.GetFileNameWithoutExtension(file);
                        row["filePath"] = Path.GetFullPath(file);
                        row["type"] = "F";
                        files.Rows.Add(row);
                    }
                    _previewGrid.DataSource = files;
                }
                else if (_matchDirectory.Checked)
                {
                    filesFound = Directory.GetDirectories(_inputPath.Text, String.IsNullOrEmpty(_mask.Text) ? "*.*" : _mask.Text, SearchOption.TopDirectoryOnly);
                    foreach (string file in filesFound)
                    {
                        Regex regex = new Regex(@"[" + (String.IsNullOrEmpty(_separator.Text) ? "_" : _separator.Text) + "]");
                        string[] matches = regex.Split(Path.GetFileName(file));
                        
                        if (matches.Length == 0)
                        {
                            continue;
                        }
                        DataRow row = files.NewRow();
                        row["fileName"] = Path.GetFileName(file);
                        row["fileNameNoExt"] = Path.GetFileNameWithoutExtension(file);
                        row["filePath"] = Path.GetFullPath(file);
                        row["type"] = "D";
                        files.Rows.Add(row);
                        string[] subFilesFound = Directory.GetFiles(file, String.IsNullOrEmpty(_mask.Text) ? "*.*" : _mask.Text, _recursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                        foreach (string subfile in subFilesFound)
                        {
                            DataRow subrow = files.NewRow();
                            subrow["fileName"] = Path.GetFileName(subfile);
                            subrow["fileNameNoExt"] = Path.GetFileName(file);
                            subrow["filePath"] = Path.GetFullPath(subfile);
                            subrow["type"] = "F";
                            files.Rows.Add(subrow);
                        }
                        _previewGrid.DataSource = files;
                    }
                }
            }
        }

        #endregion

    }
}
