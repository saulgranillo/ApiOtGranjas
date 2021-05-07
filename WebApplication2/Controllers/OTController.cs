using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClbModOT;
using ClbNegOT;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTController : ControllerBase
    {

        [HttpPost("Cargar")]
        [AllowAnonymous]
        public IActionResult CargarEstatusLista(ClsModCatOT obj)
        {
            return Ok(obj);
        }

        [HttpGet("CargarEquipo")]
        [AllowAnonymous]
        public IActionResult CargarEquipoLista()
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
            return Ok(LstModCatEquipo);
        }

        [HttpGet("CargarPrioridad")]
        [AllowAnonymous]
        public IActionResult CargarPrioridadLista()
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
            return Ok(LstModCatPrioridad);
        }

        [HttpGet("CargarTipo")]
        [AllowAnonymous]
        public IActionResult CargarTipoLista()
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
            return Ok(LstModCatTipo);
        }

        [HttpGet("CargarArea")]
        [AllowAnonymous]
        public IActionResult CargarAreaLista()
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
            return Ok(LstModCatArea);
        }

        [HttpGet("CargarGranja")]       
        [AllowAnonymous]
        public IActionResult CargarGranjaLista()
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
            return Ok(LstModCatGranja);
        }

        [HttpGet("CargarEstatus")]
        [AllowAnonymous]
        public IActionResult CargarEstatusLista()
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
            return Ok(LstModCatEstatus);
        }

        [HttpGet("CargarEvento")]
        [AllowAnonymous]
        public IActionResult CargarEventoLista()
        {
            //ClsModEvento objModel = new ClsModEvento();
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
            return Ok(LstModCatEvento);
        }

        [HttpPost("Guardar")]
        [AllowAnonymous]
        public IActionResult GuardarOT([FromBody]ClsModCatOT objModel)
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
            return Ok(objClsModResultado);
        }

        //La use solo para hacer la peticion de la imagen
        //[HttpPost("imagen")]
        //public IActionResult Imagen([FromBody] string base64Data)
        //{
        //    try
        //    {
        //        if (base64Data != "" && base64Data != null)
        //        {
        //            return Ok();
        //        }
        //        else
        //        {
        //            return Ok(null);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, $"Internal server error, {ex.Message}");
        //    }

        //}

        [HttpGet("CargarCSV")]
        [AllowAnonymous]
        public IActionResult CargarCSV()
        {
            ClsModCatOT objModel = new ClsModCatOT();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModCatOT> LstModCatOTCSV = null;

            ClsNegCatOT objCatNeg = new ClsNegCatOT();
            try
            {
                LstModCatOTCSV = objCatNeg.CargarCSV();
            }

            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return Ok(LstModCatOTCSV);
        }

        [HttpPost("CargarXFechas")]
        [AllowAnonymous]
        public IActionResult CargarXFechas(ClsModRptXFecha objFecha)
        {
            ClsModCatOT objModel = new ClsModCatOT();
            ClsModResultado objClsModResultado = new ClsModResultado();
            List<ClsModCatOT> LstModCatOTFechas = null;

            ClsNegCatOT objCatNeg = new ClsNegCatOT();
            try
            {
                LstModCatOTFechas = objCatNeg.CargarPorFechas(objFecha);
            }

            catch (Exception ex)
            {
                objClsModResultado.MsgError = ex.Message;
            }
            return Ok(LstModCatOTFechas);
        }







    }
}
