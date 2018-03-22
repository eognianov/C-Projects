namespace ErrorLogger.Models.Contracts
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}