using Aminoko.TemplateGen.Converters;
using Aminoko.TemplateGen.Infrastructure;
using Aminoko.TemplateGen.Models;
using Antlr4.Runtime.Misc;
using SharpCompress.Common;
using System.Text;

namespace Aminoko.TemplateGen;

public class TemplateVisitor : TemplateParserBaseVisitor<string>
{
    private readonly Dictionary<string, string> statements = new(new CaseInsensitiveEqualityComparer());
    private readonly IInlineConverter inlineConverter;
    private readonly IBlockConverter blockConverter;
    private readonly IFlashcardBuilder flashcardBuilder;

    public TemplateVisitor(
        IInlineConverter inlineConverter,
        IBlockConverter blockConverter,
        IFlashcardBuilder flashcardBuilder)
    {
        this.inlineConverter = inlineConverter;
        this.blockConverter = blockConverter;
        this.flashcardBuilder = flashcardBuilder;
    }

    public override string VisitTemplate([NotNull] TemplateParser.TemplateContext context)
    {
        context.statements().Accept(this);
        context.front().Accept(this);
        flashcardBuilder.SwitchSide();
        context.back().Accept(this);
        return string.Empty;
    }

    public override string VisitFront([NotNull] TemplateParser.FrontContext context)
    {
        context.body().Accept(this);
        return string.Empty;
    }

    public override string VisitBack([NotNull] TemplateParser.BackContext context)
    {
        context.body().Accept(this);
        return string.Empty;
    }

    public override string VisitBody([NotNull] TemplateParser.BodyContext context)
    {
        foreach (var block in context.blockExpression())
        {
            block.Accept(this);
        }

        return string.Empty;
    }

    public override string VisitBlockStatementImage([NotNull] TemplateParser.BlockStatementImageContext context)
    {
        flashcardBuilder.AddBlock(BlockType.Image, blockConverter.BlockStatementImage());
        return string.Empty;
    }

    public override string VisitBlockStatementDefinition([NotNull] TemplateParser.BlockStatementDefinitionContext context)
    {
        flashcardBuilder.AddBlock(BlockType.Text, blockConverter.BlockStatementDefinition());
        return string.Empty;
    }

    public override string VisitBlockStatementMethodAudio([NotNull] TemplateParser.BlockStatementMethodAudioContext context)
    {
        var inputString = context.statementMethodParameters().Accept(this);
        flashcardBuilder.AddBlock(BlockType.Audio, blockConverter.BlockStatementMethodAudio(inputString));
        return string.Empty;
    }

    public override string VisitBlockStatementMethodImage([NotNull] TemplateParser.BlockStatementMethodImageContext context)
    {
        var inputString = context.statementMethodParameters().Accept(this);
        flashcardBuilder.AddBlock(BlockType.Image, blockConverter.BlockStatementMethodImage(inputString));
        return string.Empty;
    }

    public override string VisitBlockText([NotNull] TemplateParser.BlockTextContext context)
    {
        var inputString = context.inlineTextExpressions().Accept(this);
        flashcardBuilder.AddBlock(BlockType.Text, blockConverter.BlockText(inputString));
        return string.Empty;
    }

    public override string VisitInlineStatementDeclaration([NotNull] TemplateParser.InlineStatementDeclarationContext context)
    {
        var identifier = context.STATEMENT_METHOD_STATEMENT_DECLARATION().GetText()[..^1];
        if (statements.ContainsKey(identifier))
        {
            throw new InvalidFormatException($"The statement '{identifier}' is already defined.");
        }

        statements.Add(identifier, context.statementMethodParameters().Accept(this));
        return string.Empty;
    }

    public override string VisitStatements([NotNull] TemplateParser.StatementsContext context)
    {
        context.statementsBody().Accept(this);
        return string.Empty;
    }

    public override string VisitStatementsBody([NotNull] TemplateParser.StatementsBodyContext context)
    {
        foreach (var statement in context.inlineTextStatementDeclaration())
        {
            statement.Accept(this);
        }

        return string.Empty;
    }

    public override string VisitInlineStatementWord([NotNull] TemplateParser.InlineStatementWordContext context)
        => inlineConverter.InlineStatementWord();

    public override string VisitInlineStatementSentence([NotNull] TemplateParser.InlineStatementSentenceContext context)
        => inlineConverter.InlineStatementSentence();


    public override string VisitInlineStatementMethodQuery([NotNull] TemplateParser.InlineStatementMethodQueryContext context)
        => inlineConverter.InlineStatementMethodQuery(context.statementMethodParameters().Accept(this));

    public override string VisitInlineStatementMethodTranslate([NotNull] TemplateParser.InlineStatementMethodTranslateContext context)
        => inlineConverter.InlineStatementMethodTranslate(context.statementMethodParameters().Accept(this));

    public override string VisitInlineStatement([NotNull] TemplateParser.InlineStatementContext context)
    {
        var identifier = context.STATEMENT().GetText();
        if (!statements.TryGetValue(identifier, out string? statementValue))
        {
            throw new InvalidFormatException($"The statement '{identifier}' is not defined.");
        }

        return inlineConverter.InlineStatement(statementValue);
    }

    public override string VisitStatementMethodParameters([NotNull] TemplateParser.StatementMethodParametersContext context)
    {
        var result = new StringBuilder();
        foreach (var expression in context.statementMethodParameter())
        {
            result.Append(expression.Accept(this));
        }

        return result.ToString();
    }

    public override string VisitInlineText([NotNull] TemplateParser.InlineTextContext context)
        => inlineConverter.InlineText(context.GetText());

    public override string VisitInlineString([NotNull] TemplateParser.InlineStringContext context)
        => inlineConverter.InlineString(context.GetText());

    public override string VisitInlineTextExpressions([NotNull] TemplateParser.InlineTextExpressionsContext context)
    {
        var result = new StringBuilder();
        foreach (var expression in context.inlineTextExpression())
        {
            result.Append(expression.Accept(this));
        }

        return result.ToString();
    }
}
