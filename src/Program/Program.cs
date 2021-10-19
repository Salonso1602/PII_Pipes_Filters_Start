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
            IPicture picture = provider.GetPicture(@"Luke.jpg");

            PipeSerial pipeSerial3 = new PipeSerial(new FilterGreyscale(), new PipeNull());
            PipeSerial pipeSerial2 = new PipeSerial(new Twitter(), pipeSerial3);
            PipeSerial pipeSerial1 = new PipeSerial(new SaveProgress(), pipeSerial2);
            PipeSerial pipeSerial0 = new PipeSerial(new FilterNegative(), pipeSerial1);

            IPicture result = pipeSerial0.Send(picture);

            provider = new PictureProvider();
            provider.SavePicture(result, @"PathToImage.jpg");
        }
    }
}
