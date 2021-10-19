namespace CompAndDel
{
    public class SaveProgress : IFilter
    {
        private static int numProgreso = 0;
        private static int NumProgreso 
        {
            get
            {
                return numProgreso+=1;
            }
        }
        //la responsabilidad de guardar una imagen en disco ya la tiene provider, por lo que creo una clase que implemente
        //ifilter para poder pasar este proceso como parametro "filtro"
        public IPicture Filter(IPicture image)
        {
            PictureProvider tempProv = new PictureProvider();
            tempProv.SavePicture(image, @"PipeIntermedio" + (SaveProgress.NumProgreso) + ".jpg");

            return image;
        }
    }
}