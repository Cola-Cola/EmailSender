using System.Collections.Generic;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class AdressListForm : Form
    {

        public AdressListForm(List<object> adresslist)
        {
            InitializeComponent();
            foreach (var item in adresslist)
            {
                listBox1.Items.Add(item.ToString());
            }
        }
    }
}
