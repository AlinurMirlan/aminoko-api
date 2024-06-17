using Antlr4.Runtime;
using System.Text;

namespace Aminoko.TemplateGen;

public class TemplateValidator : ITemplateValidator
{
    public bool IsValid(string template, out string validationErrors)
    {
        var inputStream = new AntlrInputStream(template);
        var templateLexer = new TemplateLexer(inputStream);
        var templateTokenStream = new CommonTokenStream(templateLexer);
        var templateParser = new TemplateParser(templateTokenStream);
        var lexerErrorListener = new LexerErrorListener();
        var parserErrorListener = new ParserErrorListener();
        templateLexer.AddErrorListener(lexerErrorListener);
        templateParser.AddErrorListener(parserErrorListener);
        templateParser.template();

        var errorMessageBuilder = new StringBuilder();
        if (lexerErrorListener.Errors.Count > 0)
        {
            foreach (var error in lexerErrorListener.Errors)
            {
                errorMessageBuilder.AppendLine(error);
            }
        }

        if (parserErrorListener.Errors.Count > 0)
        {
            foreach (var error in parserErrorListener.Errors)
            {
                errorMessageBuilder.AppendLine(error);
            }
        }

        validationErrors = errorMessageBuilder.ToString();
        return string.IsNullOrEmpty(validationErrors);
    }

    private sealed class LexerErrorListener : IAntlrErrorListener<int>
    {
        public LinkedList<string> Errors { get; } = [];

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Errors.AddLast($"line {line}:{charPositionInLine} {msg}");
        }
    }

    private sealed class ParserErrorListener : BaseErrorListener
    {
        public LinkedList<string> Errors { get; } = [];

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Errors.AddLast($"line {line}:{charPositionInLine} {msg}");
        }
    }
}

