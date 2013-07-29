using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComPorts;
using FileLib;

namespace ReflowController
{
    public partial class frmPIDSettings : Form
    {
        ComPortsLib ComPort = new ComPortsLib();
        INI_File ini = new INI_File();
        
        public frmPIDSettings()
        {
            InitializeComponent();
            InitializeValues();
            LoadAllFiles();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Initialize variables
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void InitializeValues()
        {
            int[] Kp = new int[]
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 
                 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 
                 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 
                 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 
                 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 
                 92, 93, 94, 95, 96, 97, 98, 99, 100 };

            int[] Ki = new int[]
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 
                 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 
                 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 
                 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 
                 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 
                 92, 93, 94, 95, 96, 97, 98, 99, 100 };

            int[] Kd = new int[]
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 
                 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 
                 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 
                 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 
                 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 
                 92, 93, 94, 95, 96, 97, 98, 99, 100 }; 

            int[] cycleTime = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            createProfileKpComboBox.DataSource = Kp;
            createProfileKpComboBox.SelectedItem = 11;

            createProfileKiComboBox.DataSource = Ki;
            createProfileKiComboBox.SelectedItem = 5;

            createProfileKdComboBox.DataSource = Kd;
            createProfileKdComboBox.SelectedItem = 1;

            createProfileCycleTimeComboBox.DataSource = cycleTime;
            createProfileCycleTimeComboBox.SelectedItem = 5;

            editProfileComboBoxKp.DataSource = Kp;
            editProfileComboBoxKp.SelectedItem = 11;

            editProfileComboBoxKi.DataSource = Ki;
            editProfileComboBoxKi.SelectedItem = 5;

            editProfileComboBoxKd.DataSource = Kd;
            editProfileComboBoxKd.SelectedItem = 1;

            editProfileCycleTimeLabel.DataSource = cycleTime;
            editProfileCycleTimeLabel.SelectedItem = 5;
        }

        ///// <summary>
        ///// ------------------------------------------------------------------------------
        /////  Procedure: Upload PID gains to controller
        /////  ins: none
        /////  outs: none
        ///// ------------------------------------------------------------------------------
        ///// </summary>
        //private void UploadPID()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();

        //    string path = Environment.CurrentDirectory;

        //    if (Directory.Exists(path))
        //    {
        //        if (ComPort.IsPortOpen() == true)
        //        {
        //            openFileDialog.Title = "Upload PID Gains";
        //            openFileDialog.InitialDirectory = path;
        //            openFileDialog.Filter = "INI (*.ini)|*.ini";

        //            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        //            {
        //                path = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
        //                ComPort.UploadPID(openFileDialog.SafeFileName, path);
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Save PID gains
        ///  ins: profile name, soak temperature, soak time, reflow temperature,
        ///  reflow time, bake temperature, bake time
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void SavePID(string filename, string Kp, string Ki,
            string Kd, string cycleTime)
        {
            string path = Environment.CurrentDirectory + @"\PID";

            if (!(filename == null || filename == ""))
            {
                if (!(Directory.Exists(path))) Directory.CreateDirectory(path);

                //Write to profile
                ini.WriteINI(filename, "FILE TYPE", "VALUE", "PID", path);
                ini.WriteINI(filename, "PROFILE", "NAME", filename, path);
                ini.WriteINI(filename, "KP", "VALUE", Kp, path);
                ini.WriteINI(filename, "KI", "VALUE", Ki, path);
                ini.WriteINI(filename, "KD", "VALUE", Kd, path);
                ini.WriteINI(filename, "CYCLE TIME", "VALUE", cycleTime, path);

                MessageBox.Show("Profile " + filename + " successfully saved.",
                "Save Profile", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Delete selected file
        ///  ins: file name
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void DeleteProfile(string filename)
        {
            string path = path = Environment.CurrentDirectory + @"\PID";

            try
            {
                if (System.IO.File.Exists(path + "\\" + filename) && filename != "Default.ini")
                {
                    System.IO.File.Delete(path + "\\" + filename);

                    MessageBox.Show("File " + filename + " successfully deleted.",
                    "File Modified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    MessageBox.Show("File " + filename + " cannot be deleted.",
                    "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Illegal Permissions for this operation: " + ex.Message);
            }

            catch (IOException exIO)
            {
                MessageBox.Show("File in use: " + exIO.Message);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Load all files in directory
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void LoadAllFiles()
        {
            string path = Environment.CurrentDirectory + @"\PID";

            DirectoryInfo dir = new DirectoryInfo(path);

            if (!(Directory.Exists(path))) Directory.CreateDirectory(path);
            
            FileInfo[] iniFiles = dir.GetFiles("*.ini");

            if (!(IsDirectoryEmpty(path) == true))
            {
                //Refresh profile entries
                comboBoxProfileName.Items.Clear();

                foreach (FileInfo f in iniFiles)
                {
                    comboBoxProfileName.Items.Add(f.Name);
                }

                comboBoxProfileName.SelectedIndex = 0;
            
                string filename = comboBoxProfileName.SelectedItem.ToString();

                editProfileComboBoxKp.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "KP", "VALUE", path));
                editProfileComboBoxKi.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "KI", "VALUE", path));
                editProfileComboBoxKd.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "KD", "VALUE", path));
                editProfileCycleTimeLabel.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "CYCLE TIME", "VALUE", path));
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Checks for an empty directory
        ///  ins: directory path
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Load stored *.ini parameters for selected profile. This action
        ///  is executed on filename change in the Profile combobox.
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void comboBoxProfileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + @"\PID";
            string filename = comboBoxProfileName.SelectedItem.ToString();

            editProfileComboBoxKp.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "KP", "VALUE", path));
            editProfileComboBoxKi.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "KI", "VALUE", path));
            editProfileComboBoxKd.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "KD", "VALUE", path));
            editProfileCycleTimeLabel.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "CYCLE TIME", "VALUE", path));
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Close form from Create PID gains tab
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void createProfileCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Close form from Edit PID gains tab
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void editProfileCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to save PID gains to a file from Edit PID gains tab
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void createProfileSaveButton_Click(object sender, EventArgs e)
        {
            if (!(createProfileTextBox.Text == null || createProfileTextBox.Text == ""))
            {
                SavePID(createProfileTextBox.Text + ".ini", createProfileKpComboBox.SelectedItem.ToString(),
                    createProfileKiComboBox.SelectedItem.ToString(), createProfileKdComboBox.SelectedItem.ToString(),
                    createProfileCycleTimeComboBox.SelectedItem.ToString());

                LoadAllFiles();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to save PID gains to a file from Create PID gains tab
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void editProfileSaveButton_Click(object sender, EventArgs e)
        {
            SavePID(comboBoxProfileName.SelectedItem.ToString(), editProfileComboBoxKp.SelectedItem.ToString(),
                    editProfileComboBoxKi.SelectedItem.ToString(), editProfileComboBoxKd.SelectedItem.ToString(),
                    editProfileCycleTimeLabel.SelectedItem.ToString());

            LoadAllFiles();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to delete a profile
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void editProfileDeleteButton_Click(object sender, EventArgs e)
        {
            DeleteProfile(comboBoxProfileName.SelectedItem.ToString());
            comboBoxProfileName.Items.Clear();
            LoadAllFiles();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Disable combobox editing
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void createProfileKpComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void createProfileKiComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void createProfileKdComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void createProfileCycleTimeComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBoxProfileName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void editProfileComboBoxKp_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void editProfileComboBoxKi_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void editProfileComboBoxKd_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void editProfileCycleTimeLabel_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
