using System;
using System.Drawing;
using System.Windows.Forms;
using ReflowController.Properties;

namespace ReflowController
{
    public partial class frmAppSettings : Form
    {
        public frmAppSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Initialize paths on form startup.
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void frmSettings_Load(object sender, EventArgs e)
        {
            FirmwareLoaderPathLabel.AutoEllipsis = true;
            FirmwareLoaderPathLabel.Text = Settings.Default.firmwarepath;

            ProgrammerLoaderPathLabel.AutoEllipsis = true;
            ProgrammerLoaderPathLabel.Text = Settings.Default.programmerpath;

            EditorLoaderPathLabel.AutoEllipsis = true;
            EditorLoaderPathLabel.Text = Settings.Default.editorpath;

            if (FirmwareLoaderPathLabel.Text == "")
            {
                FirmwareLoaderStatusLabel.ForeColor = Color.Red;
                FirmwareLoaderStatusLabel.Text = "Status: Firmware loader path not saved.";
            }

            else
            {
                FirmwareLoaderStatusLabel.ForeColor = Color.Black;
                FirmwareLoaderStatusLabel.Text = "Status: Firmware loader path saved.";
            }

            if (ProgrammerLoaderPathLabel.Text == "")
            {
                ProgrammerStatusLabel.ForeColor = Color.Red;
                ProgrammerStatusLabel.Text = "Status: Programmer path not saved.";
            }

            else
            {
                ProgrammerStatusLabel.ForeColor = Color.Black;
                ProgrammerStatusLabel.Text = "Status: Programmer path saved.";
            }

            if (EditorLoaderPathLabel.Text == "")
            {
                EditorStatusLabel.ForeColor = Color.Red;
                EditorStatusLabel.Text = "Status: Editor path not saved.";
            }

            else
            {
                EditorStatusLabel.ForeColor = Color.Black;
                EditorStatusLabel.Text = "Status: Editor path saved.";
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to browse for firmware loader application.
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void BrowseFirmwarePathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get application path and loader filename
                string path = System.IO.Path.GetDirectoryName(openFileDialog.FileName) + "\\" + 
                    System.IO.Path.GetFileName(openFileDialog.FileName);

                //set label to current path text
                FirmwareLoaderPathLabel.Text = path;
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to browse for hardware programmer application.
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void BrowseProgrammerButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get application path and loader filename
                string path = System.IO.Path.GetDirectoryName(openFileDialog.FileName) + "\\" +
                    System.IO.Path.GetFileName(openFileDialog.FileName);

                //set label to current path text
                ProgrammerLoaderPathLabel.Text = path;
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to browse for program editor application.
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void BrowseEditorButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get application path and loader filename
                string path = System.IO.Path.GetDirectoryName(openFileDialog.FileName) + "\\" +
                    System.IO.Path.GetFileName(openFileDialog.FileName);

                //set label to current path text
                EditorLoaderPathLabel.Text = path;
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to save application paths, if loaded.
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (FirmwareLoaderPathLabel.Text != "")
            {
                //Save selected path settings
                Settings.Default.firmwarepath = FirmwareLoaderPathLabel.Text;
                Settings.Default.Save();

                FirmwareLoaderStatusLabel.ForeColor = Color.Black;
                FirmwareLoaderStatusLabel.Text = "Status: Firmware loader path saved.";
            }

            if (ProgrammerLoaderPathLabel.Text != "")
            {
                //Save selected path settings
                Settings.Default.programmerpath = ProgrammerLoaderPathLabel.Text;
                Settings.Default.Save();

                ProgrammerStatusLabel.ForeColor = Color.Black;
                ProgrammerStatusLabel.Text = "Status: Programmer path saved.";
            }

            if (EditorLoaderPathLabel.Text != "")
            {
                //Save selected path settings
                Settings.Default.editorpath = EditorLoaderPathLabel.Text;
                Settings.Default.Save();

                EditorStatusLabel.ForeColor = Color.Black;
                EditorStatusLabel.Text = "Status: Editor path saved.";
            }

            this.Close();
        }
    }
}
