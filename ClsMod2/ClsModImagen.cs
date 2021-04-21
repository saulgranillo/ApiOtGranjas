using System.Collections.Generic;



namespace ClbModOT
{
   public class ClsModImagen
    {
        public int IdImagen { get; set; }
        public byte[] Imagen { get; set; }
        public int IdOT { get; set; }

        public List<ClsModImagen> LstModImagenes { get; set; }
           
    }
}
