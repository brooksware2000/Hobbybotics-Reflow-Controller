using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
//using System.Runtime.Remoting.Messaging;
//using System.ComponentModel;
using System.Reflection;
using System.Threading;
using FileLib;
using DS1307Lib;

namespace ComPorts
{
    public class ComPortsLib : IDisposable
    {
        //Serial port class object
        SerialPort ComPort = new SerialPort();
        
        //INI file class object
        INI_File ini = new INI_File();

        //DS1307 Real-time clock object
        RTC_DS1307 RTC = new RTC_DS1307();

        //Event handler for serial receive method
        public event EventHandler<SerialDataEventArgs> NewSerialDataRecieved;

        //Class destructor
        ~ComPortsLib()
        {
            Dispose(false);
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Opens the serial port
        ///  ins: none
        ///  outs: returns True for port successfully opened or False if port is already
        ///  closed
        ///------------------------------------------------------------------------------
        /// </summary>
        public void OpenPort(string PortName, string BaudRate, string DataBits,
            string Parity, string StopBits, string Handshake)
        {           
            if (ComPort != null && IsPortOpen() == false)
            {
                ComPort.PortName = PortName;
                ComPort.BaudRate = Convert.ToInt32(BaudRate);
                ComPort.DataBits = Convert.ToInt32(DataBits);
                ComPort.Parity = (Parity)Enum.Parse(typeof(Parity), Parity);
                ComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), StopBits);
                ComPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), Handshake);
                ComPort.Encoding = System.Text.Encoding.Default;
                ComPort.ReadTimeout = 1000;
                ComPort.WriteTimeout = 1000;

                ComPort.DataReceived += new SerialDataReceivedEventHandler(ComPort_DataReceived);

                ComPort.Open();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Event to receive data from serial port
        ///  ins: none
        ///  outs: none
        ///------------------------------------------------------------------------------
        /// </summary>
        public void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int numBytesToRead = 19;

            if (ComPort.BytesToRead == numBytesToRead)
            {
                byte[] byteBuffer = new byte[numBytesToRead];

                ComPort.Read(byteBuffer, 0, ComPort.BytesToRead);

                if (NewSerialDataRecieved != null)
                    NewSerialDataRecieved(this, new SerialDataEventArgs(byteBuffer));
            }

