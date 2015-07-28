

namespace Data
{
    public class NumbContact:Contact
    {
        public string Code { get; set; }
        public override string ToString()
        {
            return Code + contact;
        }
    }
}
