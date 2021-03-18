using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

using ClbModOT;
using ClbNegOT;


namespace OrdenesTrabajo.Controllers
{
    //[Route("api/[controller]")]
    [EnableCors(origins: "*", headers:"*",methods:"*")]
    public class OrdenesTrabajoController : ApiController
    {


        // POST: OrdenesTrabajo/Create
        /// <summary>
        /// Realiza el cargar los equipos(herramientas) de una OT
        /// </summary>
        /// <param name="objModEquipo"> modelo que retorna la peticion</param>
        /// <returns>Modelo de ClsModEquipo denrto ClsModResultado</returns>
        /// 
        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [ActionName("CargarEquipo")]
        public List<ClsModEquipo> CargarEquipoLista()
        {
            ClsModEquipo objModel = new ClsModEquipo();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModEquipo> LstModCatEquipo = null;

            ClsNegCatOT objCatNeg = new ClsNegCatOT();
            try
            {
                LstModCatEquipo = objCatNeg.CargarEquipoLista();

                //objModResponse.lstResultado = objCatNeg.CargarEquipoLista<ClsModEquipo>(out objModResponse);


            }

            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return LstModCatEquipo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [ActionName("CargarPrioridad")]
        public List<ClsModPrioridad> CargarPrioridadLista()
        {
            ClsModPrioridad objModel = new ClsModPrioridad();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModPrioridad> LstModCatPrioridad = null;

            ClsNegCatOT objCatNeg = new ClsNegCatOT();
            try
            {
                LstModCatPrioridad = objCatNeg.CargarPrioridad();

             
            }

            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return LstModCatPrioridad;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [ActionName("CargarTipo")]
        public List<ClsModTipo> CargarTipoLista()
        {
            ClsModTipo objModel = new ClsModTipo();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModTipo> LstModCatTipo = null;

            ClsNegCatOT objCatNeg = new ClsNegCatOT();
            try
            {
                LstModCatTipo = objCatNeg.CargarTipo();

            }

            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return LstModCatTipo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [ActionName("CargarArea")]
        public List<ClsModArea> CargarAreaLista()
        {
            ClsModArea objModel = new ClsModArea();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModArea> LstModCatArea = null;

            ClsNegCatOT objCatNeg = new ClsNegCatOT();
            try
            {
                LstModCatArea = objCatNeg.CargarArea();

            }

            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return LstModCatArea;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [ActionName("CargarGranja")]
        public List<ClsModGranja> CargarGranjaLista()
        {
            ClsModGranja objModel = new ClsModGranja();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModGranja> LstModCatGranja = null;

            ClsNegCatOT objCatNeg = new ClsNegCatOT();
            try
            {
                LstModCatGranja = objCatNeg.CargarGranja();

            }

            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return LstModCatGranja;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [ActionName("CargarEstatus")]
        public List<ClsModEstatus> CargarEstatusLista()
        {
            ClsModEstatus objModel = new ClsModEstatus();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModEstatus> LstModCatEstatus = null;

            ClsNegCatOT objCatNeg = new ClsNegCatOT();
            try
            {
                LstModCatEstatus = objCatNeg.CargarEstatus();

            }

            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return LstModCatEstatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [ActionName("CargarEvento")]
        public List<ClsModEvento> CargarEventoLista()
        {
            ClsModEvento objModel = new ClsModEvento();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModEvento> LstModCatEvento = null;

            ClsNegCatOT objCatNeg = new ClsNegCatOT();
            try
            {
                LstModCatEvento = objCatNeg.CargarTípoEvento();

            }

            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return LstModCatEvento;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Authorize]
        [AllowAnonymous]
        [ActionName("Guardar")]
        public ClsModResultado GuardarOT ([FromBody] ClsModCatOT objModel)
        {
            ClsModResultado objClsModResultado = new ClsModResultado();
            ClsNegCatOT objCatNeg = new ClsNegCatOT();
            
            try
            {
                
                objClsModResultado = objCatNeg.GuardarOT(objModel);
            }
            catch (Exception ex)
            { 
                objClsModResultado.MsgError = ex.Message;
                
            }
            return objClsModResultado;
        }








    }
}