            //else return;
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        /// Procedure: Call to release serial port 
        /// ins: boolean true or false
        /// outs: none
        ///------------------------------------------------------------------------------
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        /// Procedure: Implements the dispose function to delete serial port event 
        /// handler
        /// ins: boolean true or false
        /// outs: none
        ///------------------------------------------------------------------------------
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ComPort.DataReceived -= new SerialDataReceivedEventHandler(ComPort_DataReceived);
            }
            // Releasing serial port (and other unmanaged objects)
            if (ComPort != null)
            {
                if (ComPort.IsOpen) ComPort.Close();

                ComPort.Dispose();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        /// Procedure: Releases serial port event
        /// ins: boolean true or false
        /// outs: none
        ///------------------------------------------------------------------------------
        /// </summary>
        public void ClosePort()
        {
            if (IsPortOpen() == true) ComPort.Close();
            Dispose(true);
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Checks for a open port
        ///  ins: none
        ///  outs: returns True or False
        ///------------------------------------------------------------------------------
        /// </summary>
        public bool IsPortOpen()
        {
            if (ComPort.IsOpen == true) return true;
            else return false;
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Get all available serial ports
        ///  ins: none
        ///  outs: installed ports - ports[]
        /// ------------------------------------------------------------------------------
        /// </summary>
        public string[] GetAvailablePorts()
        {
            string [] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            return ports;
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Upload a reflow profile to controller
        ///  ins: profile name and directory path
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void UploadProfile(string filename, string path)
        {
            if (IsPortOpen() == true)
            {
                byte[] dataToSend = new byte[] { 254, 0 };

                ComPort.Write(dataToSend, 0, dataToSend.Length);

                dataToSend = new byte[7];

                Thread.Sleep(500);

                dataToSend[0] = Convert.ToByte(ini.ReadINI(filename, "SOAK TEMPERATURE", "VALUE", path));
                dataToSend[1] = Convert.ToByte(ini.ReadINI(filename, "SOAK TIME", "VALUE", path));
                dataToSend[2] = Convert.ToByte(ini.ReadINI(filename, "REFLOW TEMPERATURE", "VALUE", path));
                dataToSend[3] = Convert.ToByte(ini.ReadINI(filename, "REFLOW TIME", "VALUE", path));
                dataToSend[4] = Convert.ToByte(ini.ReadINI(filename, "BAKE TEMPERATURE", "VALUE", path));
                dataToSend[5] = Convert.ToByte(ini.ReadINI(filename, "BAKE TIME", "VALUE", path).Substring(0, 2));
                dataToSend[6] = Convert.ToByte(ini.ReadINI(filename, "BAKE TIME", "VALUE", path).Substring(2, 2));

                ComPort.Write(dataToSend, 0, dataToSend.Length);
                ComPort.DiscardOutBuffer();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Starts a reflow process
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void Reflow()
        {
            if (IsPortOpen() == true)
            {
                byte[] dataToSend = new byte[] { 254, 1 };

                ComPort.Write(dataToSend, 0, dataToSend.Length);
                ComPort.DiscardOutBuffer();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Starts a bake process
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void Bake()
        {
            if (IsPortOpen() == true)
            {
                byte[] dataToSend = new byte[] { 254, 2 };

                ComPort.Write(dataToSend, 0, dataToSend.Length);
                ComPort.DiscardOutBuffer();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Upload PID gains to controller
        ///  ins: profile name and directory path
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void UploadPID(string filename, string path)
        {
            if (IsPortOpen() == true)
            {
                byte[] dataToSend = new byte[] { 254, 3 };

                ComPort.Write(dataToSend, 0, dataToSend.Length);

                dataToSend = new byte[4];

                Thread.Sleep(500);

                dataToSend[0] = Convert.ToByte(ini.ReadINI(filename, "KP", "VALUE", path));
                dataToSend[1] = Convert.ToByte(ini.ReadINI(filename, "KI", "VALUE", path));
                dataToSend[2] = Convert.ToByte(ini.ReadINI(filename, "KD", "VALUE", path));
                dataToSend[3] = Convert.ToByte(ini.ReadINI(filename, "CYCLE TIME", "VALUE", path));

                ComPort.Write(dataToSend, 0, dataToSend.Length);
                ComPort.DiscardOutBuffer();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Sets DS1307 real-time clock
        ///  ins: none
        ///  outs: hour (24hr clock), minutes (0-59), seconds (0-59), day-of-week (1-7), 
        ///  day-of-month (1-31), and year (1-12)
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void SetRTC()
        {
            //string rtcHours = RTC.getHours();
            //string rtcMinutes = RTC.getMinutes();
            //string rtcSeconds = RTC.getSeconds();
            //string rtcDayOfWeek = RTC.getDayOfWeek();
            //string rtcMonth = RTC.getMonth();
            //string rtcDayOfMonth = RTC.getDayOfMonth();
            //string rtcYear = RTC.getYear();

            //if (IsPortOpen() == true)
            //{
            //    byte[] dataToSend = new byte[] { 254, 8 };

            //    ComPort.Write(dataToSend, 0, dataToSend.Length);
            //    ComPort.DiscardOutBuffer();

            //    Thread.Sleep(500);

            //    dataToSend = new byte[7];

            //    dataToSend[0] = Convert.ToByte(rtcSeconds);
            //    dataToSend[1] = Convert.ToByte(rtcMinutes);
            //    dataToSend[2] = Convert.ToByte(rtcHours);
            //    dataToSend[3] = Convert.ToByte(rtcDayOfWeek);
            //    dataToSend[4] = Convert.ToByte(rtcDayOfMonth);
            //    dataToSend[5] = Convert.ToByte(rtcMonth);
            //    dataToSend[6] = Convert.ToByte(rtcYear);

            //    ComPort.Write(dataToSend, 0, dataToSend.Length);
            //    ComPort.DiscardOutBuffer();
            //}
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Reads temperature from DS6675 sensor
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void SensorTest()
        {
            if (IsPortOpen() == true)
            {
                byte[] dataToSend = new byte[] { 254, 4 };

                ComPort.Write(dataToSend, 0, dataToSend.Length);
                ComPort.DiscardOutBuffer();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Reboots the controller
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void ResetController()
        {
            if (IsPortOpen() == true)
            {
                byte[] dataToSend = new byte[] { 254, 5 };

                ComPort.Write(dataToSend, 0, dataToSend.Length);
                ComPort.DiscardOutBuffer();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Sets selected output pin High or Low
        ///  ins: pin - pin to set. state - 1 = High, 0 = Low
        ///  outs: none
        ///  notes: pin values are 1..11. Pin 1 is relay 1 and pin 2 is relay 2.
        ///  Pins 3..8 are associated with outputs A0..A5.  Pins 9..11 are associated
        ///  with LEDs 1..3 respectively.
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void SetPin(int pin, int state)
        {
            if (IsPortOpen() == true)
            {
                byte[] dataToSend = new byte[] { 254, 6 };

                ComPort.Write(dataToSend, 0, dataToSend.Length);
                ComPort.DiscardOutBuffer();

                Thread.Sleep(500);

                dataToSend = new byte[2];

                dataToSend[0] = Convert.ToByte(pin);
                dataToSend[1] = Convert.ToByte(state);

                ComPort.Write(dataToSend, 0, dataToSend.Length);
                ComPort.DiscardOutBuffer();
            }
        }

        /// <summary>
        /// ------------------------------------------------------------------------------
        ///  Procedure: Reads current settings from DS6675 sensor. Good for checking PID
        ///  and profile settings.
        ///  ins: none
        ///  outs: none
        /// ------------------------------------------------------------------------------
        /// </summary>
        public void GetSensorSettings()
        {
            if (IsPortOpen() == true)
            {
                byte[] dataToSend = new byte[] { 254, 7 };

                ComPort.Write(dataToSend, 0, dataToSend.Length);
                ComPort.DiscardOutBuffer();
            }
        }
    }

    /// <summary>
    /// ------------------------------------------------------------------------------
    ///  EventArgs used to send bytes recieved on serial port
    /// ------------------------------------------------------------------------------
    /// </summary>
    public class SerialDataEventArgs : EventArgs
    {
        public string state;
        public string temperature;
        public string setpoint;
        public string heater;
        public string auxiliary;
        public string elapsed;
        public string start;
        public string hours;
        public string minutes;
        public string seconds;
        public string Kp;
        public string Ki;
        public string Kd;
        public string cycleTime;
        public string pTerm;
        public string iTerm;
        public string dTerm;
        public string output;

        public SerialDataEventArgs(byte[] dataInByteArray)
        {
            state = dataInByteArray[0].ToString();
            temperature = dataInByteArray[1].ToString();
            setpoint = dataInByteArray[2].ToString();
            heater = dataInByteArray[3].ToString();
            auxiliary = dataInByteArray[4].ToString();
            elapsed = ((dataInByteArray[5] * 0x100) | dataInByteArray[6]).ToString().PadLeft(4, '0');
            start = dataInByteArray[7].ToString();
            hours = dataInByteArray[8].ToString().PadLeft(2, '0');
            minutes = dataInByteArray[9].ToString().PadLeft(2, '0');
            seconds = dataInByteArray[10].ToString().PadLeft(2, '0');
            Kp = dataInByteArray[11].ToString();
            Ki = dataInByteArray[12].ToString();
            Kd = dataInByteArray[13].ToString();
            cycleTime = dataInByteArray[14].ToString();
            pTerm = dataInByteArray[15].ToString();
            iTerm = dataInByteArray[16].ToString();
            dTerm = dataInByteArray[17].ToString();
            output = dataInByteArray[18].ToString();
        }
    }
}
