using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System;
using System.Reflection;

namespace ReflowController
{
    public partial class frmAboutBox : Form
    {
        public frmAboutBox()
        {
            InitializeComponent();
            UpdateLabels();
        }

        private string GetCopyrightInfo()
        {
            Assembly assemblyInfo = Assembly.GetExecutingAssembly();
            object[] objects = assemblyInfo.GetCustomAttributes(false);

            foreach (object obj in objects)
            {
                if (obj.GetType() == typeof(System.Reflection.AssemblyCopyrightAttribute))
                {
                    AssemblyCopyrightAttribute copyright = (AssemblyCopyrightAttribute) obj;
                    return copyright.Copyright;
                }
            }

            return string.Empty;
        }

        private string GetCompanyName()
        {
            Assembly assemblyInfo = Assembly.GetExecutingAssembly();
            object[] objects = assemblyInfo.GetCustomAttributes(false);

            foreach (object obj in objects)
            {
                if (obj.GetType() == typeof(System.Reflection.AssemblyCompanyAttribute))
                {
                    AssemblyCompanyAttribute company = (AssemblyCompanyAttribute) obj;
                    return company.Company;
                }
            }

            return string.Empty;
        }

        private string GetProductName()
        {
            Assembly assemblyInfo = Assembly.GetExecutingAssembly();
            object[] objects = assemblyInfo.GetCustomAttributes(false);

            foreach (object obj in objects)
            {
                if (obj.GetType() == typeof(System.Reflection.AssemblyProductAttribute))
                {
                    AssemblyProductAttribute product = (AssemblyProductAttribute)obj;
                    return product.Product;
                }
            }

            return string.Empty;
        }

        private string GetConfigurationInfo()
        {
            Assembly assemblyInfo = Assembly.GetExecutingAssembly();
            object[] objects = assemblyInfo.GetCustomAttributes(false);

            foreach (object obj in objects)
            {
                if (obj.GetType() == typeof(System.Reflection.AssemblyConfigurationAttribute))
                {
                    AssemblyConfigurationAttribute configuration = (AssemblyConfigurationAttribute)obj;
                    return configuration.Configuration;
                }
            }

            return string.Empty;
        }

        private void InfoPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //string company = Application.CompanyName.Trim();
            string company = GetCompanyName();
            string product = GetProductName();
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string configuration = GetConfigurationInfo();

            using (Font myFont = new Font("Arial", 12))
            {
                e.Graphics.DrawString(company, myFont, Brushes.SteelBlue, new Point(410, 50));
                e.Graphics.DrawString(product, myFont, Brushes.SteelBlue, new Point(410, 70));
                e.Graphics.DrawString(version, myFont, Brushes.SteelBlue, new Point(410, 90));
                e.Graphics.DrawString(configuration, myFont, Brushes.SteelBlue, new Point(410, 110));
            }
        }

        private void UpdateLabels()
        {
            CopyrightLabel.Text = GetCopyrightInfo();
            InfoLabel.Text = "This project is covered under the open source project and other open source software.";
            //InfoLabel.Text = "This project is covered under the open source project.";
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
