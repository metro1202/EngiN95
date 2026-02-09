using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace EngiN95.Core.Rendering;

public class Image
{
    public byte[] PixelData { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Image(string path, bool flip = false)
    {
        var image = SixLabors.ImageSharp.Image.Load<Rgba32>(path);

        //flip img
        if (flip)
        {
            image.Mutate(x => x.Flip(FlipMode.Vertical));
        }

        var pixels = new List<byte>(4 * image.Width * image.Height);

        for (var y = 0; y < image.Height; y++)
        {
            for (var x = 0; x < image.Width; x++)
            {
                pixels.Add(image[x, y].R);
                pixels.Add(image[x, y].G);
                pixels.Add(image[x, y].B);
                pixels.Add(image[x, y].A);
            }
        }

        PixelData = pixels.ToArray();
        Width = image.Width;
        Height = image.Height;
    }
}