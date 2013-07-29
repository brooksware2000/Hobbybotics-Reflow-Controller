using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComPorts;
using FileLib;

namespace ReflowController
{
    public partial class frmProfileSettings : Form
    {
        ComPortsLib ComPort = new ComPortsLib();
        INI_File ini = new INI_File();

        public frmProfileSettings()
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
            int[] soaktemperature = new int[] {80, 90, 100, 110, 120, 130, 140, 150, 160,
                                         170, 180, 190, 200, 210, 220, 230, 240, 250};

            int[] reflowtemperature = new int[] {80, 90, 100, 110, 120, 130, 140, 150, 160,
                                         170, 180, 190, 200, 210, 220, 230, 240, 250};

            int[] baketemperature = new int[] {80, 90, 100, 110, 120, 130, 140, 150, 160,
                                         170, 180, 190, 200, 210, 220, 230, 240, 250};

            int[] soaktime = new int[120];

            int[] reflowtime = new int[120];

            int[] baketime = new int[7200];

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < soaktime.Length)
            {
                soaktime[i] = i + 1;
                i++;
            }

            while (j < reflowtime.Length)
            {
                reflowtime[j] = j + 1;
                j++;
            }

            while (k < baketime.Length)
            {
                baketime[k] = k + 1;
                k++;
            }

            SoakTemperatureComboBox1.DataSource = soaktemperature;
            SoakTemperatureComboBox1.SelectedItem = 170;

            SoakTemperatureComboBox2.DataSource = soaktemperature;
            SoakTemperatureComboBox2.SelectedItem = 170;

            SoakTimeComboBox1.DataSource = soaktime;
            SoakTimeComboBox1.SelectedItem = 90;

            SoakTimeComboBox2.DataSource = soaktime;
            SoakTimeComboBox2.SelectedItem = 90;

            ReflowTemperatureComboBox1.DataSource = reflowtemperature;
            ReflowTemperatureComboBox1.SelectedItem = 230;

            ReflowTemperatureComboBox2.DataSource = reflowtemperature;
            ReflowTemperatureComboBox2.SelectedItem = 230;

            ReflowTimeComboBox1.DataSource = reflowtime;
            ReflowTimeComboBox1.SelectedItem = 30;

            ReflowTimeComboBox2.DataSource = reflowtime;
            ReflowTimeComboBox2.SelectedItem = 30;

            BakeTemperatureComboBox1.DataSource = baketemperature;
            BakeTemperatureComboBox1.SelectedItem = 80;

            BakeTemperatureComboBox2.DataSource = baketemperature;
            BakeTemperatureComboBox2.SelectedItem = 80;

            BakeTimeComboBox1.DataSource = baketime;
            BakeTimeComboBox1.SelectedItem = 7200;
            
