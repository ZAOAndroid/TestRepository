

namespace Data
{
    public class MailContact:Contact
    {
        public string Alias { get; set; }
        public override string ToString()
        {
            return contact + "_" + Alias;
        }
    }
}
