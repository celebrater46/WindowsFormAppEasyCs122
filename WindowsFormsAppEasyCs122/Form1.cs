using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsAppEasyCs122
{
    public partial class Form1 : Form
    {
        private ListBox lbx;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Get All Data";
            this.Width = 300;
            this.Height = 200;

            lbx = new ListBox();
            lbx.Dock = DockStyle.Fill;

            var cars = new[]
            {
                new { num = 2, name = "Benz" },
                new { num = 3, name = "Ferrari" },
                new { num = 4, name = "Fuso" },
            };
            
            XDocument doc = XDocument.Load("C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs122\\WindowsFormsAppEasyCs122\\Sample.xml");

            // IEnumerable qry = from K in doc.Descendants("car") select K;
            // IEnumerable qry = from K in doc.Descendants("car") where (string)K.Attribute("country") == "Japan" select K;
            // IEnumerable qry = from K in doc.Descendants("car") where (int)K.Attribute("id") >= 1005 select K.Element("name").Value;
            IEnumerable qry = from K in doc.Descendants("car") orderby(int)K.Attribute("id") select K.Element("name").Value;

            foreach (var tmp in qry)
            {
                lbx.Items.Add(tmp);
            }

            lbx.Parent = this;
        }
    }
}