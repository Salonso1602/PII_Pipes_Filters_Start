using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            IPipe pipeNegative = new PipeSerial(new FilterNegative(), new PipeNull());

            IPipe pipeTwitter = new PipeSerial(new Twitter(), new PipeNull());

            IPipe pipeCond = new PipeBranchIfHasFace(pipeTwitter, pipeNegative);
            IPipe pipeSerialGrey = new PipeSerial(new FilterGreyscale(), pipeCond);

            IPicture result = pipeSerialGrey.Send(picture);

            provider = new PictureProvider();
            provider.SavePicture(result, @"PathToImage.jpg");
        }
    }
}
