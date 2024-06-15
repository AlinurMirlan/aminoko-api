using Aminoko.Api.Persistence.Repos;
using Aminoko.Api.Services.ContentGeneration;
using Aminoko.TemplateGen.Converters;

namespace Aminoko.Api.Services.ContentConversion;

public class BlockConverter : BlockConverterBase
{
    private readonly IAudioGenerator _audioGenerator;
    private readonly IDefinitionGenerator _definitionGenerator;
    private readonly IImageGenerator _imageGenerator;
    private readonly IImageRepo _imageRepo;

    public BlockConverter(
        IAudioGenerator audioGenerator,
        IDefinitionGenerator definitionGenerator,
        IImageGenerator imageGenerator,
        IImageRepo imageRepo)
    {
        _audioGenerator = audioGenerator;
        _definitionGenerator = definitionGenerator;
        _imageGenerator = imageGenerator;
        _imageRepo = imageRepo;
    }

    public override string BlockStatementDefinition()
        => _definitionGenerator.GenerateDefinition(StatementWord);

    public override string BlockStatementImage()
        => _imageRepo.GetImageUrl(StatementImage);

    public override string BlockStatementMethodAudio(string inputString)
        => _audioGenerator.GenerateAudio(inputString);

    public override string BlockStatementMethodImage(string inputString)
        => _imageGenerator.GenerateImage(inputString);
}
