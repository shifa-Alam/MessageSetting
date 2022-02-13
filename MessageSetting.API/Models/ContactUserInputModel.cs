namespace MessageSetting.API.Models
{
    public class ContactUserInputModel
    {

        public long Id { get; set; }
        public long ContactId { get; set; }
        public long UserId { get; set; }
        public long UserType { get; set; }

        public string UserName { get; set; }
        //public ContactInputModel Contact { get; set; }
        //public UserInputModel User { get; set; }
    }
}
