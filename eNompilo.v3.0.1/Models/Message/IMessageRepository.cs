using System;
using System.Collections.Generic;

namespace eNompilo.v3._0._1.Models.Message
{
    

    public interface IMessageRepository
    {
        List<Message> GetMessagesForUsers(string senderId, string receiverId);
        void Add(Message message);
    }

    public class InMemoryMessageRepository : IMessageRepository
    {
        private List<Message> _messages = new List<Message>();

        public List<Message> GetMessagesForUsers(string senderId, string receiverId)
        {
            // Implement your logic to retrieve messages for the given sender and receiver
            return _messages.FindAll(message =>
                (message.SenderId == senderId && message.ReceiverId == receiverId) ||
                (message.SenderId == receiverId && message.ReceiverId == senderId));
        }

        public void Add(Message message)
        {
            // Simulate adding a message to an in-memory list
            _messages.Add(message);
        }
    }

}
