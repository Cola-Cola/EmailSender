namespace EmailSender
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Getter_txtbx = new System.Windows.Forms.TextBox();
            this.UploadList_Btn = new System.Windows.Forms.Button();
            this.ShowList_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Sender_txtbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Sender_pswd_txtbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Msg_theme_txtbx = new System.Windows.Forms.TextBox();
            this.IncludeAttachment_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Msg_txtbx = new System.Windows.Forms.TextBox();
            this.Send_Btn = new System.Windows.Forms.Button();
            this.UploadAddresses = new System.Windows.Forms.OpenFileDialog();
            this.ShowPswd_Btn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Show_errors_btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.UploadAttachment = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Адрес получателя";
            // 
            // Getter_txtbx
            // 
            this.Getter_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Getter_txtbx.Location = new System.Drawing.Point(178, 12);
            this.Getter_txtbx.Name = "Getter_txtbx";
            this.Getter_txtbx.Size = new System.Drawing.Size(285, 22);
            this.Getter_txtbx.TabIndex = 1;
            // 
            // UploadList_Btn
            // 
            this.UploadList_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UploadList_Btn.Location = new System.Drawing.Point(487, 10);
            this.UploadList_Btn.Name = "UploadList_Btn";
            this.UploadList_Btn.Size = new System.Drawing.Size(167, 23);
            this.UploadList_Btn.TabIndex = 2;
            this.UploadList_Btn.Text = "Загрузить из файла";
            this.UploadList_Btn.UseVisualStyleBackColor = true;
            this.UploadList_Btn.Click += new System.EventHandler(this.UploadList_Btn_Click);
            // 
            // ShowList_btn
            // 
            this.ShowList_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowList_btn.Location = new System.Drawing.Point(660, 10);
            this.ShowList_btn.Name = "ShowList_btn";
            this.ShowList_btn.Size = new System.Drawing.Size(182, 23);
            this.ShowList_btn.TabIndex = 3;
            this.ShowList_btn.Text = "Посмотреть список";
            this.ShowList_btn.UseVisualStyleBackColor = true;
            this.ShowList_btn.Click += new System.EventHandler(this.ShowList_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Адрес отправителя";
            // 
            // Sender_txtbx
            // 
            this.Sender_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Sender_txtbx.Location = new System.Drawing.Point(178, 54);
            this.Sender_txtbx.Name = "Sender_txtbx";
            this.Sender_txtbx.Size = new System.Drawing.Size(182, 22);
            this.Sender_txtbx.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(484, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Пароль";
            // 
            // Sender_pswd_txtbx
            // 
            this.Sender_pswd_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Sender_pswd_txtbx.Location = new System.Drawing.Point(557, 54);
            this.Sender_pswd_txtbx.Name = "Sender_pswd_txtbx";
            this.Sender_pswd_txtbx.PasswordChar = '*';
            this.Sender_pswd_txtbx.Size = new System.Drawing.Size(237, 22);
            this.Sender_pswd_txtbx.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Тема";
            // 
            // Msg_theme_txtbx
            // 
            this.Msg_theme_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Msg_theme_txtbx.Location = new System.Drawing.Point(65, 90);
            this.Msg_theme_txtbx.Name = "Msg_theme_txtbx";
            this.Msg_theme_txtbx.Size = new System.Drawing.Size(398, 22);
            this.Msg_theme_txtbx.TabIndex = 10;
            // 
            // IncludeAttachment_btn
            // 
            this.IncludeAttachment_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IncludeAttachment_btn.Location = new System.Drawing.Point(487, 88);
            this.IncludeAttachment_btn.Name = "IncludeAttachment_btn";
            this.IncludeAttachment_btn.Size = new System.Drawing.Size(167, 23);
            this.IncludeAttachment_btn.TabIndex = 11;
            this.IncludeAttachment_btn.Text = "Добавить вложение";
            this.IncludeAttachment_btn.UseVisualStyleBackColor = true;
            this.IncludeAttachment_btn.Click += new System.EventHandler(this.IncludeAttachment_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(409, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Текст сообщения (можно вкладывать HTML-страницы)";
            // 
            // Msg_txtbx
            // 
            this.Msg_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Msg_txtbx.Location = new System.Drawing.Point(16, 154);
            this.Msg_txtbx.Multiline = true;
            this.Msg_txtbx.Name = "Msg_txtbx";
            this.Msg_txtbx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Msg_txtbx.Size = new System.Drawing.Size(826, 433);
            this.Msg_txtbx.TabIndex = 13;
            // 
            // Send_Btn
            // 
            this.Send_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Send_Btn.Location = new System.Drawing.Point(428, 123);
            this.Send_Btn.Name = "Send_Btn";
            this.Send_Btn.Size = new System.Drawing.Size(104, 23);
            this.Send_Btn.TabIndex = 14;
            this.Send_Btn.Text = "Отправить";
            this.Send_Btn.UseVisualStyleBackColor = true;
            this.Send_Btn.Click += new System.EventHandler(this.Send_Btn_Click);
            // 
            // ShowPswd_Btn
            // 
            this.ShowPswd_Btn.BackgroundImage = global::EmailSender.Properties.Resources.eye_2387853_960_720;
            this.ShowPswd_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ShowPswd_Btn.Location = new System.Drawing.Point(802, 53);
            this.ShowPswd_Btn.Name = "ShowPswd_Btn";
            this.ShowPswd_Btn.Size = new System.Drawing.Size(40, 21);
            this.ShowPswd_Btn.TabIndex = 8;
            this.ShowPswd_Btn.UseVisualStyleBackColor = true;
            this.ShowPswd_Btn.Click += new System.EventHandler(this.ShowPswd_Btn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "@mail.ru",
            "@yandex.ru"});
            this.comboBox1.Location = new System.Drawing.Point(367, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 24);
            this.comboBox1.TabIndex = 15;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(538, 125);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(221, 20);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Сохранить данные адресанта";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(13, 603);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Отправлено: ";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 631);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(826, 23);
            this.progressBar1.TabIndex = 18;
            // 
            // Show_errors_btn
            // 
            this.Show_errors_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Show_errors_btn.Location = new System.Drawing.Point(701, 595);
            this.Show_errors_btn.Name = "Show_errors_btn";
            this.Show_errors_btn.Size = new System.Drawing.Size(139, 23);
            this.Show_errors_btn.TabIndex = 19;
            this.Show_errors_btn.Text = "Показать ошибки";
            this.Show_errors_btn.UseVisualStyleBackColor = true;
            this.Show_errors_btn.Click += new System.EventHandler(this.Show_errors_btn_Click);
            // 
            // UploadAttachment
            // 
            this.UploadAttachment.Multiselect = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(852, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(701, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 681);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Show_errors_btn);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Send_Btn);
            this.Controls.Add(this.Msg_txtbx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IncludeAttachment_btn);
            this.Controls.Add(this.Msg_theme_txtbx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ShowPswd_Btn);
            this.Controls.Add(this.Sender_pswd_txtbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Sender_txtbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ShowList_btn);
            this.Controls.Add(this.UploadList_Btn);
            this.Controls.Add(this.Getter_txtbx);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "E-mail Sender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Getter_txtbx;
        private System.Windows.Forms.Button UploadList_Btn;
        private System.Windows.Forms.Button ShowList_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Sender_txtbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Sender_pswd_txtbx;
        private System.Windows.Forms.Button ShowPswd_Btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Msg_theme_txtbx;
        private System.Windows.Forms.Button IncludeAttachment_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Msg_txtbx;
        private System.Windows.Forms.Button Send_Btn;
        private System.Windows.Forms.OpenFileDialog UploadAddresses;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Show_errors_btn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog UploadAttachment;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button1;
    }
}

