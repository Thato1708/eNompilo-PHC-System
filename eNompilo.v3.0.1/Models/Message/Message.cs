using eNompilo.v3._0._1.Models.SystemUsers;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Message
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string? SenderUser { get; set; }
        public string? ReceiverUser { get; set; }
    }

}
