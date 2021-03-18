using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ClbModOT;
using ClbNegOT;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesTrabajoController : ControllerBase
    {
        [HttpGet("CargarEquipo")]
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
    }
}
