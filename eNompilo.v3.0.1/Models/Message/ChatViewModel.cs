namespace eNompilo.v3._0._1.Models.Message
{
    public class ChatViewModel
    {
        public string SenderId { get; set; } // The ID of the sender
        public string ReceiverId { get; set; } // The ID of the receiver
        public string MessageContent { get; set; } // The content of the message
        public List<Message> Messages { get; set; } // List of chat messages
    }
}
