using System.Collections.Generic;

namespace EmailSender
{
    static class MessageWithData
    {
        public static List<object> Getter_Addresses { get; set; }
        public static string Getter { get; set; }
        public static string Sender_ { get; set; }
        public static string SenderPassword { get; set; }
        public static string Theme { get; set; }
        public static string Message { get; set; }
        public static string AttachmentPath { get; set; }

        public static void Clear()
        {
            Getter = "";
            Sender_ = "";
            SenderPassword = "";
            Theme = "";
            Message = "";
            AttachmentPath = "";
        }

    }
}
