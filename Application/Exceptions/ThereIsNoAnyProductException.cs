
namespace Application.Exceptions;

public class ThereIsNoAnyProductException : Exception
{
    public override string Message => "There is no any product in database";
}
