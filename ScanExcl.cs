using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;
using  Microsoft.Office.Interop.Excel;

namespace EmailSender
{
    public partial class ScanExcl : Form
    {
        public ScanExcl()
        {
            InitializeComponent();
        }

        private Thread t;
        public ScanExcl(Microsoft.Office.Interop.Excel._Application excl, _Workbook wb, _Worksheet ws, Microsoft.Office.Interop.Excel.Range excel_range)
        {
            List<object> getters = new List<object>();
            int count = 0, totalCells = excel_range.Rows.Count * excel_range.Columns.Count;
            InitializeComponent();
            t = new Thread(new ThreadStart(() =>
            {
                for (int i = 1; i <= wb.Worksheets.Count; i++)
                {
                    for (int j = 1; j <= excel_range.Rows.Count; j++)
                    {
                        for (int k = 1; k <= excel_range.Columns.Count; k++)
                        {
                            count++;
                            
                            if (excel_range.Cells[j, k] != null && excel_range.Cells[j, k].Value2 != null)
                            {

                                string tempStr = excel_range.Cells[j, k].Value2.ToString();
                                string[] tempArray = tempStr.Split(new char[] { ' ', '\n' },
                                    StringSplitOptions.RemoveEmptyEntries);

                                foreach (var item in tempArray)
                                {
                                    if (item.Contains("@"))
                                        getters.Add(item);
                                }
                            }

                            
                                Invoke(new System.Action(() =>
                                {
                                    label1.Text = $"Просканировано ячеек {count} / {totalCells}";
                                    progressBar1.Maximum = totalCells;
                                    progressBar1.Value = count;
                                }));

                        }
                    }
                }

                wb.Close();
                excl.Quit();
                MessageWithData.Getter_Addresses = getters;
            }));
            t.IsBackground = true;
            t.Start();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           t.Abort();
           this.Dispose();
        }
    }
}
