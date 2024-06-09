using Antlr4.Runtime;

namespace Aminoko.TemplateGen;

public class TemplateValidator : ITemplateValidator
{
    public bool Validate(string template)
    {
        var inputStream = new AntlrInputStream(template);
        var templateLexer = new TemplateLexer(inputStream);
        var templateTokenStream = new CommonTokenStream(templateLexer);
        var templateParser = new TemplateParser(templateTokenStream);
        try
        {
            templateParser.template();
        }
        catch (RecognitionException)
        {
            return false;
        }

        return templateParser.NumberOfSyntaxErrors == 0;
    }
}
