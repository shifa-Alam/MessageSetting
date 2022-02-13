namespace MessageSetting.API.Models
{
    public class ContactInputModel
    {

        public long Id { get; set; }
        public string? PhoneNo { get; set; }
        public string? Name { get; set; }

        public  IList<ContactUserInputModel>? ContactUsers { get; set; }

        public ContactInputModel()
        {
            ContactUsers = new List<ContactUserInputModel>();
        }
    }
}
