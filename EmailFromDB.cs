using System.Data.Linq.Mapping;

namespace EmailSender
{
    [Table(Name = "Emails")]
    class EmailFromDB
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name="Email")]
        public string Address { get; set; }
    }
}
