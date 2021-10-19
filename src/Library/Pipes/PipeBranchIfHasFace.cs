using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;


namespace CompAndDel.Pipes
{
    public class PipeBranchIfHasFace : IPipe
    {
        IPipe pipeIfTrue;
        IPipe pipeIfFalse;
        
        /// <summary>
        /// La cañería recibe una imagen, la clona y envìa la original por una cañeria y la clonada por otra.
        /// </summary>
        /// <param name="tipoFiltro">Tipo de filtro que se debe aplicar sobre la imagen. Se crea un nuevo filtro con los parametros por defecto</param>
        /// <param name="pipeIfTrue">Siguiente cañeria si tiene cara</param>
        /// <param name="pipeIfFalse">Siguiente cañeria si no tiene cara</param>
        public PipeBranchIfHasFace(IPipe pipeIfTrue, IPipe pipeIfFalse) 
        {
            this.pipeIfTrue = pipeIfTrue;
            this.pipeIfFalse = pipeIfFalse;           
        }
        
        /// <summary>
        /// La cañería recibe una imagen, construye un duplicado de la misma, 
        /// y envía la original por una cañería y el duplicado por otra.
        /// </summary>
        /// <param name="picture">imagen que se procesa y se decide a donde enviarla, no se le aplica ningun filtro</param>
        public IPicture Send(IPicture picture)
        {
            if (ContainsFace(picture))
            {
                return pipeIfTrue.Send(picture);
            }
            else
            {
                return pipeIfFalse.Send(picture);
            }
        }

        public bool ContainsFace(IPicture picture)
        {
            FaceSearcher faceSearch = new FaceSearcher();
            PipeSerial tempPipe = new PipeSerial(faceSearch, new PipeNull());
            tempPipe.Send(picture);

            return faceSearch.HasFace;
        }
    }
}
