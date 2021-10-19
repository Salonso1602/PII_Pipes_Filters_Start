using CognitiveCoreUCU;
using CompAndDel.Pipes;

namespace CompAndDel
{
    public class FaceSearcher : IFilter
    {
        public bool HasFace;
        public IPicture Filter (IPicture image)
        {
            PipeSerial temppipe = new PipeSerial(new SaveProgress(), new PipeNull());
            IPicture tempImg = temppipe.Send(image);

            PictureProvider tempProv = new PictureProvider();
            tempProv.SavePicture(tempImg, @"Buscada.jpg");

            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(@"Buscada.jpg");

            this.HasFace = cog.FaceFound;

            return image;
        }
    }
}