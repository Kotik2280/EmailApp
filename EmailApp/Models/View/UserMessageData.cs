namespace EmailApp.Models.View
{
    public class UserMessageData
    {
        public User User { get; set; }
        public MessageData Message { get; set; }
        public List<MessageData> MessageDataList { get; set; }
    }
}
