using Aminoko.Api.Persistence.Repos;
using Aminoko.Api.Services.ContentGeneration;
using Aminoko.TemplateGen.Converters;

namespace Aminoko.Api.Services.ContentConversion;

public class BlockConverter : BlockConverterBase
{
    private readonly IAudioGenerator _audioGenerator;
    private readonly IDefinitionGenerator _definitionGenerator;
    private readonly IImageGenerator _imageGenerator;

    public BlockConverter(
        IAudioGenerator audioGenerator,
        IDefinitionGenerator definitionGenerator,
        IImageGenerator imageGenerator)
    {
        _audioGenerator = audioGenerator ?? throw new ArgumentNullException(nameof(audioGenerator));
        _definitionGenerator = definitionGenerator ?? throw new ArgumentNullException(nameof(definitionGenerator));
        _imageGenerator = imageGenerator ?? throw new ArgumentNullException(nameof(imageGenerator));
    }

    public override string BlockStatementDefinition()
        => _definitionGenerator.GenerateDefinitionAsync(StatementWord).Result;

    public override string BlockStatementMethodAudio(string inputString)
        => _audioGenerator.GenerateAudioAsync(inputString).Result;

    public override string BlockStatementMethodImage(string inputString)
        => _imageGenerator.GenerateImageAsync(inputString).Result;
}
