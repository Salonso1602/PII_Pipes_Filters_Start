namespace CompAndDel
{
    public class SaveProgress : IFilter
    {
        public static int numProgreso = 0;
        public static int NumProgreso 
        {
            get
            {
                return numProgreso+=1;
            }
        }
        //la responsabilidad de guardar una imagen en disco ya la tiene provider, por lo que creo una clase que implemente
        //ifilter para poder pasar este proceso como parametro "filtro". Implemento el tipo a pictureProvider
        public IPicture Filter(IPicture image)
        {
            PictureProvider tempProv = new PictureProvider();
            tempProv.SavePicture(image, @"PipeIntermedio" + (SaveProgress.NumProgreso) + ".jpg");

            return image;
        }
    }
}