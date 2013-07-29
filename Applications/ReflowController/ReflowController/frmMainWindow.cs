using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Windows.Forms;
using ComPorts;
using FileLib;
using ReflowController.Properties;
using ZedGraph;

namespace ReflowController
{
    public partial class frmMainWindow : Form
    {
        ComPortsLib ComPort = new ComPortsLib();

        //INI file class object
        INI_File ini = new INI_File();
        
        //Create system date/time object
        //DateTime dateTime = new DateTime();

        //Create a timer object
        //Timer timer = new Timer();
                
        static int time = 1;
        //static string hours = "0";
        //static string minutes = "0";
        //static string seconds = "0";
             
        public frmMainWindow()
        {
            InitializeComponent();
            InitializeApplicationTitle();
            InitialializeLabels();
            UserInitialization();
            //InitTimer();
            CreateChart();
            GetPorts();  
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Set application title to application name.  Include version info.
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void InitializeApplicationTitle()
        {
            this.Text = "Reflow Controller " + 
                Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Initialize serial port data receive event handler and form closing
        ///  event handler
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void UserInitialization()
        {
            ComPort.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(ComPort_NewSerialDataRecieved);
            
            this.FormClosing += new FormClosingEventHandler(Reflow_FormClosing);
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Initialize elapsed time object
        ///  event handler
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        //private void InitTimer()
        //{
        //    //Disable timer and set tick interval to 1sec
        //    timer.Enabled = false;
        //    timer.Interval = 1000;

        //    //Create an event for the timer object
        //    timer.Tick += new EventHandler(OnTimerEvent);
        //}

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Event handler for the timer object.  Tracks elapsed time
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        //private void OnTimerEvent(object sender, EventArgs e)
        //{
        //    //Keep track of the elapsed time since the application started
        //    TimeSpan span = DateTime.Now.Subtract(dateTime);

        //    //Track hours and roll over as necessary
        //    if (span.Hours < 10) { hours = "0" + span.Hours.ToString(); }
        //    else { hours = span.Hours.ToString(); }

        //    //Track minutes and roll over as necessary
        //    if (span.Minutes < 10) { minutes = "0" + span.Minutes.ToString(); }
        //    else { minutes = span.Minutes.ToString(); }

        //    //Track seconds and roll over as necessary
        //    if (span.Seconds < 10) { seconds = "0" + span.Seconds.ToString(); }
        //    else { seconds = span.Seconds.ToString(); }

        //    //Update the elapsed time label
        //    TotalTimeLabel.Text = hours + ":" + minutes + ":" + seconds;
        //}

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Create serial port data receive event handler
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void ComPort_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(ComPort_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            string state = e.state;
            string temperature = e.temperature;
            string setpoint = e.setpoint;
            string heater = e.heater;
            string auxiliary = e.auxiliary;
            string elapsed = e.elapsed;
            string start = e.start;
            string hours = e.hours;
            string minutes = e.minutes;
            string seconds = e.seconds;
            string Kp = e.Kp;
            string Ki = e.Ki;
            string Kd = e.Kd;
            string cycleTime = e.cycleTime;
            string pTerm = e.pTerm;
            string iTerm = e.iTerm;
            string dTerm = e.dTerm;
            string output = e.output;
        
            //Current stage
            switch (state)
            {
                case "0": CurrentStageLabel.Text = "WAITING"; break;
                case "1": CurrentStageLabel.Text = "PREHEAT"; break;
                case "2": CurrentStageLabel.Text = "SOAK"; break;
                case "3": CurrentStageLabel.Text = "HEATING"; break;
                case "4": CurrentStageLabel.Text = "REFLOW"; break;
                case "5": CurrentStageLabel.Text = "COOLING"; break;
                case "6": CurrentStageLabel.Text = "BAKE"; break;
            }
            
            //Current temperature
            TemperatureLabel.Text = temperature + "\u00b0" + "C";
            
            //Setpoint temperature
            SetPointLabel.Text = setpoint + "\u00b0" + "C";
            
            //Heater state (On/Off)
            switch (heater)
            {
                case "0": HeaterLabel.Text = "OFF"; break;
                case "1": HeaterLabel.Text = "ON"; break;
            }

            //Auxiliary state (On/Off)
            switch (auxiliary)
            {
                case "0": Auxiliary1Label.Text = "OFF"; break;
                case "1": Auxiliary1Label.Text = "ON"; break;
            }
            
            //Current stage remaining time
            if (elapsed == "0000") elapsed = "N/A";
                StageTimeLabel.Text = elapsed;

            ////Track elapsed time
            //switch (start)
            //{
            //    case "0":
            //        if (timer.Enabled == true)
            //        {
            //            timer.Enabled = false;
            //        }
            //        break;

            //    case "1":
            //        if (!(timer.Enabled))
            //        {
            //            dateTime = DateTime.Now;
            //            timer.Enabled = true;
            //        }
            //        break;
            //}

            //Update the elapsed time label
            TotalTimeLabel.Text = hours + ":" + minutes + ":" + seconds;

            //Enable or disable logging to datagrid control
            if (EnableLogCheckBox.Checked == true)
            {           
                //Add time and temperature values
                dataGridView1.Rows.Add();
                dataGridView1.Rows[time - 1].Cells[0].Value = time - 1;
                dataGridView1.Rows[time - 1].Cells[1].Value = temperature;
                dataGridView1.Rows[time - 1].Cells[2].Value = setpoint;

                //Track heater On/Off actions. Off = 0 and High = 20
                if (heater == "0") dataGridView1.Rows[time - 1].Cells[3].Value = "0";
                if (heater == "1") dataGridView1.Rows[time - 1].Cells[3].Value = "35";

                //Keep cursor on current row data
                dataGridView1.CurrentCell = dataGridView1.Rows[time - 1].Cells[0];

                KptoolStripStatusLabel.Text = "Kp = " + Kp;
                KitoolStripStatusLabel.Text = "Ki = " + Ki;
                KdtoolStripStatusLabel.Text = "Kd = " + Kd;
                cycleTimetoolStripStatusLabel.Text = "Cycle Time (Secs) = " + cycleTime;
                pTermtoolStripStatusLabel.Text = "pTerm = " + pTerm;
                iTermtoolStripStatusLabel.Text = "iTerm = " + iTerm;
                dtermtoolStripStatusLabel.Text = "dTerm = " + dTerm;
                outPuttoolStripStatusLabel.Text = "Output = " + output;

                //Make sure the curve list has at least one curve value
                if (zedGraphControl1.GraphPane.CurveList.Count <= 0) return;

                //Get the furst curve item in the graph
                LineItem curve = zedGraphControl1.GraphPane.CurveList[0] as LineItem;

                //Set line thickness
                curve.Line.Width = 2.0F;

                //Make sure there is at least one curve value
                if (curve == null) return;

                //Get the point pair list
                IPointListEdit list = curve.Points as IPointListEdit;

                //If this is null it means the reference at curve.Points does not
                //support IPointListEdit so, we won't be able to modify it
                if (list == null) return;

                //Add time and temperature values to list
                list.Add(time, Convert.ToDouble(temperature));

                //Make sure each axis is rescaled to accommodate actual data
                zedGraphControl1.AxisChange();

                //Force a redraw
                zedGraphControl1.Invalidate();

                //Advance time variable
                time++;
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Save default port settings so they can be restore next application
        ///  start up.
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void Reflow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close serial port
            ComPort.ClosePort();

            if (PortsComboBox.SelectedItem != null)
            {
                //Save current port settings
                Settings.Default.port = PortsComboBox.SelectedItem.ToString();
                Settings.Default.baudrate = BaudRateComboBox.SelectedItem.ToString();
                Settings.Default.Save();
            }

            ////Disable timer
            //timer.Enabled = false;
            
            ////Release resources from timer object
            //timer.Dispose();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Initialize label controls with default data
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void InitialializeLabels()
        {
            TemperatureLabel.Text = "000" + "\u00b0" + "C";
            SetPointLabel.Text = "000" + "\u00b0" + "C";
            StageTimeLabel.Text = "N/A";
            CurrentStageLabel.Text = "WAITING";
            TotalTimeLabel.Text = "00:00:00";
            HeaterLabel.Text = "OFF";
            Auxiliary1Label.Text = "OFF";
            Auxiliary2Label.Text = "OFF";
            toolStripStatusLabel1.Text = "Status: Not connected to port";
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Create chart control
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void CreateChart()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            //Set title axis labels and font color
            myPane.Title.Text = "Temperature vs. Time";
            myPane.Title.FontSpec.FontColor = Color.Black;

            myPane.XAxis.Title.Text = "Time (Sec)";
            myPane.XAxis.Title.FontSpec.FontColor = Color.Black;
            
            myPane.YAxis.Title.Text = "Temperature (Celcius)";         
            myPane.YAxis.Title.FontSpec.FontColor = Color.Black;
            
            //Fill the chart background with a color gradient
            myPane.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
            myPane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);

            //Add grid lines to the plot and make them gray
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = Color.LightGray;

            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.Color = Color.LightGray;

            //Enable point value tooltips and handle point value event
            zedGraphControl1.IsShowPointValues = true;
            zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(PointValueHandler);

            //Show the horizontal scroll bar
            zedGraphControl1.IsShowHScrollBar = true;

            //Automatically set the scrollable range to cover the data range from the curves
            zedGraphControl1.IsAutoScrollRange = true;

            //Add 10% to scale range
            zedGraphControl1.ScrollGrace = 0.1;

            //Horizontal pan and zoom allowed
            zedGraphControl1.IsEnableHPan = true;
            zedGraphControl1.IsEnableHZoom = true;

            //Vertical pan and zoom not allowed
            zedGraphControl1.IsEnableVPan = false;
            zedGraphControl1.IsEnableVZoom = false;

            //Set the initial viewed range
            //zedGraphControl1.GraphPane.XAxis.Scale.MinAuto = true;
            //zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;

            //Let Y-Axis range adjust to data range
            zedGraphControl1.GraphPane.IsBoundedRanges = true;

            //Set the margins to 10 points
            myPane.Margin.All = 10;

            //Hide the legend
            myPane.Legend.IsVisible = false;

            //Set start point for XAxis scale
            myPane.XAxis.Scale.BaseTic = 0;

            //Set start point for YAxis scale
            myPane.YAxis.Scale.BaseTic = 0;

            //Set max/min XAxis range
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 1000;
            myPane.XAxis.Scale.MinorStep = 10;
            myPane.XAxis.Scale.MajorStep = 30;

            //Set max/min YAxis range
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 250;
            myPane.YAxis.Scale.MinorStep = 10;
            myPane.YAxis.Scale.MajorStep = 20;

            //Save 7400 points.  The RollingPointPairList is an efficient storage class that always
            //keeps a rolling set of point data without needing to shift any data values
            RollingPointPairList list = new RollingPointPairList(7400);

            //Initially, a curve is added with no data points (list is empty)
            //Color is red, and there will be no symbols
            LineItem curve = myPane.AddCurve("Temperature", list, Color.Red, SymbolType.None);

            //Scale the axis
            myPane.AxisChange();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Show tooltips when the mouse hovers over a point
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private string PointValueHandler(ZedGraphControl control, GraphPane pane, CurveItem curve, int Pt)
        {
            //Get the point pair that is under the mouse
            PointPair pt = curve[Pt];
            return "Time: " + pt.X.ToString() + " Temp: " + pt.Y.ToString();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Get available serial ports and restore last used port values
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void GetPorts()
        {
            //Get list of available ports and store in array
            string[] ports = ComPort.GetAvailablePorts();
            
            //Array of baud rates
            string[] baudrates = {"75", "110", "134", "150", "300", "600", "1200", "1800",
                                 "2400", "4800", "7200", "9600", "14400", "19200", "38400",
                                 "57600", "115200", "128000"};
            
            //Variable used to search array of ports for previously used port
            int found = 0;

            if (ports.Length != 0)
            {
                //Set data source for port selection combobox
                PortsComboBox.DataSource = ports;

                //Set data source for baud rate combobox
                BaudRateComboBox.DataSource = baudrates;

                //Search ports array for previously used port or until end of array
                while (!((ports[found] == Settings.Default.port) | (found == ports.GetUpperBound(0)))) { found++; }

                //If desired port is not found then, select the first port in the array of ports
                if (found == ports.GetUpperBound(0)) PortsComboBox.SelectedItem = ports[0];

                //If desired port is found then, select the desired port
                if (ports[found] == Settings.Default.port) PortsComboBox.SelectedItem = Settings.Default.port;

                //Set baud rate to previously used baud rate
                BaudRateComboBox.SelectedItem = Settings.Default.baudrate;
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Connect serial port
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void ConnectPort()
        {
            if (PortsComboBox.SelectedItem != null)
            {
                //Get selected port
                string Port = PortsComboBox.SelectedItem.ToString();

                //Get selected baud rate
                string BaudRate = BaudRateComboBox.SelectedItem.ToString();

                //Get default remainder port settings 
                string DataBits = Settings.Default.databits;
                string Parity = Settings.Default.parity;
                string StopBits = Settings.Default.stopbits;
                string Handshake = Settings.Default.handshake;

                if (ComPort.IsPortOpen() == false)
                {
                    //Open selected port
                    ComPort.OpenPort(Port, BaudRate, DataBits, Parity, StopBits, Handshake);

                    //Update status label
                    toolStripStatusLabel1.Text = "Status: Connected to " + PortsComboBox.SelectedValue +
                        " at " + BaudRateComboBox.SelectedValue + " baud";

                    //Clear data grid and reset time variable
                    ClearData();

                    //Disable certain controls while port is connected
                    DisableControls();
                }
            }

            //Error opening port
            else
            {
                DialogResult dlgResult = MessageBox.Show("Error opening serial port.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Disconnect from serial port
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void DisconnectPort()
        {
            if (ComPort.IsPortOpen() == true)
            {
                //If heater auxiliary output is on then turn off
                if (AuxiliaryButton2_Press == 1)
                {
                    //Turn off auxiliary output
                    ComPort.SetPin(3, 0);

                    //Set auxiliay status label
                    Auxiliary1Label.Text = "OFF";

                    //Update heater fan flag
                    AuxiliaryButton2_Press = 0;
                }

                //Close port
                ComPort.ClosePort();

                ////Disable timer
                //timer.Enabled = false;

                ////Release resources from timer object
                //timer.Dispose();

                //Update status label
                toolStripStatusLabel1.Text = "Status: Disconnected from " + PortsComboBox.SelectedValue +
                        " at " + BaudRateComboBox.SelectedValue + " baud";

                //Re-enable previously disables controls
                EnableControls();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Disable selected controls
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void DisableControls()
        {
            ClearDataButton.Enabled = false;
            SaveLogFileButton.Enabled = false;
            viewToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            EnableLogCheckBox.Enabled = false;
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Enable selected controls
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void EnableControls()
        {
            ClearDataButton.Enabled = true;
            SaveLogFileButton.Enabled = true;
            viewToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            EnableLogCheckBox.Enabled = true;
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Uploads selected profile to controller
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void UploadProfile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string path = Environment.CurrentDirectory;

            if (Directory.Exists(path))
            {
                if (ComPort.IsPortOpen() == true)
                {
                    openFileDialog.Title = "Upload Profile";
                    openFileDialog.InitialDirectory = path;
                    openFileDialog.Filter = "INI (*.ini)|*.ini";

                    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        path = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                        
                        string filename = openFileDialog.SafeFileName;
                        string fileType = ini.ReadINI(filename, "FILE TYPE", "VALUE", path);

                        if (fileType == "Profile")
                        {
                            ComPort.UploadProfile(openFileDialog.SafeFileName, path);
                        }

                        else
                        {
                            MessageBox.Show("The file you are attempting to upload is not a Profile.\n" +
                                     "Please check the file type.  The upload has been cancelled.",
                                     "Error Uploading File",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Upload PID gains to controller
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void UploadPID()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string path = Environment.CurrentDirectory;

            if (Directory.Exists(path))
            {
                if (ComPort.IsPortOpen() == true)
                {
                    openFileDialog.Title = "Upload PID Gains";
                    openFileDialog.InitialDirectory = path;
                    openFileDialog.Filter = "INI (*.ini)|*.ini";

                    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        path = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                        
                        string filename = openFileDialog.SafeFileName;
                        string fileType = ini.ReadINI(filename, "FILE TYPE", "VALUE", path);

                        if (fileType == "PID")
                        {
                            ComPort.UploadPID(openFileDialog.SafeFileName, path);
                        }

                        else
                        {
                            MessageBox.Show("The file you are attempting to upload is not a PID file.\n" +
                                     "Please check the file type.  The upload has been cancelled.",
                                     "Error Uploading File",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Saves chart data to a file
        ///  ins: SoapSerialize() procedure
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void SaveChartFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            string path = Environment.CurrentDirectory + @"\Charts";

            saveFileDialog.Title = "Save Chart";
            saveFileDialog.InitialDirectory = path;
            saveFileDialog.Filter = "Soap (*.soap)|*.soap";

            if (!(Directory.Exists(path)))
            {
                Directory.CreateDirectory(path);
            }

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                SoapSerialize(zedGraphControl1, saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Open chart data file
        ///  ins: SoapDeSerialize() procedure
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void OpenChartFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string path = Environment.CurrentDirectory + @"\Charts";

            openFileDialog.Title = "Save Chart";
            openFileDialog.InitialDirectory = path;
            openFileDialog.Filter = "Soap (*.soap)|*.soap";

            if (!(Directory.Exists(path)))
            {
                Directory.CreateDirectory(path);
            }

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                SoapDeSerialize(zedGraphControl1, openFileDialog.FileName);

                zedGraphControl1.Refresh();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Save a chart image
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void SaveChartImage()
        {
            //Set default path for chart images
            string path = Environment.CurrentDirectory + @"\Chart Images";

            //Set save dialog title, initial path and image filters
            zedGraphControl1.SaveFileDialog.Title = "Save Chart Image";
            zedGraphControl1.SaveFileDialog.InitialDirectory = path;
            zedGraphControl1.SaveFileDialog.Filter = "PNG (*.png)|*.png|" +
                                                     "BMP (*.bmp)|*.bmp|" +
                                                     "JPEG (*.jpg)|*.jpg|" +
                                                     "GIF (*.gif)|*.gif|" +
                                                     "TIF (*.tiff)|*.tiff|" +
                                                     "EMF (*.emf)|*.emf";

            //Create directory if it does not exist
            if (!(Directory.Exists(path))) Directory.CreateDirectory(path);

            //If OK button clicked and the file name is not blank then, save image using selected filter
            if (zedGraphControl1.SaveFileDialog.ShowDialog(this) == DialogResult.OK && zedGraphControl1.SaveFileDialog.FileName != "")
            {
                //Create filestream object and save image using OpenFile method
                System.IO.FileStream fs = (System.IO.FileStream)zedGraphControl1.SaveFileDialog.OpenFile();

                //Save image using the image FilterIndex property
                switch (zedGraphControl1.SaveFileDialog.FilterIndex)
                {
                    case 1: this.zedGraphControl1.GetImage().Save(fs, System.Drawing.Imaging.ImageFormat.Png); break;
                    case 2: this.zedGraphControl1.GetImage().Save(fs, System.Drawing.Imaging.ImageFormat.Bmp); break;
                    case 3: this.zedGraphControl1.GetImage().Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case 4: this.zedGraphControl1.GetImage().Save(fs, System.Drawing.Imaging.ImageFormat.Gif); break;
                    case 5: this.zedGraphControl1.GetImage().Save(fs, System.Drawing.Imaging.ImageFormat.Tiff); break;
                    case 6: this.zedGraphControl1.GetImage().Save(fs, System.Drawing.Imaging.ImageFormat.Emf); break;
                }
                
                //Close filestream object
                fs.Close();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Open a chart image
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void OpenChartImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Set default path for chart images
            string path = Environment.CurrentDirectory + @"\Chart Images";

            //Set open file dialog title, initial path and image filters
            openFileDialog.Title = "Open Chart Image";
            openFileDialog.InitialDirectory = path;
            openFileDialog.Filter = "PNG (*.png)|*.png|" +
                                    "BMP (*.bmp)|*.bmp|" +
                                    "JPEG (*.jpg)|*.jpg|" +
                                    "GIF (*.gif)|*.gif|" +
                                    "TIF (*.tiff)|*.tiff|" +
                                    "EMF (*.emf)|*.emf|" + 
                                    "All (*.*)|*.*";

            //Make sure directory exists before attempting to open an image
            if (Directory.Exists(path))
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK) System.Diagnostics.Process.Start(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Open a profile for viewing
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void OpenProfile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Set default path for profiles
            string path = Environment.CurrentDirectory + @"\Profiles";

            //Set open file dialog title, initial path and document filter
            openFileDialog.Title = "View Profile";
            openFileDialog.InitialDirectory = path;
            openFileDialog.Filter = "INI (*.ini)|*.ini";

            //Make sure directory exists before attempting to open a profile document
            if (Directory.Exists(path))
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK) System.Diagnostics.Process.Start(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Open a PID file for viewing
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void OpenPIDfile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Set default path for profiles
            string path = Environment.CurrentDirectory + @"\PID";

            //Set open file dialog title, initial path and document filter
            openFileDialog.Title = "View PID File";
            openFileDialog.InitialDirectory = path;
            openFileDialog.Filter = "INI (*.ini)|*.ini";

            //Make sure directory exists before attempting to open a profile document
            if (Directory.Exists(path))
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK) System.Diagnostics.Process.Start(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Open a log file for viewing
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void OpenLogFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Set default path for log files
            string path = Environment.CurrentDirectory + @"\Logs";

            //Set open file dialog title, initial path and document filter
            openFileDialog.Title = "View Log File";
            openFileDialog.InitialDirectory = path;
            openFileDialog.Filter = "CSV (*.csv) |*.csv";

            //Make sure directory exists before attempting to open a log file
            if (Directory.Exists(path))
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK) System.Diagnostics.Process.Start(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Export data from gridview to CSV file (Excel compatible)
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void SaveLogFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            //Variable to store contents from each datagrid cell
            string data = string.Empty;


            //Only export if disconnected from serial port
            if (!(ComPort.IsPortOpen() == true))
            {
                //Ensure we are not attempting to export an empty log file
                if (dataGridView1.Rows.Count != 1)
                {
                    //Set the default directory path and file extension
                    string path = Environment.CurrentDirectory + @"\Logs";

                    saveFileDialog.InitialDirectory = path;
                    saveFileDialog.Filter = "CSV (*.csv)|*.csv";

                    //Make sure the directory exist or create one
                    if (!(Directory.Exists(path)))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        //Create a file stream write object
                        using (StreamWriter myFile = new StreamWriter(saveFileDialog.FileName, false, Encoding.Default))
                        {
                            //Get the column header text first
                            foreach (DataGridViewColumn dataColumns in dataGridView1.Columns)
                            {
                                data += dataColumns.HeaderText + ",";
                            }

                            //Get row data
                            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                                {
                                    if (!string.IsNullOrEmpty(dataGridView1[j, i].Value.ToString()))
                                    {
                                        if (j > 0)
                                        {
                                            data += "," + dataGridView1[j, i].Value.ToString();
                                        }

                                        else
                                        {
                                            if (string.IsNullOrEmpty(data))
                                            {
                                                data = dataGridView1[j, i].Value.ToString();
                                            }

                                            else
                                            {
                                                data += Environment.NewLine + dataGridView1[j, i].Value.ToString();
                                            }
                                        }
                                    }
                                }
                            }

                            //Write data to file and close file
                            myFile.Write(data);
                            myFile.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Save chart data to a file
        ///  ins: graph object, file name
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void SoapSerialize(ZedGraphControl z1, string filename)
        {
            if (z1 != null && !String.IsNullOrEmpty(filename))
            {
                SoapFormatter mySerializer = new SoapFormatter();
                Stream myWriter = new FileStream(filename, FileMode.Create,
                      FileAccess.Write, FileShare.None);

                mySerializer.Serialize(myWriter, z1.MasterPane);
                myWriter.Close();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Load chart data from a file
        ///  ins: graph object, file name
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void SoapDeSerialize(ZedGraphControl z1, string filename)
        {
            if (z1 != null && !String.IsNullOrEmpty(filename))
            {
                SoapFormatter mySerializer = new SoapFormatter();
                Stream myReader = new FileStream(filename, FileMode.Open,
                   FileAccess.Read, FileShare.Read);

                z1.GraphPane.CurveList.Clear();
                MasterPane master = (MasterPane)mySerializer.Deserialize(myReader);
                
                z1.MasterPane = master;
                
                //trigger a resize event
                z1.Size = z1.Size;
         
                //z1.Refresh();   
                
                myReader.Close();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Open application help file
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void OpenHelpFile()
        {
            //Set default path for help file
            string path = Environment.CurrentDirectory + @"\Help\Help.pdf";

            if (File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }

            else
            {
                DialogResult dlgResult = MessageBox.Show("Help file not found.  " +
                "Check Help directory for file existence.",
                "Help", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Clear data from grid and chart
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void ClearData()
        {
            //Clear data grid contents
            this.dataGridView1.Rows.Clear();

            //Reset time variable
            time = 1;

            //Clear all the curve items and recreate the chart
            zedGraphControl1.GraphPane.CurveList.Clear();

            //Reset chart control
            zedGraphControl1.Invalidate();
            CreateChart();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Procedure to launch bootloader application for controller updates
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void UpdateFirmware()
        {
            //Get default path for loader application
            string path = Settings.Default.firmwarepath;

            if (!(path == ""))
            {
                int portflag = 0;

                Process p = new Process();

                p.StartInfo.FileName = path;

                if (ComPort.IsPortOpen() == true)
                {
                    ComPort.ClosePort();

                    portflag = 1;
                }

                //Start process
                p.Start();

                //Disable main form until loader thread exits
                while (p.HasExited == false) System.Threading.Thread.Sleep(1000);

                //Reconnect port if it was closed to allow loader access to port
                if (ComPort.IsPortOpen() == false && portflag == 1) ConnectPort();
            }

            else
            {
                DialogResult dlgResult = MessageBox.Show("Firmware loader not found.  " +
                "Check application configuration settings in the Configuration Menu.",
                "Update Controller Firmware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Procedure to launch hardware programmer for controller updates.
        ///  Used to load firmware if bootloader is not used
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void OpenProgrammer()
        {
            //Get default path for programmer application
            string path = Settings.Default.programmerpath;

            if (!(path == ""))
            {
                int portflag = 0;

                Process p = new Process();

                p.StartInfo.FileName = path;

                if (ComPort.IsPortOpen() == true)
                {
                    ComPort.ClosePort();

                    portflag = 1;
                }

                //Start process
                p.Start();

                //Disable main form until loader thread exits
                while (p.HasExited == false) System.Threading.Thread.Sleep(1000);

                //Reconnect port if it was closed to allow loader access to port
                if (ComPort.IsPortOpen() == false && portflag == 1) ConnectPort();
            }

            else
            {
                DialogResult dlgResult = MessageBox.Show("Hardware programmer not found.  " +
                "Check application configuration settings in the Configuration Menu.",
                "Open Hardware Programmer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Procedure to launch program editor for controller updates.
        ///  Used to edit firmware.
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void OpenEditor()
        {
            //Get default path for editor application
            string path = Settings.Default.editorpath;

            if (!(path == ""))
            {
                int portflag = 0;

                Process p = new Process();

                p.StartInfo.FileName = path;

                if (ComPort.IsPortOpen() == true)
                {
                    ComPort.ClosePort();

                    portflag = 1;
                }

                //Start process
                p.Start();

                //Disable main form until loader thread exits
                while (p.HasExited == false) System.Threading.Thread.Sleep(1000);

                //Reconnect port if it was closed to allow loader access to port
                if (ComPort.IsPortOpen() == false && portflag == 1) ConnectPort();
            }

            else
            {
                DialogResult dlgResult = MessageBox.Show("Program editor not found.  " +
                "Check application configuration settings in the Configuration Menu.",
                "Open Program Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to test temperature sensor
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void testTemperatureSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComPort.SensorTest();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to start reflow profile
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void reflowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComPort.Reflow();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to start bake profile
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void bakeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComPort.Bake();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to setup real time clock
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void configureRTCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComPort.SetRTC();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to open create/edit profile dialog window
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void createEditProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfileSettings ProfileSettingsWindow = new frmProfileSettings();
            ProfileSettingsWindow.ShowDialog();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to upload a new profile to controller
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void uploadProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadProfile();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Reset controller
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComPort.ResetController();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to save a excel compatible CSV log file
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void saveLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLogFile();
        }
        
        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to open a log file for viewing
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void openLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLogFile();
        }
        
        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to open a profile document for viewing
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void openProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProfile();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to open a PID document for viewing
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void pidFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPIDfile();
        }
        
        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to open a chart image
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void openChartImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChartImage();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to save a chart image
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void saveChartImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChartImage();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to open a chart data file
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void openChartFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChartFile();

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
                this.WindowState = FormWindowState.Maximized;
            }

            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.WindowState = FormWindowState.Normal;
            }
        }
        
        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to save chart data file
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void saveChartFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChartFile();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to set page settings for printer
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zedGraphControl1.DoPageSetup();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button print preview
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zedGraphControl1.DoPrintPreview();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to print chart image
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zedGraphControl1.DoPrint();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to exit application
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close serial port
            if (ComPort.IsPortOpen() == true) ComPort.ClosePort();

            //Disable timer
            //timer.Enabled = false;

            //exit application
            this.Close();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to launch firmware update tool
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void updateFirmwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateFirmware();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to launch hardware programmer tool
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void openProgrammerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProgrammer();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to launch program editor tool
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void openEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditor();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to open help file
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void helpTopicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHelpFile();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Menu button to launch application settings form
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void applicationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppSettings frmSettingsWindow = new frmAppSettings();
            frmSettingsWindow.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult dlgResult = MessageBox.Show("Hobbybotis Reflow Controller\n" +
            //    "Version: 6.00\n" + "4/23/2011",
            //    "About", MessageBoxButtons.OK, MessageBoxIcon.None);

            frmAboutBox AboutBox = new frmAboutBox();
            AboutBox.ShowDialog();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to connect to serial port
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ConnectPort();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to disconnect from serial port
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            DisconnectPort();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to open device manager
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void PropertiesButton_Click(object sender, EventArgs e)
        {
            //Open device manager hardware settings
            System.Diagnostics.Process.Start("devmgmt.msc");
        }

        static int AuxiliaryButton2_Press = 0;

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to turn ON/OFF Auxiliary Output
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        /// 
        private void AuxiliaryButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (ComPort.IsPortOpen() == true)
            {
                if (AuxiliaryButton2_Press == 0)
                {
                    //Set I/O pin A1 High
                    ComPort.SetPin(3, 1);
                    Auxiliary2Label.Text = "ON";
                    AuxiliaryButton2_Press = 1;
                }

                else
                {
                    //Set I/O pin A1 Low
                    ComPort.SetPin(3, 0);
                    Auxiliary2Label.Text = "OFF";
                    AuxiliaryButton2_Press = 0;
                }
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to export gridview data to CSV file
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void SaveLogFileButton_Click(object sender, EventArgs e)
        {
            SaveLogFile();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to clear gridview data
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void ClearDataButton_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to get current PID values from controller.  Also returns
        ///  current profile state, current temperature, current setpoint temperature,
        ///  current state of relays 0 and 1, current elapsed time
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void getPIDGainsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (EnableLogCheckBox.Checked == true) EnableLogCheckBox.Checked = false;
            ComPort.GetSensorSettings();
            //if (EnableLogCheckBox.Checked == false) EnableLogCheckBox.Checked = true;
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to edit PID and save PID profile values
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void editPIDParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPIDSettings PIDSettingsWindow = new frmPIDSettings();
            PIDSettingsWindow.ShowDialog();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Button to upload PID values to controller
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        private void uploadPIDGainsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadPID();
        }
    }
}
