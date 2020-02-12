using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace EmailSender
{
    public class Sender
    {
        public Sender() { }

        private string GetterAddress { get; }
        private string SenderAddress { get; }
        private string Password { get; }

        private List<object> Addresses;
        public Sender(string getter, string _sender, string password)
        {
            GetterAddress = getter;
            SenderAddress = _sender;
            Password = password;
        }

        public Sender(List<object> addresses, string _sender, string password)
        {
            Addresses = addresses;
            SenderAddress = _sender;
            Password = password;
        }

        public Sender(List<object> addresses, string address, string _sender, string password)
        {
            Addresses = addresses;
            GetterAddress = address;
            SenderAddress = _sender;
            Password = password;
        }

        public virtual void Send(string theme, string message, string attachmentPath, int variant)
        {
            if (SenderAddress.Contains("yandex.ru") || SenderAddress.Contains("ya.ru"))
            {
                if (variant == 0) //отправить одно сообщение на адрес из поля
                {
                    MailMessage mailmes = new MailMessage(SenderAddress, GetterAddress);
                    mailmes.IsBodyHtml = true;
                    mailmes.Subject = theme;
                    mailmes.Body = message;
                    ForYandex(mailmes);
                }

                if (variant == 1) // отправить сообщение на адреса из списка
                {
                    foreach (var item in Addresses)
                    {
                        MailMessage mailmes = new MailMessage(SenderAddress, item.ToString());

                        mailmes.IsBodyHtml = true;
                        mailmes.Subject = theme;
                        mailmes.Body = message;
                        ForYandex(mailmes);
                    }
                }

                if (variant == 2) //отправить на адрес из поля и на адреса из списка
                {
                    MailMessage mailmes = new MailMessage(SenderAddress, GetterAddress);
                    mailmes.IsBodyHtml = true;
                    mailmes.Subject = theme;
                    mailmes.Body = message;
                    ForYandex(mailmes);

                    foreach (var item in Addresses)
                    {
                        mailmes = new MailMessage(SenderAddress, item.ToString());

                        mailmes.IsBodyHtml = true;
                        mailmes.Subject = theme;
                        mailmes.Body = message;
                        ForYandex(mailmes);
                    }
                }
            }

            if (SenderAddress.Contains("mail.ru"))
            {
                if (variant == 0) //отправить одно сообщение на адрес из поля
                {
                    try
                    {
                        MailMessage mailmes = new MailMessage(SenderAddress, GetterAddress);
                        mailmes.IsBodyHtml = true;
                        mailmes.Subject = theme;
                        mailmes.Body = message;
                        if (attachmentPath != "")
                            mailmes.Attachments.Add(new Attachment(attachmentPath));
                        ForMailRu(mailmes);
                    }
                    catch(Exception ex)
                    {
                        Stats.bad++;
                        Stats.Errors.Add(ex.Message);
                    }
                }

                if (variant == 1) // отправить сообщение на адреса из списка
                {
                    try
                    {
                        foreach (var item in Addresses)
                        {
                            MailMessage mailmes = new MailMessage(SenderAddress, item.ToString());
                            mailmes.IsBodyHtml = true;
                            mailmes.Subject = theme;
                            mailmes.Body = message;
                            if (attachmentPath != "")
                                mailmes.Attachments.Add(new Attachment(attachmentPath));
                            ForMailRu(mailmes);
                        }
                    }
                    catch(Exception ex)
                    {
                        Stats.bad++;
                        Stats.Errors.Add(ex.Message);
                    }
                }

                if (variant == 2) //отправить на адрес из поля и на адреса из списка
                {
                    try
                    {
                        MailMessage mailmes = new MailMessage(SenderAddress, GetterAddress);
                        mailmes.IsBodyHtml = true;
                        mailmes.Subject = theme;
                        mailmes.Body = message;
                        if (attachmentPath != "")
                            mailmes.Attachments.Add(new Attachment(attachmentPath));
                        ForMailRu(mailmes);

                        foreach (var item in Addresses)
                        {

                            mailmes = new MailMessage(SenderAddress, item.ToString());
                            mailmes.IsBodyHtml = true;
                            mailmes.Subject = theme;
                            mailmes.Body = message;
                            if (attachmentPath != "")
                                mailmes.Attachments.Add(new Attachment(attachmentPath));
                            ForMailRu(mailmes);
                        }
                    }
                    catch (Exception ex)
                    {
                        Stats.bad++;
                        Stats.Errors.Add(ex.Message);
                    }
                }
            }
        }

        private void ForYandex(MailMessage mm)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru",465);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(SenderAddress, Password);
                smtpClient.Send(mm);
                Stats.good++;
            }
            catch (Exception ex)
            {
                Stats.bad++;
                Stats.Errors.Add(ex.Message);
            }
        }

        private void ForMailRu(MailMessage mm)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.mail.ru");
                smtpClient.Port = 587;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new System.Net.NetworkCredential(SenderAddress, Password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mm);
                Stats.good++;

            }
            catch (Exception ex)
            {
                Stats.bad++;
                Stats.Errors.Add(ex.Message);
            }
        }
    }
}
