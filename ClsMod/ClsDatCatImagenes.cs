using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using ClbModOT;
using Microsoft.ApplicationBlocks.Data;
using Dapper;
using System.Linq;

using UtilidadesNorson.Conexiones;

namespace ClsDatOT
{
   public class ClsDatCatImagenes
    {

        public List<ClsModImagen> Guardar(int IdOT, string objModel, out ClsModResultado objModResultado)
        {
            objModResultado = new ClsModResultado();
            List<ClsModImagen> LstImagenes = new List<ClsModImagen>();
            SqlDataReader sqlRead = null;


            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();

            //base64Encode(objModel);

            try
            {
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.Parameters.Add(new SqlParameter("@IdOT", SqlDbType.VarChar) { Value = IdOT});
                conSql.Command.Parameters.Add(new SqlParameter("@Imagen", SqlDbType.VarChar) { Value = objModel });
                conSql.Command.CommandText = "[OrdenesTrabajo].[dbo].[SpdAgregarImagen]";
                conSql.DataReader = conSql.Command.ExecuteReader();
            }
            catch (Exception ex)
            {

                objModResultado.MsgError =  "Guardar OT" + ex.Message;
            }
            finally
            {
                if (sqlRead != null) sqlRead.Close();
            }

            return LstImagenes;
        }

        public ClsModImagen CargarImagenXId (string IdOT)
        {
            ClsModImagen objReturn = new ClsModImagen();
          //ClsModResultado  objClsModResultado = new ClsModResultado();

            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();

            try
            {
                
                //int x = Convert.ToInt32(IdOT);
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.Parameters.Add(new SqlParameter("@Folio", SqlDbType.VarChar) { Value = IdOT});
                conSql.Command.CommandText = "[OrdenesTrabajo].[dbo].[SpdRptCargarImagenXId]";
                conSql.DataReader = conSql.Command.ExecuteReader();

                if (conSql.DataReader.HasRows)
                {
                    while (conSql.DataReader.Read())
                    {
                        //byte[] productImage;
                        //productImage = (byte[])conSql.DataReader["Imagen"];
                        objReturn.Imagen = (string)(conSql.DataReader["Imagen"] != DBNull.Value ? conSql.DataReader["Imagen"] : string.Empty);
                        //Base64Decode(objReturn.Imagen);
                    }
                   
                }
            }
            catch (Exception ex)
            {
              objReturn.clsModResultado.MsgError =  "Error al Cargar Imagen X Id()" + ex.Message;
                
            }
            finally
            {
                if (conSql != null) conSql.CloseConn();
            }
             return objReturn;
        }

        public static string base64Encode (string objModel)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(objModel);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
