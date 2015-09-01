using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action
{
    public interface IUser
    {
        string UserName { get; }

        string Password { get; }
    }
}
