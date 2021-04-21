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
    }
}
