using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class Errors : Form
    {
        public Errors()
        {
            InitializeComponent();
            foreach (var item in Stats.Errors)
                textBox1.Text += item + "\r\n";
        }
    }
}
