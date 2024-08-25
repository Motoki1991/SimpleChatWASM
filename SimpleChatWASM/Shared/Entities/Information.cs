namespace SimpleChatWASM.Shared.Entities
{
    public class Information
    {
        public UserEntity User { get; set; }
        public string Context { get; set; }
        public bool IsChecked { get; set; }
        public DateTime DateTime { get; set; }
    }
}
