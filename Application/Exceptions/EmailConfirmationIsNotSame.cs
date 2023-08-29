using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class EmailConfirmationIsNotSame : Exception
{
    public override string Message => "Email confirmation is not the same as email";
}
