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
//namespace ClsMod
{
    public class CLsDatOT
    {
        string Error = "ClsDatOT";

        public List<ClsModEquipo> CargarEquipo(ClsModEquipo objModel, out ClsModResultado objClsModResultado) //SqlConnection conn, 
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModEquipo> LstModCatEquipo = new List<ClsModEquipo>();
            SqlDataReader sqlRead = null;

            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();
            try
            {
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.CommandText = "[OrdenesTrabajo].[dbo].[SpdCargarEquipo]";
                conSql.DataReader = conSql.Command.ExecuteReader();
                
                string id = string.Empty;
                string descripcion = string.Empty;
                string codigo = string.Empty;
                string gpo = string.Empty;

                if (conSql.DataReader.HasRows)
                {
                    while (conSql.DataReader.Read())
                    {
                        //porque no me deja castear directo el objmodel.id ... 
                        objModel = new ClsModEquipo();

                        id = conSql.DataReader["IdEquipo"].ToString() ;
                        descripcion = (string)(conSql.DataReader["Descripcion"] != DBNull.Value ? conSql.DataReader["Descripcion"] : string.Empty);
                        codigo = (string)(conSql.DataReader["Codigo"] != DBNull.Value ? conSql.DataReader["Codigo"] : string.Empty);
                        gpo = (string)(conSql.DataReader["GpoEquipo"] != DBNull.Value ? conSql.DataReader["GpoEquipo"] : string.Empty);

                        int result = Int32.Parse(id);
                        objModel.IdEquipo = result;
                        objModel.Descripcion = descripcion;
                        objModel.Codigo = codigo;
                        objModel.Grupo = gpo;

                        LstModCatEquipo.Add(objModel);
                        
                    }
                }

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


        public List<ClsModPrioridad> CargarPrioridad(ClsModPrioridad objModel, out ClsModResultado objClsModResultado) //SqlConnection conn, 
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModPrioridad> LstModCatPrioridad = new List<ClsModPrioridad>();
            SqlDataReader sqlRead = null;

            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();
            try
            {
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.CommandText = "[OrdenesTrabajo].[dbo].[SpdCargarPrioridad]";
                conSql.DataReader = conSql.Command.ExecuteReader();

                string id = string.Empty;
                string nombre = string.Empty;
                string prioridad = string.Empty;
                
                if (conSql.DataReader.HasRows)
                {
                    while (conSql.DataReader.Read())
                    {
                        //porque no me deja castear directo el objmodel.id ... 
                        objModel = new ClsModPrioridad();

                        id = conSql.DataReader["IdPrioridad"].ToString();
                        nombre = (string)(conSql.DataReader["Nombre"] != DBNull.Value ? conSql.DataReader["Nombre"] : string.Empty);
                        prioridad = conSql.DataReader["Prioridad"].ToString(); 


                        int Id = Int32.Parse(id);
                        objModel.IdPrioridad= Id;

                        objModel.Nombre = nombre;

                        int Prio = Int32.Parse(prioridad);
                        objModel.Prioridad = Prio;

                        LstModCatPrioridad.Add(objModel);

                    }
                }

            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = Error + "CargarPrioridad()" + ex.Message;

            }
            finally
            {
                if (sqlRead != null) sqlRead.Close();
            }
            return LstModCatPrioridad;
        }

        public List<ClsModTipo> CargarTipo(ClsModTipo objModel, out ClsModResultado objClsModResultado) //SqlConnection conn, 
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModTipo> LstModCatTipo = new List<ClsModTipo>();
            SqlDataReader sqlRead = null;

            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();
            try
            {
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.CommandText = "[OrdenesTrabajo].[dbo].[SpdCargarTipoOT]";
                conSql.DataReader = conSql.Command.ExecuteReader();

                string id = string.Empty;
                string tipo = string.Empty;
                string codigo = string.Empty;

                if (conSql.DataReader.HasRows)
                {
                    while (conSql.DataReader.Read())
                    {
                        //porque no me deja castear directo el objmodel.id ... 
                        objModel = new ClsModTipo();

                        id = conSql.DataReader["IdTipo"].ToString();
                        tipo = (string)(conSql.DataReader["Tipo"] != DBNull.Value ? conSql.DataReader["Tipo"] : string.Empty);
                        codigo = (string)(conSql.DataReader["Codigo"] != DBNull.Value ? conSql.DataReader["Codigo"] : string.Empty);


                        int Id = Int32.Parse(id);
                        objModel.IdTipo = Id;

                        objModel.Tipo = tipo;
                        objModel.Codigo = codigo;

                        LstModCatTipo.Add(objModel);

                    }
                }

            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = Error + "CargarTipo()" + ex.Message;

            }
            finally
            {
                if (sqlRead != null) sqlRead.Close();
            }
            return LstModCatTipo;
        }


        public List<ClsModArea> CargarArea(ClsModArea objModel, out ClsModResultado objClsModResultado) //SqlConnection conn, 
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModArea> LstModCatArea = new List<ClsModArea>();
            SqlDataReader sqlRead = null;

            SqlNorson02 conSql = new SqlNorson02();
            conSql.CreateConn();
            try
            {
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.CommandText = "[AppMovGranjas].[dbo].[SpdCargarAreas]";
                conSql.DataReader = conSql.Command.ExecuteReader();

                string area = string.Empty;
                string areaDesc = string.Empty;
                

                if (conSql.DataReader.HasRows)
                {
                    while (conSql.DataReader.Read())
                    {
                        //porque no me deja castear directo el objmodel.id ... 
                        objModel = new ClsModArea();

                        
                        area = (string)(conSql.DataReader["Area"] != DBNull.Value ? conSql.DataReader["Area"] : string.Empty);
                        areaDesc = (string)(conSql.DataReader["AreaDesc"] != DBNull.Value ? conSql.DataReader["AreaDesc"] : string.Empty);

                        objModel.Area= area;
                        objModel.AreaDesc = areaDesc;

                        LstModCatArea.Add(objModel);

                    }
                }

            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = Error + "CargarArea()" + ex.Message;

            }
            finally
            {
                if (sqlRead != null) sqlRead.Close();
            }
            return LstModCatArea;
        }

        public List<ClsModGranja> CargarGranjas(ClsModGranja objModel, out ClsModResultado objClsModResultado) //SqlConnection conn, 
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModGranja> LstModCatGranja = new List<ClsModGranja>();
            SqlDataReader sqlRead = null;

            SqlNorson02 conSql = new SqlNorson02();
            conSql.CreateConn();
            try
            {
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.CommandText = "[AppMovGranjas].[dbo].[SpdCargarGranjas]";
                conSql.DataReader = conSql.Command.ExecuteReader();

                string centro = string.Empty;
                string nombre = string.Empty;


                if (conSql.DataReader.HasRows)
                {
                    while (conSql.DataReader.Read())
                    {
                        //porque no me deja castear directo el objmodel.id ... 
                        objModel = new ClsModGranja();


                        centro = (string)(conSql.DataReader["Centro"] != DBNull.Value ? conSql.DataReader["Centro"] : string.Empty);
                        nombre = (string)(conSql.DataReader["Nombre"] != DBNull.Value ? conSql.DataReader["Nombre"] : string.Empty);

                        objModel.Centro = centro;
                        objModel.Nombre = nombre;

                        LstModCatGranja.Add(objModel);

                    }
                }

            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = Error + "CargarArea()" + ex.Message;

            }
            finally
            {
                if (sqlRead != null) sqlRead.Close();
            }
            return LstModCatGranja;
        }


        public List<ClsModEstatus> CargarEstatus(ClsModEstatus objModel, out ClsModResultado objClsModResultado) //SqlConnection conn, 
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModEstatus> LstModCatEstatus = new List<ClsModEstatus>();
            SqlDataReader sqlRead = null;

            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();
            try
            {
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.CommandText = "[OrdenesTrabajo].[dbo].[SpdCargarEstatus]";
                conSql.DataReader = conSql.Command.ExecuteReader();

                string estatus = string.Empty;
                string estado = string.Empty;
                string id = string.Empty;

                if (conSql.DataReader.HasRows)
                {
                    while (conSql.DataReader.Read())
                    {
                        //porque no me deja castear directo el objmodel.id ... 
                        objModel = new ClsModEstatus();

                        id = conSql.DataReader["IdEstatus"].ToString();
                        estatus = (string)(conSql.DataReader["Estatus"] != DBNull.Value ? conSql.DataReader["Estatus"] : string.Empty);
                        estado = (string)(conSql.DataReader["Estado"] != DBNull.Value ? conSql.DataReader["Estado"] : string.Empty);


                        int result = Int32.Parse(id);
                        objModel.IdEstatus= result;

                        objModel.Estatus = estatus;
                        objModel.Estado = estado;

                        LstModCatEstatus.Add(objModel);

                    }
                }

            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = Error + "CargarEstatus()" + ex.Message;

            }
            finally
            {
                if (sqlRead != null) sqlRead.Close();
            }
            return LstModCatEstatus;
        }


        public List<ClsModEvento> CargarTipoEvento(ClsModEvento objModel, out ClsModResultado objClsModResultado) //SqlConnection conn, 
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModEvento> LstModCatEvento = new List<ClsModEvento>();
            SqlDataReader sqlRead = null;

            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();
            try
            {
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.CommandText = "[OrdenesTrabajo].[dbo].[SpdCargarEvento]";
                conSql.DataReader = conSql.Command.ExecuteReader();

                string evento = string.Empty;
                string estatusEvento = string.Empty;
                string id = string.Empty;


                if (conSql.DataReader.HasRows)
                {
                    while (conSql.DataReader.Read())
                    {
                        //porque no me deja castear directo el objmodel.id ... 
                        objModel = new ClsModEvento();

                        id = conSql.DataReader["IdEvento"].ToString();
                        evento = (string)(conSql.DataReader["Evento"] != DBNull.Value ? conSql.DataReader["Evento"] : string.Empty);
                        estatusEvento = (string)(conSql.DataReader["EstatusEvento"] != DBNull.Value ? conSql.DataReader["EstatusEvento"] : string.Empty);

                        int result = Int32.Parse(id);
                        objModel.idEvento= result;

                        objModel.Evento = evento;
                        objModel.EstatusEvento = estatusEvento;

                        LstModCatEvento.Add(objModel);

                    }
                }

            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = Error + "CargarEstatusEvento()" + ex.Message;

            }
            finally
            {
                if (sqlRead != null) sqlRead.Close();
            }
            return LstModCatEvento;
        }


        //GUARDAR       GUARDAR     GUARDAR     GUARDAR


        public ClsModResultado GuardarOT(ClsModCatOT objModel)
        {
            ClsModResultado objReturn = new ClsModResultado();

            DateTime fecha = DateTime.Now;
            string folioTmp = "";
            folioTmp = fecha.ToString("yyyyMMddHmmssf");
            Console.WriteLine("folio formateado " + folioTmp + "rrrr" + fecha);


            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();
                       
            try
            {
                
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.Parameters.Add(new SqlParameter("@Prioridad", SqlDbType.VarChar) { Value = objModel.Prioridad });
                conSql.Command.Parameters.Add(new SqlParameter("@CodPrioridad", SqlDbType.VarChar) { Value = objModel.CodPrioridad });
                conSql.Command.Parameters.Add(new SqlParameter("@TipoOT", SqlDbType.VarChar) { Value = objModel.TipoOT });
                conSql.Command.Parameters.Add(new SqlParameter("@CodTipoOT", SqlDbType.VarChar) { Value = objModel.CodTipoOT });
                conSql.Command.Parameters.Add(new SqlParameter("@Centro", SqlDbType.VarChar) { Value = objModel.Centro });
                conSql.Command.Parameters.Add(new SqlParameter("@Granja", SqlDbType.VarChar) { Value = objModel.Granja });
                conSql.Command.Parameters.Add(new SqlParameter("@Area", SqlDbType.VarChar) { Value = objModel.Area });
                conSql.Command.Parameters.Add(new SqlParameter("@CodArea", SqlDbType.VarChar) { Value = objModel.CodArea });
                conSql.Command.Parameters.Add(new SqlParameter("@Sala", SqlDbType.VarChar) { Value = objModel.Sala });
                conSql.Command.Parameters.Add(new SqlParameter("@Equipo", SqlDbType.VarChar) { Value = objModel.Equipo });
                conSql.Command.Parameters.Add(new SqlParameter("@CodEquipo", SqlDbType.VarChar) { Value = objModel.CodEquipo });
                conSql.Command.Parameters.Add(new SqlParameter("@Grupo", SqlDbType.VarChar) { Value = objModel.Grupo });
                conSql.Command.Parameters.Add(new SqlParameter("@Actividad", SqlDbType.VarChar) { Value = objModel.Actividad });
                conSql.Command.Parameters.Add(new SqlParameter("@Materiales", SqlDbType.VarChar) { Value = objModel.Materiales });
                conSql.Command.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.VarChar) { Value = objModel.Estatus });
                conSql.Command.Parameters.Add(new SqlParameter("@CodEstatus", SqlDbType.VarChar) { Value = objModel.CodEstatus });
                conSql.Command.Parameters.Add(new SqlParameter("@Tecnico1", SqlDbType.VarChar) { Value = objModel.Tecnico1 });
                conSql.Command.Parameters.Add(new SqlParameter("@Tecnico2", SqlDbType.VarChar) { Value = objModel.Tecnico2 });
                conSql.Command.Parameters.Add(new SqlParameter("@Tecnico3", SqlDbType.VarChar) { Value = objModel.Tecnico3 });
                conSql.Command.Parameters.Add(new SqlParameter("@Tecnico4", SqlDbType.VarChar) { Value = objModel.Tecnico4 });
                conSql.Command.Parameters.Add(new SqlParameter("@Tecnico5", SqlDbType.VarChar) { Value = objModel.Tecnico5 });
                conSql.Command.Parameters.Add(new SqlParameter("@TipoEventoDesc", SqlDbType.VarChar) { Value = objModel.TipoEvento });
                conSql.Command.Parameters.Add(new SqlParameter("@TipoEvento", SqlDbType.VarChar) { Value = objModel.CodEvento });
                conSql.Command.Parameters.Add(new SqlParameter("@Folio", SqlDbType.VarChar) { Value = folioTmp });
                conSql.Command.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime) { Value = fecha });

                conSql.Command.CommandText = "[OrdenesTrabajo].[dbo].[SpdAgregarOT]";
        
                object Id = conSql.Command.ExecuteScalar();
                if(Id != null)
                {
                    int ident = 0;
                    if(int.TryParse(Id.ToString(),out ident))
                    {
                        objReturn.Id = ident;
                    }
                }

            }
            catch (Exception ex)
            {

                objReturn.MsgError = Error + "Guardar OT" + ex.Message;
            }

            
            return objReturn;
        }

        ////REPORTES

        public List<ClsModCatOT> CargarCSV(ClsModCatOT objModel, out ClsModResultado objClsModResultado)  
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModCatOT> LstModCatOTCSV = new List<ClsModCatOT>();
            SqlDataReader sqlRead = null;

            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();
            try
            {
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.CommandText = "[OrdenesTrabajo].[dbo].[SpdRptCatOT]";
                conSql.DataReader = conSql.Command.ExecuteReader();

               
                string CodPrioridad = string.Empty;
                string Folio = string.Empty;
                string CodTipoOT = string.Empty;
                string Granja = string.Empty;
                string Area = string.Empty;
                string Sala = string.Empty;
                string Equipo = string.Empty;
                string Actividad = string.Empty;
                string Materiales = string.Empty;
                //string Fecha = string.Empty;
                string Estatus = string.Empty;
                string CodEstatus = string.Empty;
                string Tecnico1 = string.Empty;
                string Tecnico2 = string.Empty;
                string Tecnico3 = string.Empty;
                string Tecnico4 = string.Empty;
                string Tecnico5 = string.Empty;
                string TipoEvento = string.Empty;
                string CodEvento = string.Empty;
               
                if (conSql.DataReader.HasRows)
                {
                    while (conSql.DataReader.Read())
                    {
                        //el orden del modelo, es el orden en el que se acomodan las columnas del reporte
                        objModel = new ClsModCatOT();

                       
                        CodPrioridad = (string)(conSql.DataReader["CodPrioridad"] != DBNull.Value ? conSql.DataReader["CodPrioridad"] : string.Empty);
                        Folio = (conSql.DataReader["Folio"] != DBNull.Value ? conSql.DataReader["Folio"].ToString() : string.Empty);
                        CodTipoOT = (string)(conSql.DataReader["CodTipoOT"] != DBNull.Value ? conSql.DataReader["CodTipoOT"] : string.Empty);
                        Granja = (string)(conSql.DataReader["Granja"] != DBNull.Value ? conSql.DataReader["Granja"] : string.Empty);
                        Area = (string)(conSql.DataReader["Area"] != DBNull.Value ? conSql.DataReader["Area"] : string.Empty);
                        Sala= (string)(conSql.DataReader["Sala"] != DBNull.Value ? conSql.DataReader["Sala"] : string.Empty);
                        Equipo = (string)(conSql.DataReader["Equipo"] != DBNull.Value ? conSql.DataReader["Equipo"] : string.Empty);
                        Actividad = (string)(conSql.DataReader["Actividad"] != DBNull.Value ? conSql.DataReader["Actividad"] : string.Empty);
                        Materiales = (string)(conSql.DataReader["Materiales"] != DBNull.Value ? conSql.DataReader["Materiales"] : string.Empty);
                        Estatus = (string)(conSql.DataReader["Estatus"] != DBNull.Value ? conSql.DataReader["Estatus"] : string.Empty);
                        CodEstatus = (string)(conSql.DataReader["CodEstatus"] != DBNull.Value ? conSql.DataReader["CodEstatus"] : string.Empty);
                        Tecnico1 = (string)(conSql.DataReader["Tecnico1"] != DBNull.Value ? conSql.DataReader["Tecnico1"] : string.Empty);
                        Tecnico2 = (string)(conSql.DataReader["Tecnico2"] != DBNull.Value ? conSql.DataReader["Tecnico2"] : string.Empty);
                        Tecnico3 = (string)(conSql.DataReader["Tecnico3"] != DBNull.Value ? conSql.DataReader["Tecnico3"] : string.Empty);
                        Tecnico4 = (string)(conSql.DataReader["Tecnico4"] != DBNull.Value ? conSql.DataReader["Tecnico4"] : string.Empty);
                        Tecnico5 = (string)(conSql.DataReader["Tecnico5"] != DBNull.Value ? conSql.DataReader["Tecnico5"] : string.Empty);
                        TipoEvento = (string)(conSql.DataReader["Evento"] != DBNull.Value ? conSql.DataReader["Evento"] : string.Empty);
                        CodEvento = (string)(conSql.DataReader["CodEvento"] != DBNull.Value ? conSql.DataReader["CodEvento"] : string.Empty);

                        //int result = Int32.Parse(Id);
                        //objModel.IdOT = result;

                        //quitar caracteres - : de la fecha (folio)
                        string folioTmp = Folio.Replace("-","");
                        string folioTmp2 = folioTmp.Replace(":", "");
                        string folioTmp3 = folioTmp2.Replace(".", "");
                        string folioTmp4 = folioTmp3.Replace(" ", "");


                        objModel.CodPrioridad = CodPrioridad;
                        objModel.Folio = folioTmp4;
                        objModel.CodTipoOT = CodTipoOT;
                        objModel.Granja = Granja;
                        objModel.Area = Area; 
                        objModel.Sala = Sala;
                        objModel.Equipo = Equipo;
                        objModel.Actividad = Actividad;
                        objModel.Materiales = Materiales;
                        objModel.Fecha= Folio;
                        objModel.Estatus = Estatus;
                        objModel.CodEstatus = CodEstatus;
                        objModel.Tecnico1 = Tecnico1;
                        objModel.Tecnico2 = Tecnico2;
                        objModel.Tecnico3 = Tecnico3;
                        objModel.Tecnico4 = Tecnico4;
                        objModel.Tecnico5 = Tecnico5;
                        objModel.TipoEvento = TipoEvento;
                        objModel.CodEvento = CodEvento;
                        


                        

                        LstModCatOTCSV.Add(objModel);

                    }
                }

            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = Error + "Cargar CSV()" + ex.Message;

            }
            finally
            {
                if (sqlRead != null) sqlRead.Close();
            }
            return LstModCatOTCSV;
        }

        public List<ClsModCatOT> CargarPorFechas(ClsModRptXFecha objFecha , out ClsModResultado objClsModResultado)
        {
            objClsModResultado = new ClsModResultado();
            List<ClsModCatOT> LstModCatOTCSV = new List<ClsModCatOT>();
            SqlDataReader sqlRead = null;


            SqlNorson16 conSql = new SqlNorson16();
            conSql.CreateConn();
            try
            {
                conSql.Command = conSql.Connection.CreateCommand();
                conSql.Command.CommandType = CommandType.StoredProcedure;
                conSql.Command.Parameters.Add(new SqlParameter("@FechaIni", SqlDbType.Date) { Value = objFecha.fechaInicio });
                conSql.Command.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date) { Value = objFecha.fechaFin });
                conSql.Command.CommandText = "[OrdenesTrabajo].[dbo].[SpdRptCatOTFechas]";
                conSql.DataReader = conSql.Command.ExecuteReader();


                string CodPrioridad = string.Empty;
                string Folio = string.Empty;
                string CodTipoOT = string.Empty;
                string Granja = string.Empty;
                string Area = string.Empty;
                string Sala = string.Empty;
                string Equipo = string.Empty;
                string Actividad = string.Empty;
                string Materiales = string.Empty;
                //string Fecha = string.Empty;
                string Estatus = string.Empty;
                string CodEstatus = string.Empty;
                string Tecnico1 = string.Empty;
                string Tecnico2 = string.Empty;
                string Tecnico3 = string.Empty;
                string Tecnico4 = string.Empty;
                string Tecnico5 = string.Empty;
                string TipoEvento = string.Empty;
                string CodEvento = string.Empty;

                if (conSql.DataReader.HasRows)
                {
                    while (conSql.DataReader.Read())
                    {
                        //el orden del modelo, es el orden en el que se acomodan las columnas del reporte
                        ClsModCatOT objModel = new ClsModCatOT();


                        CodPrioridad = (string)(conSql.DataReader["CodPrioridad"] != DBNull.Value ? conSql.DataReader["CodPrioridad"] : string.Empty);
                        Folio = (conSql.DataReader["Folio"] != DBNull.Value ? conSql.DataReader["Folio"].ToString() : string.Empty);
                        CodTipoOT = (string)(conSql.DataReader["CodTipoOT"] != DBNull.Value ? conSql.DataReader["CodTipoOT"] : string.Empty);
                        Granja = (string)(conSql.DataReader["Granja"] != DBNull.Value ? conSql.DataReader["Granja"] : string.Empty);
                        Area = (string)(conSql.DataReader["Area"] != DBNull.Value ? conSql.DataReader["Area"] : string.Empty);
                        Sala = (string)(conSql.DataReader["Sala"] != DBNull.Value ? conSql.DataReader["Sala"] : string.Empty);
                        Equipo = (string)(conSql.DataReader["Equipo"] != DBNull.Value ? conSql.DataReader["Equipo"] : string.Empty);
                        Actividad = (string)(conSql.DataReader["Actividad"] != DBNull.Value ? conSql.DataReader["Actividad"] : string.Empty);
                        Materiales = (string)(conSql.DataReader["Materiales"] != DBNull.Value ? conSql.DataReader["Materiales"] : string.Empty);
                        Estatus = (string)(conSql.DataReader["Estatus"] != DBNull.Value ? conSql.DataReader["Estatus"] : string.Empty);
                        CodEstatus = (string)(conSql.DataReader["CodEstatus"] != DBNull.Value ? conSql.DataReader["CodEstatus"] : string.Empty);
                        Tecnico1 = (string)(conSql.DataReader["Tecnico1"] != DBNull.Value ? conSql.DataReader["Tecnico1"] : string.Empty);
                        Tecnico2 = (string)(conSql.DataReader["Tecnico2"] != DBNull.Value ? conSql.DataReader["Tecnico2"] : string.Empty);
                        Tecnico3 = (string)(conSql.DataReader["Tecnico3"] != DBNull.Value ? conSql.DataReader["Tecnico3"] : string.Empty);
                        Tecnico4 = (string)(conSql.DataReader["Tecnico4"] != DBNull.Value ? conSql.DataReader["Tecnico4"] : string.Empty);
                        Tecnico5 = (string)(conSql.DataReader["Tecnico5"] != DBNull.Value ? conSql.DataReader["Tecnico5"] : string.Empty);
                        TipoEvento = (string)(conSql.DataReader["Evento"] != DBNull.Value ? conSql.DataReader["Evento"] : string.Empty);
                        CodEvento = (string)(conSql.DataReader["CodEvento"] != DBNull.Value ? conSql.DataReader["CodEvento"] : string.Empty);

                        //int result = Int32.Parse(Id);
                        //objModel.IdOT = result;

                        //quitar caracteres - : de la fecha (folio)
                        string folioTmp = Folio.Replace("-", "");
                        string folioTmp2 = folioTmp.Replace(":", "");
                        string folioTmp3 = folioTmp2.Replace(".", "");
                        string folioTmp4 = folioTmp3.Replace(" ", "");


                        objModel.CodPrioridad = CodPrioridad;
                        objModel.Folio = folioTmp4;
                        objModel.CodTipoOT = CodTipoOT;
                        objModel.Granja = Granja;
                        objModel.Area = Area;
                        objModel.Sala = Sala;
                        objModel.Equipo = Equipo;
                        objModel.Actividad = Actividad;
                        objModel.Materiales = Materiales;
                        objModel.Fecha = Folio;
                        objModel.Estatus = Estatus;
                        objModel.CodEstatus = CodEstatus;
                        objModel.Tecnico1 = Tecnico1;
                        objModel.Tecnico2 = Tecnico2;
                        objModel.Tecnico3 = Tecnico3;
                        objModel.Tecnico4 = Tecnico4;
                        objModel.Tecnico5 = Tecnico5;
                        objModel.TipoEvento = TipoEvento;
                        objModel.CodEvento = CodEvento;





                        LstModCatOTCSV.Add(objModel);

                    }
                }

            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = Error + "Reporte por fechas()" + ex.Message;

            }
            finally
            {
                if (sqlRead != null) sqlRead.Close();
            }
            

            return LstModCatOTCSV;
        }


















    }
}
