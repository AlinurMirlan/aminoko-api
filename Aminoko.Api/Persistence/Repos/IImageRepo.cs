namespace Aminoko.Api.Persistence.Repos;

public interface IImageRepo
{
    public string GetImageUrl(string imageId);

    public string SaveImage(IFormFile imageFile);
}
