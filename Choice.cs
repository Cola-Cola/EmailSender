using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
            label1.Text = @"Вы ввели адрес конкретного получателя, а также у вас заполнен список адресов получателей,
пожалуйста, выберете как отправить сообщение.";
        }

        private Sender sen;
        private string Theme { get; }
        private string Message { get; }
        public string Getter { get;  }
        public string Sender_ { get;  }
        public string Pass { get;  }
        public List<object> Getter_adresses { get;  }

        private Main m;
        public Thread t;

        public Choice(Sender _sender, string theme, string message)
        {
            sen = _sender;
            Theme = theme;
            Message = message;
            m = this.Owner as Main;
            InitializeComponent();
            label1.Text = @"Вы ввели адрес конкретного получателя, а также у вас заполнен список адресов получателей,
пожалуйста, выберете как отправить сообщение.";
        }

        public Choice(List<object> addresses, string getter, string sender, string sender_pass, string theme,
            string message)
        {
            Getter_adresses = addresses;
            Getter = getter;
            Sender_ = sender;
            Pass = sender_pass;
            Theme = theme;
            Message = message;
            m = this.Owner as Main;
            InitializeComponent();
            label1.Text = @"Вы ввели адрес конкретного получателя, а также у вас заполнен список адресов получателей,
пожалуйста, выберете как отправить сообщение.";
        }

        public Choice(Main main)
        {
            m = main; InitializeComponent();
            label1.Text = @"Вы ввели адрес конкретного получателя, а также у вас заполнен список адресов получателей,
пожалуйста, выберете как отправить сообщение.";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //sen.Send(Theme, Message, 0);
            m.Variant = 0;
            m.Send();
            this.Dispose();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            //t = new Thread(() =>
            //{
            //    sen.Send(Theme, Message, 1);
            //    m.label6.Text = $"Отправлено {Stats.good} / {m.Getter_adresses.Count}";
            //    m.progressBar1.Maximum = m.Getter_adresses.Count;
            //    m.progressBar1.Value = Stats.good + Stats.bad;
            //});
            //t.IsBackground = true;
            //t.Start();
            //this.Hide();
            m.Variant = 1;
            m.Send();
            this.Dispose();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //t = new Thread(() =>
            //{
            //    sen.Send(Theme, Message, 2);
            //    m.label6.Text = $"Отправлено {Stats.good} / {m.Getter_adresses.Count + 1}";
            //    m.progressBar1.Maximum = m.Getter_adresses.Count + 1;
            //    m.progressBar1.Value = Stats.good + Stats.bad;
            //});
            //t.IsBackground = true;
            //t.Start();
            m.Variant = 2;
            this.Dispose();
            m.Send();
            
        }
    }
}
