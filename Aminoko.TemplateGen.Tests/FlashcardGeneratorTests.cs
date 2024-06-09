using Aminoko.TemplateGen.Converters;
using Aminoko.TemplateGen.Models;
using Moq;

namespace Aminoko.TemplateGen.Tests;

public class FlashcardGeneratorTests
{
    private readonly FlashcardGenerator flashcardGenerator;
    private static readonly string inlineStatementWord = "sample word";
    private static readonly string inlineStatementSentence = "sample sentence";
    private static readonly string blockImage = "https://image/sampleImage.png";
    private static readonly string blockDefinition = """
        - definition one
        - definition two
        - definition three
        """;
    private static string ApiAudioFunc(string input) => $"https://audio/{input}.mp3";
    private static string ApiImageFunc(string input) => $"https://image/{input}.mp3";
    private static string ApiTranslateFunc(string input) => $"translate({input})";
    private static string ApiQueryFunc(string input) => $"query({input})";

    public FlashcardGeneratorTests()
    {
        var inlineConverter = new Mock<InlineConverterBase>();
        inlineConverter.Setup(x => x.InlineStatement(It.IsAny<string>())).Returns<string>(x => x);
        inlineConverter.Setup(x => x.InlineText(It.IsAny<string>())).Returns<string>(x => x);
        inlineConverter.Setup(x => x.InlineString(It.IsAny<string>())).Returns<string>(x => x);
        inlineConverter.Setup(x => x.InlineStatementWord()).Returns(inlineStatementWord);
        inlineConverter.Setup(x => x.InlineStatementSentence()).Returns(inlineStatementSentence);
        inlineConverter.Setup(x => x.InlineStatementMethodTranslate(It.IsAny<string>())).Returns<string>(ApiTranslateFunc);
        inlineConverter.Setup(x => x.InlineStatementMethodQuery(It.IsAny<string>())).Returns<string>(ApiQueryFunc);

        var blockConverter = new Mock<BlockConverterBase>();
        blockConverter.Setup(x => x.BlockStatementDefinition()).Returns(blockDefinition);
        blockConverter.Setup(x => x.BlockStatementImage()).Returns(blockImage);
        blockConverter.Setup(x => x.BlockStatementMethodAudio(It.IsAny<string>())).Returns<string>(ApiAudioFunc);
        blockConverter.Setup(x => x.BlockText(It.IsAny<string>())).Returns<string>(x => x);
        blockConverter.Setup(x => x.BlockStatementMethodImage(It.IsAny<string>())).Returns<string>(ApiImageFunc);

        flashcardGenerator = new FlashcardGenerator(inlineConverter.Object, blockConverter.Object, new FlashcardBuilder());
    }

    [Fact]
    public void ConvertToTemplate_WithValidAminokoInput_ReturnsTemplate()
    {
        // Arrange
        var template = """
            #statements

            &generatedSentences(&query(5 sample sentences for the word &word))
            &sentences(&sentence. &generatedSentences)

            #front

            &definition

            #back

            &word - &translate(&word)
            &image
            &sentences
            &image(&word)
            &audio(&sentences)
            """;

        var sentences = $"{inlineStatementSentence}. {ApiQueryFunc($"5 sample sentences for the word {inlineStatementWord}")}";
        var expectedFlashcard = new Flashcard(
            [
                new(BlockType.Text, $"""


                """),
                new(BlockType.Text, $"""
                {blockDefinition}
                """),
                new(BlockType.Text, $"""



                """)
            ],
            [
                new(BlockType.Text, $"""

                {inlineStatementWord} - {ApiTranslateFunc(inlineStatementWord)}

                """),
                new(BlockType.Image, blockImage),
                new(BlockType.Text, $"""

                {sentences}

                """),
                new(BlockType.Image, ApiImageFunc(inlineStatementWord)),
                new(BlockType.Text, $"""


                """),
                new(BlockType.Audio, ApiAudioFunc(sentences)),
            ]);

        // Act
        var actualFlashcard = flashcardGenerator.GenerateFlashcard(template);

        // Assert 
        Assert.Equivalent(expectedFlashcard.Front, actualFlashcard.Front);
        Assert.Equivalent(expectedFlashcard.Back, actualFlashcard.Back);
    }
}