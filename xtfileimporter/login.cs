using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace xtfileimporter
{
    public partial class login : Form
    {
        string username = String.Empty;
        string password = String.Empty;
        string database = String.Empty;
        string server = String.Empty;
        bool headless = false;
        int port = 0;

        public login(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                processArguments(args);
                if (headless)
                {
                    _login_Click(null, null);
                }
            }
        }
        /// <summary>
        /// Method to build the global connection string. Used in case people make changes in between operations
        /// </summary>
        /// <returns>string</returns>
        private string getConnectionString()
        {
            if (String.IsNullOrEmpty(_server.Text) || String.IsNullOrEmpty(_port.Text) || String.IsNullOrEmpty(_user.Text) ||  String.IsNullOrEmpty(_database.Text))
            {
                MessageBox.Show("Please completely fill out server information before continuing");
                return null;
            }
            return String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};ApplicationName=xtfileimporter",
                                 _server.Text, _port.Text, _user.Text, _password.Text, _database.Text);
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
        private void _exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void _login_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(getConnectionString());
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT login(true);";
                cmd.ExecuteScalar();
                main mainForm = new main(conn);
                this.Hide();
                mainForm.ShowDialog();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
            finally
            {
                Environment.Exit(0);
            }
        }
    }
}
