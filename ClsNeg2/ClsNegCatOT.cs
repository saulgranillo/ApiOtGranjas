using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

using ClbModOT;
using ClsDatOT;


using UtilidadesNorson.Conexiones;
//using static System.Net.Mime.MediaTypeNames;

namespace ClbNegOT
{
    public class ClsNegCatOT
    {
        //SqlConnection Con = null;
             
        public ClsNegCatOT()
        {
            //SqlNorson16 con = new SqlNorson16();
            //con.CreateConn();

        }

        public List<ClsModEquipo> CargarEquipoLista( ) //ClsModEquipo objModel,out ClsModResultado objClsModResultado
        {
            ClsModEquipo objModel = new ClsModEquipo();
           ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModEquipo> LstModCatEquipo = null;

            try
            {
                    LstModCatEquipo = new ClsDatOT.CLsDatOT().CargarEquipo( objModel, out objClsModResultado);
            }
            catch(Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }

            return LstModCatEquipo;
        }

        public List<ClsModPrioridad> CargarPrioridad() //ClsModEquipo objModel,out ClsModResultado objClsModResultado
        {
            ClsModPrioridad objModel = new ClsModPrioridad();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModPrioridad> LstModCatPrioridad = null;

            try
            {
                LstModCatPrioridad = new ClsDatOT.CLsDatOT().CargarPrioridad(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }

            return LstModCatPrioridad;
        }

        public List<ClsModTipo> CargarTipo() //ClsModEquipo objModel,out ClsModResultado objClsModResultado
        {
            ClsModTipo objModel = new ClsModTipo();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModTipo> LstModCatTipo = null;

            try
            {
                LstModCatTipo = new ClsDatOT.CLsDatOT().CargarTipo(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }

            return LstModCatTipo;
        }

        public List<ClsModArea> CargarArea() //ClsModEquipo objModel,out ClsModResultado objClsModResultado
        {
            ClsModArea objModel = new ClsModArea();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModArea> LstModCatArea = null;

            try
            {
                LstModCatArea = new ClsDatOT.CLsDatOT().CargarArea(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }

            return LstModCatArea;
        }

        public List<ClsModGranja> CargarGranja() //ClsModEquipo objModel,out ClsModResultado objClsModResultado
        {
            ClsModGranja objModel = new ClsModGranja();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModGranja> LstModCatGranja = null;

            try
            {
                LstModCatGranja = new ClsDatOT.CLsDatOT().CargarGranjas(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }

            return LstModCatGranja;
        }

        public List<ClsModEstatus> CargarEstatus() //ClsModEquipo objModel,out ClsModResultado objClsModResultado
        {
            ClsModEstatus objModel = new ClsModEstatus();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModEstatus> LstModCatEstatus = null;

            try
            {
                LstModCatEstatus = new ClsDatOT.CLsDatOT().CargarEstatus(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }

            return LstModCatEstatus;
        }

        public List<ClsModEvento> CargarTípoEvento() //ClsModEquipo objModel,out ClsModResultado objClsModResultado
        {
            ClsModEvento objModel = new ClsModEvento();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModEvento> LstModCatEvento= null;

            try
            {
                LstModCatEvento = new ClsDatOT.CLsDatOT().CargarTipoEvento(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }

            return LstModCatEvento;
        }

        public ClsModResultado GuardarOT (ClsModCatOT objModel)
        {
            ClsModResultado objClsModResultado = null;

            ClsModImagen objModImagen = new ClsModImagen();
            CLsDatOT objClsDatOT = new CLsDatOT();
            //ClsDatCatImagenes objDatImagen = new ClsDatCatImagenes();
            List<ClsModImagen> lstModImagen = null;
            try
            {
                if (objModel.IdOT > 0)
                {
                   //Modificar
                }
                else
                {

                    objClsModResultado = objClsDatOT.GuardarOT(objModel);

                    //foreach (var imagen in objModel.LstImagenes)
                    //{
                    //    objModImagen.LstModImagenes.Add(imagen);
                    //}

                    
                    if (objClsModResultado.Id >0)
                    {
                        if (objModel.LstImagenes != null || objModel.LstImagenes != "")
                        {
                            lstModImagen = new ClsDatCatImagenes().Guardar(objClsModResultado.Id, objModel.LstImagenes, out objClsModResultado);
                        }           
                    }
                }

            }
            catch (Exception ex)
            {
             objClsModResultado.MsgError =  ex.Message;
              
            }
            return objClsModResultado;
        }

        //para probar solo el guardado de la imagen cuando cambie el tipo en sql
        //public ClsModResultado GuardarImagen( string base64)
        //{
        //    ClsModResultado objClsModResultado = null;
        //    if (base64.Length >0)
        //    {
        //        List<ClsModImagen> lstModImagen = null;

        //        lstModImagen = new ClsDatCatImagenes().Guardar(1, base64, out objClsModResultado);
        //    }

        //    return objClsModResultado;
        //}

        //REPORTES

        public List<ClsModCatOT> CargarCSV() 
        {
            ClsModCatOT objModel = new ClsModCatOT();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModCatOT> LstModCatOTCSV= null;

            try
            {
                LstModCatOTCSV = new  ClsDatOT.CLsDatOT().CargarCSV(objModel, out objClsModResultado);
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }

            return LstModCatOTCSV;
        }

        public List<ClsModCatOT>CargarPorFechas(ClsModRptXFecha objFecha)
        {
            ClsModCatOT objModel = new ClsModCatOT();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModCatOT> LstModCatOTFechas = null;

            try
            {
                LstModCatOTFechas = new ClsDatOT.CLsDatOT().CargarPorFechas(objFecha, out objClsModResultado);
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }

            return LstModCatOTFechas;
        }


        public ClsModImagen CargarImagenXId(string IdOt)
        {
            ClsModImagen objReturn = new ClsModImagen();
            ClsModResultado objClsModResultado = new ClsModResultado();

            try
            {
                objReturn = new ClsDatCatImagenes().CargarImagenXId(IdOt);
            }
            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
                
            }

            return objReturn;
        }






    }
}