            BakeTimeComboBox2.DataSource = baketime;
            BakeTimeComboBox2.SelectedItem = 7200;
        }
        
        ///// <summary>
        ///// ------------------------------------------------------------------------------
        /////  Procedure: Uploads selected profile to controller
        /////  ins: none
        /////  outs: none
        ///// ------------------------------------------------------------------------------
        ///// </summary>
        //private void UploadProfile()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();

        //    string path = Environment.CurrentDirectory;

        //    if (Directory.Exists(path))
        //    {
        //        if (ComPort.IsPortOpen() == true)
        //        {
        //            openFileDialog.Title = "Upload Profile";
        //            openFileDialog.InitialDirectory = path;
        //            openFileDialog.Filter = "INI (*.ini)|*.ini";

        //            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        //            {
        //                path = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
        //                ComPort.UploadProfile(openFileDialog.SafeFileName, path);
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Save a reflow profile
        ///  ins: profile name, soak temperature, soak time, reflow temperature,
        ///  reflow time, bake temperature, bake time
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void SaveProfile(string filename, string soakTemp, string soakTime,
            string reflowTemp, string reflowTime, string bakeTemp, string bakeTime)
        {
            string path = Environment.CurrentDirectory + @"\Profiles";

            if (!(filename == null || filename == ""))
            {
                if (!(Directory.Exists(path))) Directory.CreateDirectory(path);

                //Write to profile
                ini.WriteINI(filename, "FILE TYPE", "VALUE", "Profile", path);
                ini.WriteINI(filename, "PROFILE", "NAME", filename, path);
                ini.WriteINI(filename, "SOAK TEMPERATURE", "VALUE", soakTemp, path);
                ini.WriteINI(filename, "SOAK TIME", "VALUE", soakTime, path);
                ini.WriteINI(filename, "REFLOW TEMPERATURE", "VALUE", reflowTemp, path);
                ini.WriteINI(filename, "REFLOW TIME", "VALUE", reflowTime, path);
                ini.WriteINI(filename, "BAKE TEMPERATURE", "VALUE", bakeTemp, path);
                ini.WriteINI(filename, "BAKE TIME", "VALUE", bakeTime, path);

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
            string path = path = Environment.CurrentDirectory + @"\Profiles";

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
            string path = Environment.CurrentDirectory + @"\Profiles";

            DirectoryInfo dir = new DirectoryInfo(path);

            if (!(Directory.Exists(path))) Directory.CreateDirectory(path);

            FileInfo[] iniFiles = dir.GetFiles("*.ini");

            if (!(IsDirectoryEmpty(path) == true))
            {
                //Refresh profile entries
                ProfileNameComboBox1.Items.Clear();

                foreach (FileInfo f in iniFiles)
                {
                    ProfileNameComboBox1.Items.Add(f.Name);
                }

                ProfileNameComboBox1.SelectedIndex = 0;

                string filename = ProfileNameComboBox1.SelectedItem.ToString();

                SoakTemperatureComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "SOAK TEMPERATURE", "VALUE", path));
                SoakTimeComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "SOAK TIME", "VALUE", path));
                ReflowTemperatureComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "REFLOW TEMPERATURE", "VALUE", path));
                ReflowTimeComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "REFLOW TIME", "VALUE", path));
                BakeTemperatureComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "BAKE TEMPERATURE", "VALUE", path));
                BakeTimeComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "BAKE TIME", "VALUE", path));
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
        private void ProfileNameComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + @"\Profiles";
            string filename = ProfileNameComboBox1.SelectedItem.ToString();

            SoakTemperatureComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "SOAK TEMPERATURE", "VALUE", path));
            SoakTimeComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "SOAK TIME", "VALUE", path));
            ReflowTemperatureComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "REFLOW TEMPERATURE", "VALUE", path));
            ReflowTimeComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "REFLOW TIME", "VALUE", path));
            BakeTemperatureComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "BAKE TEMPERATURE", "VALUE", path));
            BakeTimeComboBox2.SelectedItem = Convert.ToInt32(ini.ReadINI(filename, "BAKE TIME", "VALUE", path));
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Close form from Profile tab
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void CreateProfileCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Close form from Edit tab
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void EditProfileCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to create a reflow profile from create profile tab
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void CreateProfileSaveButton_Click(object sender, EventArgs e)
        {
            if (!(ProfileNameTextBox1.Text == null || ProfileNameTextBox1.Text == ""))
            {
                SaveProfile(ProfileNameTextBox1.Text + ".ini", SoakTemperatureComboBox1.SelectedItem.ToString(),
                    SoakTimeComboBox1.SelectedItem.ToString(), ReflowTemperatureComboBox1.SelectedItem.ToString(),
                    ReflowTimeComboBox1.SelectedItem.ToString(), BakeTemperatureComboBox1.SelectedItem.ToString(),
                    BakeTimeComboBox1.SelectedItem.ToString());
                
                LoadAllFiles();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to create a reflow profile from edit tab
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void EditProfileSaveButton_Click(object sender, EventArgs e)
        {
            SaveProfile(ProfileNameComboBox1.SelectedItem.ToString(), SoakTemperatureComboBox2.SelectedItem.ToString(),
                    SoakTimeComboBox2.SelectedItem.ToString(), ReflowTemperatureComboBox2.SelectedItem.ToString(),
                    ReflowTimeComboBox2.SelectedItem.ToString(), BakeTemperatureComboBox2.SelectedItem.ToString(),
                    BakeTimeComboBox2.SelectedItem.ToString());
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to delete a profile
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void EditProfileDeleteButton_Click(object sender, EventArgs e)
        {
            DeleteProfile(ProfileNameComboBox1.SelectedItem.ToString());
            ProfileNameComboBox1.Items.Clear();
            LoadAllFiles();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Disable combobox editing
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void SoakTemperatureComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void SoakTimeComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void ReflowTemperatureComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void ReflowTimeComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void BakeTemperatureComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void BakeTimeComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        
        private void ProfileNameComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void SoakTemperatureComboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void SoakTimeComboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void ReflowTemperatureComboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void ReflowTimeComboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void BakeTemperatureComboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void BakeTimeComboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
