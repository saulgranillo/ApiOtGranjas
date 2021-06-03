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

        public ClsModImagen CargarImagenXId (int IdOT)
        {
            ClsModImagen objReturn = new ClsModImagen();
          //ClsModResultado  objClsModResultado = new ClsModResultado();

            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();

            try
            {
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.Parameters.Add(new SqlParameter("@IdOT", SqlDbType.Int) { Value = IdOT});
                conSql.Command.CommandText = "[OrdenesTrabajo].[dbo].[SpdRptCargarImagenXId]";
                conSql.DataReader = conSql.Command.ExecuteReader();

                if (conSql.DataReader.HasRows)
                {
                    while (conSql.DataReader.Read())
                    {
                        //byte[] productImage;
                        //productImage = (byte[])conSql.DataReader["Imagen"];
                        objReturn.Imagen = (string)(conSql.DataReader["Imagen"] != DBNull.Value ? conSql.DataReader["Imagen"] : string.Empty);
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
    }
}
