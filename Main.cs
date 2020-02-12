using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Linq;
using System.Data.Linq;
using System.Data.OleDb;
using Microsoft.Office.Interop.Word;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;
using Version = System.Version;

namespace EmailSender
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            UploadAddresses.Filter = "Text File(*.txt)|*.txt|Microsoft Word 97(*.doc)| *.doc|Microsoft Word 2010(*.docx)|*.docx|" +
                                     "Microsoft Excel 97(*.xls)|*.xls|Microsoft Excel 2010(*.xlsx)|*.xlsx|All files(*.*)|*.*";
            try
            {
                RegistryKey currentUserKey = Registry.CurrentUser;
                RegistryKey emailSender = currentUserKey.OpenSubKey("EMailSender");
                Sender_txtbx.Text = emailSender.GetValue("Login").ToString();
                Sender_pswd_txtbx.Text = emailSender.GetValue("Pass").ToString();
                comboBox1.SelectedIndex = int.Parse(emailSender.GetValue("Provider").ToString());
            }
            catch
            {

            }
        }

        public List<object> Getter_adresses = new List<object>();
        private string AttachmentPath = "";
        public int Variant { get; set; }
        private void UploadList_Btn_Click(object sender, EventArgs e)
        {
            string Adress;
            if (UploadAddresses.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                try
                {
                    Adress = UploadAddresses.FileName;
                    ReadFile(Adress);
                    MessageBox.Show($"Найдено адресов: {Getter_adresses.Count}");
                }
                catch(NullReferenceException nex)
                {
                    MessageBox.Show("Процесс считывания был прерван!", "Внимание", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }

            }

        }

        void ReadFile(string adresses_path)
        {
            Getter_adresses.Clear();
            if (adresses_path.Contains(".txt"))
            {
                StreamReader sr = new StreamReader(adresses_path, System.Text.Encoding.Default);
                string allText = sr.ReadToEnd();
                string[] MBAddresses = allText.Split(new char[] {' ', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string li in MBAddresses)
                    Getter_adresses.Add(li);
                sr.Close();
            }

            if (adresses_path.Contains(".doc") || adresses_path.Contains(".docx"))
            {
                try
                {
                    Microsoft.Office.Interop.Word.Application word_app = null;
                    word_app = new Microsoft.Office.Interop.Word.Application();
                    word_app.Visible = false;
                    Document word_doc = word_app.Documents.Open(adresses_path);
                    Thread t = new Thread(new ThreadStart(() =>
                    {
                        for (int i = 0; i < word_doc.Paragraphs.Count; i++)
                        {
                            string[] temp = word_doc.Paragraphs[i + 1].Range.Text.Split(new char[] { ' ', '\n', '\r' },
                                StringSplitOptions.RemoveEmptyEntries);
                            foreach (var item in temp)
                                if (item.Contains("@"))
                                    Getter_adresses.Add(item);
                        }
                        word_doc.Close();
                        word_app.Quit();
                    }));
                    t.IsBackground = false;
                    t.Start();
                    t.Join();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (adresses_path.Contains(".xls") || adresses_path.Contains(".xlsx"))
            {
                try
                {
                    Stats.count = 0;
                    Microsoft.Office.Interop.Excel._Application excel_app = null;
                    excel_app = new Microsoft.Office.Interop.Excel.Application();
                    excel_app.Visible = false;
                    _Workbook excel_workbook = excel_app.Workbooks.Open(adresses_path);
                    _Worksheet excel_worksheet = excel_workbook.Sheets[1];
                    excel_worksheet = excel_workbook.ActiveSheet;
                    Microsoft.Office.Interop.Excel.Range excel_range = excel_worksheet.UsedRange;
                    
                    ScanExcl se = new ScanExcl(excel_app,excel_workbook,excel_worksheet,excel_range);
                    se.ShowDialog();
                    Getter_adresses = MessageWithData.Getter_Addresses;
                    excel_app.Quit();
                    
                    try
                    {
                        foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                        {
                                proc.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    GC.Collect();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (adresses_path.Contains(".accdb") || adresses_path.Contains(".mdb"))
            {
                string connection = $"Provider = Microsoft.Jet.OLEDB.4.0; Data Source ={adresses_path};";
                //string connection = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={adresses_path};";
                OleDbConnection myConnection = new OleDbConnection(connection);
                myConnection.Open();
                OleDbCommand coommand = new OleDbCommand("SELECT Emails_Col FROM Emails", myConnection);
                OleDbDataReader reader = coommand.ExecuteReader();
                Getter_adresses.Clear();
                while (reader.Read())
                {
                    int AddressIndex = reader.GetOrdinal("Emails_Col");
                    Getter_adresses.Add(reader.GetString(AddressIndex));
                }
                myConnection.Close();
            }
        }

        private void ShowList_btn_Click(object sender, EventArgs e)
        {
            AdressListForm alf = new AdressListForm(Getter_adresses);
            alf.ShowDialog();

        }

        private void ShowPswd_Btn_Click(object sender, EventArgs e) => Sender_pswd_txtbx.PasswordChar =
            (Sender_pswd_txtbx.PasswordChar == '*') ? '\0' : '*';

        private void IncludeAttachment_btn_Click(object sender, EventArgs e)
        {
            if (UploadAttachment.ShowDialog() == DialogResult.Cancel)
                return; 
            AttachmentPath = UploadAttachment.FileName;
        }

        private void Send_Btn_Click(object sender, EventArgs e)
        {
            MessageWithData.Clear();
            Stats.good = Stats.bad = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            Stats.Errors.Clear();
            Choice ch = new Choice();
            if (ch.t!=null && ch.t.IsAlive)
            {
                MessageBox.Show("Выполняется отправка сообщений, пожалуйста подождите!", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                if (Sender_txtbx.Text + comboBox1.SelectedItem.ToString() != "" && Sender_pswd_txtbx.Text != "")
                {
                    RegistryKey currentUserKey = Registry.CurrentUser;

                    try
                    {
                        RegistryKey emailSenderCheck = currentUserKey.OpenSubKey("EmailSender");

                        if (Sender_txtbx.Text != emailSenderCheck.GetValue("Login").ToString() ||
                            Sender_pswd_txtbx.Text != emailSenderCheck.GetValue("Pass").ToString() ||
                            comboBox1.SelectedIndex != int.Parse(emailSenderCheck.GetValue("Provider").ToString()))
                        {
                            if (MessageBox.Show(@"Обнаружены новые входные данные, перезаписать их?
Старые входные данные не сохранятся!",
                                    "Перезапись входных данных",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                RegistryKey emailSender = currentUserKey.CreateSubKey("EMailSender");
                                emailSender.SetValue("Login", Sender_txtbx.Text);
                                emailSender.SetValue("Pass", Sender_pswd_txtbx.Text);
                                emailSender.SetValue("Provider", comboBox1.SelectedIndex);
                            }
                        }

                    }
                    catch
                    {
                        if (!checkBox1.Checked)
                        {
                            if (MessageBox.Show("Желаете ли вы сохранить логин и пароль? (Небезопасно!!!)",
                                    "Сохранение входных данных",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                RegistryKey emailSender = currentUserKey.CreateSubKey("EMailSender");
                                emailSender.SetValue("Login", Sender_txtbx.Text);
                                emailSender.SetValue("Pass", Sender_pswd_txtbx.Text);
                                emailSender.SetValue("Provider", comboBox1.SelectedIndex);
                            }
                        }
                        else
                        {
                            RegistryKey emailSender = currentUserKey.CreateSubKey("EMailSender");
                            emailSender.SetValue("Login", Sender_txtbx.Text);
                            emailSender.SetValue("Pass", Sender_pswd_txtbx.Text);
                            emailSender.SetValue("Provider", comboBox1.SelectedIndex);
                            emailSender.Close();
                        }
                    }
                }

                if (Getter_adresses.Count != 0 && Getter_txtbx.Text != "")
                {
                    Sender sen = new Sender(Getter_adresses, Getter_txtbx.Text, Sender_txtbx.Text + comboBox1.SelectedItem.ToString(), Sender_pswd_txtbx.Text);
                    ch = new Choice(this);
                    MessageWithData.Getter_Addresses = Getter_adresses;
                    MessageWithData.Getter = Getter_txtbx.Text;
                    MessageWithData.Sender_ = Sender_txtbx.Text +comboBox1.SelectedItem.ToString();
                    MessageWithData.SenderPassword = Sender_pswd_txtbx.Text;
                    MessageWithData.Theme = Msg_theme_txtbx.Text;
                    MessageWithData.Message = Msg_txtbx.Text;
                    MessageWithData.AttachmentPath = AttachmentPath;
                    ch.Owner = this;
                    ch.ShowDialog();
                }

                if (Getter_adresses.Count == 0 && Getter_txtbx.Text != "")
                {
                    Variant = 0;
                    Send_Btn.Enabled = false;
                    Send();
                    Send_Btn.Enabled = true;
                }

                if (Getter_adresses.Count != 0 && Getter_txtbx.Text == "")
                {
                    Variant = 1;
                    Send_Btn.Enabled = false;
                    Send();
                    Send_Btn.Enabled = true;
                }
            }
        }

        public void Send()
        {
            timer1.Start();
            Stats.Errors?.Clear();
            if (Variant == 0)
            {
                Sender sen = new Sender(Getter_txtbx.Text, Sender_txtbx.Text + comboBox1.SelectedItem.ToString(), Sender_pswd_txtbx.Text);
                sen.Send(Msg_theme_txtbx.Text, Msg_txtbx.Text, AttachmentPath, 0);
                label6.Text = $"Отправлено успешно {Stats.good}; неуспешно {Stats.bad} из 1";
                progressBar1.Maximum = 1;
                progressBar1.Value = 1;
                AttachmentPath = "";
            }

            if (Variant == 1)
            {
                Sender sen = new Sender(Getter_adresses, Sender_txtbx.Text + comboBox1.SelectedItem.ToString(), Sender_pswd_txtbx.Text);
                

                Thread t = new Thread(new ThreadStart(() =>
                {
                    sen.Send(Msg_theme_txtbx.Text, Msg_txtbx.Text, AttachmentPath, 1);
                    

                }));

                Thread tt = new Thread(new ThreadStart(() =>
                {
                    while (timer1.Enabled)
                    {
                        Invoke(new System.Action(() =>
                        {
                            label6.Text = $"Отправлено успешно {Stats.good}; неуспешно {Stats.bad} из {Getter_adresses.Count}";
                            progressBar1.Maximum = Getter_adresses.Count;
                            progressBar1.Value = Stats.good + Stats.bad;
                            GC.Collect();
                            if (progressBar1.Value == progressBar1.Maximum)
                            {
                                t.Abort();
                                timer1.Stop();
                                AttachmentPath = "";
                            }
                        }));
                    }
                }));

                t.IsBackground = true;
                tt.IsBackground = true;
                t.Start();
                tt.Start();

            }

            if (Variant == 2)
            {
                Sender sen = new Sender(MessageWithData.Getter_Addresses, MessageWithData.Getter,
                    MessageWithData.Sender_, MessageWithData.SenderPassword);
                Thread t = new Thread(() =>
                {
                    sen.Send(MessageWithData.Theme, MessageWithData.Message,MessageWithData.AttachmentPath, 2);
                    
                });

                Thread tt = new Thread(new ThreadStart(() =>
                {
                    while (timer1.Enabled)
                    {
                        Invoke(new System.Action(() =>
                        {
                            label6.Text = $"Отправлено успешно {Stats.good}; неуспешно {Stats.bad} из {Getter_adresses.Count + 1}";
                            progressBar1.Maximum = Getter_adresses.Count + 1;
                            progressBar1.Value = Stats.good + Stats.bad;
                            if (progressBar1.Value == progressBar1.Maximum)
                            {
                                t.Abort();
                                timer1.Stop();
                                AttachmentPath = "";
                            }
                            GC.Collect();
                        }));
                    }

                    Invoke(new System.Action(() => timer1.Stop()));
                }));

                t.IsBackground = true;
                tt.IsBackground = true;
                t.Start();
                tt.Start();
            }

        }

       

        private void Show_errors_btn_Click(object sender, EventArgs e)
        {
            Errors er =new Errors();
            er.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Version localVersion = new Version(Application.ProductVersion);
            MessageBox.Show(localVersion.ToString());
        }
    }
}
