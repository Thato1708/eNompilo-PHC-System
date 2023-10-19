using System.ComponentModel.DataAnnotations;

namespace eNompilo.v3._0._1.Models.Message
{
    public class ReplayViewModel
    {
        public int MessageId { get; set; }
        public string ReplayMessage { get; set; }
        public string? SenderUser { get; set; }
        public string? ReceiverUser { get; set; }


        public string? Content
        {
            get; set;
        }
        public List<Replay>? PreviousReplies { get; set; }
    }
}
