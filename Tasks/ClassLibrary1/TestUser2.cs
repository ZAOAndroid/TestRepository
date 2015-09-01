using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action
{
    public class TestUser2 : IUser
    {
        public string UserName { get { return "a.zykova"; } }

        public string Password { get { return "..."; } } // здесь пробовала со своим паролем
    }
}
