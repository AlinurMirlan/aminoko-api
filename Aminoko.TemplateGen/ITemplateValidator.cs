namespace Aminoko.TemplateGen;

public interface ITemplateValidator
{
    public bool IsValid(string template, out string validationErrors);
}
