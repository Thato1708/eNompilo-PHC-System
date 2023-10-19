using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eNompilo.v3._0._1.Models.Message
{
    public class Replay
    {
        [Key]
        public int Id { get; set; }
        public string Sender { get; set; }
        public int MessageId { get; set; }
        
        [ForeignKey("MessageId")]
        public Message? Messages { get; set; }

        public string ReplayMessage { get; set; }
    }
}
