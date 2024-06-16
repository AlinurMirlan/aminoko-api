using Amazon.S3;
using Amazon.S3.Model;
using Aminoko.Api.Infrastructure.Exceptions;
using OpenAI_API;
using OpenAI_API.Audio;
using OpenAI_API.Models;
using static OpenAI_API.Audio.TextToSpeechRequest;

namespace Aminoko.Api.Services.ContentGeneration;

public class AudioGenerator : IAudioGenerator
{
    private readonly IOpenAIAPI _openApi;
    private readonly IAmazonS3 _amazonS3Client;
    private readonly string _bucketName;

    public AudioGenerator(IAmazonS3 amazonS3Client, IConfiguration config, IOpenAIAPI openApi)
    {
        _amazonS3Client = amazonS3Client ?? throw new ArgumentNullException(nameof(amazonS3Client));
        _openApi = openApi ?? throw new ArgumentNullException(nameof(openApi));
        _bucketName = config["AWS:S3:AssetBucket"] ?? throw new ConfigurationException("Bucket name hasn't been specified");
    }

    public async Task<string> GenerateAudioAsync(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentNullException(nameof(text));
        }

        var audioStream = await _openApi.TextToSpeech.GetSpeechAsStreamAsync(new TextToSpeechRequest
        {
            Model = Model.TTS_HD,
            Input = text,
            Voice = Voices.Nova,
            ResponseFormat = ResponseFormats.MP3,
        });

        var audioKey = $"{Guid.NewGuid()}.mp3";
        var putObjectRequest = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = audioKey,
            InputStream = audioStream,
            ContentType = "audio/mpeg"
        };

        await _amazonS3Client.PutObjectAsync(putObjectRequest);
        return audioKey;
    }
}
