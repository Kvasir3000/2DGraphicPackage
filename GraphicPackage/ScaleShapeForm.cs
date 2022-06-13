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
    public partial class ScaleShapeForm : Form
    {
        public ScaleShapeForm()
        {
            InitializeComponent();
    
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
         
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            int scaler = 0;
            if (!int.TryParse(scalarTextBox.Text, out scaler))
            {
                MessageBox.Show("The scaler input value is wrong");
            }
            else if (!xBox.Checked && !yBox.Checked)
            {
                MessageBox.Show("Select one or two of the axes");
            }
            else
            {
                GraphicPackage.xScaleBool = xBox.Checked;
                GraphicPackage.yScaleBool = yBox.Checked;
                GraphicPackage.scalerValue = scaler;
                Close();
                ResetWindow();
            }
        }

        private void ResetWindow()
        {
            scalarTextBox.Text = "";
            xBox.Checked = false;
            yBox.Checked = false;
        }
    }

}
