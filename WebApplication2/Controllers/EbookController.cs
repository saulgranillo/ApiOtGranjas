
//NO SE USA EN NADA
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ClbModOT;
using ClbNegOT;
using Microsoft.AspNetCore.Authorization;
using UtilidadesNorson.Conexiones;

//victor's usings
using System.IO;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EbookController : ControllerBase
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("CargarImg")]
        [AllowAnonymous]
        public object CargarImagenXId() //int idOT
        {
            int idOT = 248;
            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();
            string imagen = "";
            conSql.Command = conSql.Connection.CreateCommand();
            conSql.Command.CommandType = CommandType.Text;
            conSql.Command.CommandText = "SELECT imagen FROM [OrdenesTrabajo].[dbo].[RelImagen] WHERE IdOT = " + idOT + "";
            conSql.DataReader = conSql.Command.ExecuteReader();
            if (conSql.DataReader.HasRows)
            {
                while (conSql.DataReader.Read())
                {
                    
                    imagen = (string)(conSql.DataReader["imagen"] != DBNull.Value ? conSql.DataReader["imagen"] : string.Empty );
                    
                }
            }
            
          
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            
                
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\s_granillo\Documents\Documentacion\TestImg.pdf", FileMode.Create)); 
                // Le colocamos el título y el autor
                doc.AddCreator("AppOtGranjas");
                // Abrimos el archivo
                doc.Open();

                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                //Encabezado
                Paragraph titulo = new Paragraph("Folio:" + idOT, _standardFont);
                doc.Add(titulo);
                    

            //ClsNegCatOT objCatNeg = new ClsNegCatOT();
            //objCatNeg.cargarXImagen(imagen);

            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(imagen);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
               System.Drawing.Image image2 = System.Drawing.Image.FromStream (ms, true);
                
                //iTextSharp.text.Image laImagen = iTextSharp.text.Image(image2);
                //doc.Add(laImagen);
                //return image;
            }

            //muestra el base64 tal cual en el pdf
            //Paragraph img = new Paragraph(imagen);
            //doc.Add(img);



            //var pdf = mem.ToArray();            
            //doc.Add(pdf);



            doc.Close();
            return Ok(); // Convert.ToBase64String(pdf);
            }

           

            //VIDEO
            //Document doc = new Document(iTextSharp.text.PageSize.LETTER,10,10,42,35);
            //PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\s_granillo\Documents\Documentacion\Test.pdf", FileMode.Create));
            //doc.Open(); //Open to write
            //Paragraph parrafo = new Paragraph("This is my first line 😎");
            //doc.Add(parrafo);
            //iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(@"C:\Users\s_granillo\Pictures\norsonLogoBlanco.PNG");
            //png.ScalePercent(200f);
            //doc.Add(png);
            //doc.Close();         
            //END Video

            
            #region            

            //while (mySql.DataReader.Read())
            //{

            //if ((v_Edificio != mySql.DataReader["edificio"].ToString()) || (v_Area != mySql.DataReader["areaoperativa"].ToString()) || (v_Lote != mySql.DataReader["Lote"].ToString()))
            //    {
            //        inv_inicial = 0;
            //    }

            //    // Llenamos la tabla con información
            //    Edificio = new PdfPCell(new Phrase(mySql.DataReader["edificio"].ToString(), _standardFont));
            //    Edificio.BorderWidth = 0;

            //    Lote = new PdfPCell(new Phrase(mySql.DataReader["Lote"].ToString(), _standardFont));
            //    Lote.BorderWidth = 0;

            //    Fecha = new PdfPCell(new Phrase(mySql.DataReader["Fecha"].ToString().Substring(0, 10), _standardFont));
            //    Fecha.BorderWidth = 0;


            //    if (inv_inicial == 0)
            //    {

            //        v_Edificio = mySql.DataReader["edificio"].ToString();
            //        v_Area = mySql.DataReader["areaoperativa"].ToString();
            //        v_Lote = mySql.DataReader["Lote"].ToString();



            //        mySql2.Command.CommandText = " select saldoini from SaldoEdificio where semana =  '" + semana + "' and centro = '" + granja + "' and edificio = '" + mySql.DataReader["edificio"].ToString() + "' and Area = '" + mySql.DataReader["areaoperativa"].ToString() + "' and lote = '" + mySql.DataReader["Lote"].ToString() + "'";
            //        mySql2.DataReader = mySql2.Command.ExecuteReader();

            //        while (mySql2.DataReader.Read())
            //        {

            //            inv_inicial = Int32.Parse(mySql2.DataReader["saldoini"].ToString());

            //        }
            //        mySql2.DataReader.Close();


            //    }

            //    mySql2.Command.CommandText = " select movtipo, movdesc from [dbo].[TiposMov] where movcod = '" + mySql.DataReader["movcod"].ToString() + "'";
            //    mySql2.DataReader = mySql2.Command.ExecuteReader();

            //    while (mySql2.DataReader.Read())
            //    {

            //        Movtipo = mySql2.DataReader["movtipo"].ToString();
            //        Movdesc = mySql2.DataReader["movdesc"].ToString();


            //    }
            //    mySql2.DataReader.Close();

            //    if (Movtipo == "E")
            //    {
            //        inv_Final = inv_inicial + Int32.Parse(mySql.DataReader["cantidad"].ToString());
            //    }
            //    else
            //    {
            //        inv_Final = inv_inicial - Int32.Parse(mySql.DataReader["cantidad"].ToString());
            //    }






            //    InvInicial = new PdfPCell(new Phrase(inv_inicial.ToString(), _standardFont));
            //    InvInicial.BorderWidth = 0;

            //    Area = new PdfPCell(new Phrase(mySql.DataReader["areaoperativa"].ToString(), _standardFont));
            //    Area.BorderWidth = 0;

            //    //Clave = new PdfPCell(new Phrase(mySql.DataReader["movcod"].ToString(), _standardFont));

            //    Clave = new PdfPCell(new Phrase(mySql.DataReader["movcod"].ToString() + "-" + Movdesc.Substring(0, 7), _standardFont));

            //    Clave.BorderWidth = 0;

            //    Animales = new PdfPCell(new Phrase(mySql.DataReader["cantidad"].ToString(), _standardFont));
            //    Animales.BorderWidth = 0;

            //    Edad = new PdfPCell(new Phrase(mySql.DataReader["edad"].ToString(), _standardFont));
            //    Edad.BorderWidth = 0;

            //    PesoProm = new PdfPCell(new Phrase(mySql.DataReader["peso"].ToString(), _standardFont));
            //    PesoProm.BorderWidth = 0;

            //    InvFinal = new PdfPCell(new Phrase(inv_Final.ToString(), _standardFont));
            //    InvFinal.BorderWidth = 0;

            //    GrOrigen = new PdfPCell(new Phrase(mySql.DataReader["granjaorigen"].ToString(), _standardFont));
            //    GrOrigen.BorderWidth = 0;

            //    ArOrigen = new PdfPCell(new Phrase(mySql.DataReader["areaorigen"].ToString(), _standardFont));
            //    ArOrigen.BorderWidth = 0;

            //    LtOrigen = new PdfPCell(new Phrase(mySql.DataReader["loteorigen"].ToString(), _standardFont));
            //    LtOrigen.BorderWidth = 0;


            //    // Añadimos las celdas a la tabla
            //    tblPrueba.AddCell(Edificio);
            //    tblPrueba.AddCell(Lote);
            //    tblPrueba.AddCell(Fecha);
            //    tblPrueba.AddCell(InvInicial);
            //    tblPrueba.AddCell(Area);
            //    tblPrueba.AddCell(Clave);
            //    tblPrueba.AddCell(Animales);
            //    tblPrueba.AddCell(Edad);
            //    tblPrueba.AddCell(PesoProm);
            //    tblPrueba.AddCell(InvFinal);
            //    tblPrueba.AddCell(GrOrigen);
            //    tblPrueba.AddCell(ArOrigen);
            //    tblPrueba.AddCell(LtOrigen);
            //    inv_inicial = inv_Final;
            //}

            //doc.Add(Chunk.NEWLINE);






            //doc.Add(tblPrueba);

            //doc.Close();
            //writer.Close();
            #endregion


            //string reqBook = @"C:\pdf\zebra.pdf";
            //string bookName = idOT + ".pdf";

            ////converting Pdf file into bytes array  
            //var dataBytes = File.ReadAllBytes(reqBook);
            ////adding bytes to memory stream   
            //var dataStream = new MemoryStream(dataBytes);
            //return new eBookResult(dataStream, Request, bookName);
            //return Ok();
        }


}

   

