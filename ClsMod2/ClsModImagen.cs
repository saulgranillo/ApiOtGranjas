using System.Collections.Generic;



namespace ClbModOT
{
   public class ClsModImagen
    {
        public int IdImagen { get; set; }
        public string Imagen { get; set; } //byte[]
        public int IdOT { get; set; }

        public List<ClsModImagen> LstModImagenes { get; set; }
        public ClsModResultado clsModResultado = new ClsModResultado();
           
    }
}
