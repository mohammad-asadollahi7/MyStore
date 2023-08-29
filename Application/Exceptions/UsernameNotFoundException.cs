using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class UsernameNotFoundException : Exception
{
    public override string Message => "The username was not found.";
}
