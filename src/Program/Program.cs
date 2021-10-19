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

            PipeSerial pipeSerial3 = new PipeSerial(new FilterNegative(), new PipeNull());
            PipeSerial pipeSerial2 = new PipeSerial(new SaveProgress(), pipeSerial3);
            PipeSerial pipeSerial1 = new PipeSerial(new FilterGreyscale(), pipeSerial2);

            IPicture result = pipeSerial1.Send(picture);

            provider = new PictureProvider();
            provider.SavePicture(result, @"Resultado.jpg");
        }
    }
}
