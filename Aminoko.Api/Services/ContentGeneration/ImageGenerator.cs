using Amazon.S3;
using Amazon.S3.Model;
using Aminoko.Api.Infrastructure.Exceptions;
using OpenAI_API;
using OpenAI_API.Images;
using OpenAI_API.Models;

namespace Aminoko.Api.Services.ContentGeneration;

public class ImageGenerator : IImageGenerator
{
    private readonly IOpenAIAPI _openApi;
    private readonly IAmazonS3 _amazonS3Client;
    private readonly string _bucketName;

    public ImageGenerator(IAmazonS3 amazonS3Client, IConfiguration config, IOpenAIAPI openApi)
    {
        _amazonS3Client = amazonS3Client ?? throw new ArgumentNullException(nameof(amazonS3Client));
        _openApi = openApi ?? throw new ArgumentNullException(nameof(openApi));
        _bucketName = config["AWS:S3:AssetBucket"] ?? throw new ConfigurationException("Bucket name hasn't been specified");
    }

    public async Task<string> GenerateImageAsync(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            throw new ArgumentNullException(nameof(query));
        }

        var imageGenResult = await _openApi.ImageGenerations.CreateImageAsync(
            new ImageGenerationRequest(query, Model.DALLE2, ImageSize._512, 
                responseFormat: ImageResponseFormat.B64_json));

        var imageKey = $"{Guid.NewGuid()}.jpeg";
        var putObjectRequest = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = imageKey,
            InputStream = new MemoryStream(Convert.FromBase64String(imageGenResult.Data[0].Base64Data)),
            ContentType = "image/jpeg"
        };

        await _amazonS3Client.PutObjectAsync(putObjectRequest);
        return imageKey;
    }
}
