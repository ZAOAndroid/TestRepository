using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Action
{
    public class TestUser1 : IUser
    {
        public string UserName { get { return "User"; } }

        public string Password { get { return "123"; } }
    }
}
