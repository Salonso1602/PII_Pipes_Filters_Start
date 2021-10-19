using System;
using TwitterUCU;

namespace CompAndDel
{
    public class Twitter : IFilter
    {
        public IPicture Filter (IPicture image)
        {
            PictureProvider tempProv = new PictureProvider();
            tempProv.SavePicture(image, @"PipeIntermedioATwitter.jpg");

            TwitterImage twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("aaaa", @"PipeIntermedioATwitter.jpg"));

            return image;
        }
    }
}