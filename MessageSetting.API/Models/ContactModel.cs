namespace MessageSetting.API.Models
{
    public class ContactModel
    {

        public long Id { get; set; }
        public string? PhoneNo { get; set; }
        public string? Name { get; set; }
        //public string? PrimaryUserName { get; set; }
        //public long? PrimaryUserId { get; set; }

        public IList<ContactUserModel>? ContactUsers { get; set; }

        public ContactModel()
        {
            ContactUsers = new List<ContactUserModel>();
        }
    }
}
