using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class PasswordWrongException : Exception
{
    public override string Message => "The password is not true";
}
