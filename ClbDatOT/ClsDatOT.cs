using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using ClbModOT;
using Dapper;
using UtilidadesNorson.Conexiones;

namespace ClbDatOT
{
    public class Class1
    {
        string Error = "ClsDatOT";
        //SqlNorson16 conn = new SqlNorson16();

        public List<ClsModEquipo> CargarEquipo(SqlConnection conn, ClsModEquipo objModel, out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModEquipo> LstModCatEquipo = new List<ClsModEquipo>();
            SqlDataReader sqlRead = null;

            try
            {
               
                //sqlRead = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "SpdCargarEquipo");
                //if (sqlRead.HasRows)
                //{
                //    while (sqlRead.Read())
                //    {
                //        objModel = new ClsModEquipo();

                //        objModel.IdEquipo = (int)(sqlRead["IdEquipo"] != DBNull.Value ? sqlRead["IdEquipo"] : 0);
                //        objModel.Descripcion = (string)(sqlRead["Descripcion"] != DBNull.Value ? sqlRead["Descripcion"] : string.Empty);
                //        objModel.Codigo = (string)(sqlRead["Codigo"] != DBNull.Value ? sqlRead["Codigo"] : string.Empty);
                //        objModel.Grupo = (string)(sqlRead["GpoEquipo"] != DBNull.Value ? sqlRead["GpoEquipo"] : string.Empty);
                //        LstModCatEquipo.Add(objModel);
                //    }

                //}
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = Error + "CargarEquipos()" + ex.Message;
                
            }
            finally
            {
                if (sqlRead != null) sqlRead.Close();
            }
            return LstModCatEquipo;
        }
    }
}
