using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.IO;

namespace FileLib
{
    public class INI_File
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);

        //------------------------------------------------------------------------------
        //  Write value to INI file
        //------------------------------------------------------------------------------
        public void WriteINI(string filename, string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path + "\\" + filename);
        }

        //------------------------------------------------------------------------------
        //  Read a value from INI file
        //------------------------------------------------------------------------------
        public string ReadINI(string filename, string section, string key, string path)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, path + "\\" + filename);
            return temp.ToString();
        }
    }
}
