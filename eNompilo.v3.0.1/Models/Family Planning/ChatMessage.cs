namespace eNompilo.v3._0._1.Models.Family_Planning
{
    public class ChatMessage
    {
        public int Id { get; set; } // Unique message identifier
        public string SenderUserId { get; set; } // User ID of the sender
        public string ResponsiblePractitionerId { get; set; } // User ID of the receiver
        public string Text { get; set; } // Message content
        public DateTime Timestamp { get; set; } // Timestamp when the message was sent
        public string Sender { get; set; }

    }
}
