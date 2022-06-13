using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicPackage
{
    public partial class RotateShapeForm : Form
    {
        public RotateShapeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           float angle = 0;   
           if (!float.TryParse(angleBox.Text, out angle))
           {
                MessageBox.Show("The angle input value is wrong");
           }
           else
           {
                GraphicPackage.angle = angle;
                Close();
                angleBox.Text = "";
           }
        }
    }
}
