using System;

namespace ImageLoadingStrategy
{
    public interface IImageLoadStrategy
    {
        void LoadImage(string href);
    }

 
    public class FileSystemImageLoad : IImageLoadStrategy
    {
        public void LoadImage(string href)
        {
            Console.WriteLine($"Loading image (href: {href}) from file system.");
        }
    }

    public class NetworkImageLoad : IImageLoadStrategy
    {
        public void LoadImage(string href)
        {
            Console.WriteLine($"Loading image (href: {href}) from network.");
        }
    }

    public class Image
    {
        private IImageLoadStrategy _imageLoadStrategy;

        public Image()
        {
        }

        public Image(IImageLoadStrategy imageLoadStrategy)
        {
            this._imageLoadStrategy = imageLoadStrategy;
        }

        public void SetImageLoadStrategy(IImageLoadStrategy imageLoadStrategy)
        {
            this._imageLoadStrategy = imageLoadStrategy;
        }

        public void LoadImage(string href)
        {
            if (_imageLoadStrategy != null)
            {
                this._imageLoadStrategy.LoadImage(href);
            }
            else
            {
                Console.WriteLine("Image loading strategy is not set.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Image image1 = new Image(new FileSystemImageLoad());
            Image image2 = new Image(new NetworkImageLoad());

            image1.LoadImage("image1.jpg");
            image2.LoadImage("http://example.com/image2.jpg");
        }
    }
}
