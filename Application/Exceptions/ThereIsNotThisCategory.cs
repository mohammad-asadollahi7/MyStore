
namespace Application.Exceptions;

public class ThereIsNotThisCategory : Exception
{
    public override string Message => "There is not this category in database.";
}
