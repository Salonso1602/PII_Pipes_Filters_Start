using System;
using TwitterUCU;

namespace CompAndDel
{
    public class Twitter : IFilter
    {
        public IPicture Filter (IPicture image)
        {
            TwitterImage twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("ALONSOPAIN (OC do not steal)", @"PipeIntermedio" + (SaveProgress.numProgreso) + ".jpg"));

            return image;
        }
    }
}